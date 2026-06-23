# LProject

Учебный Unity-проект с самописным каркасом: лёгкий ECS + DI-контейнер + сценовый
bootstrap. **Билда, тестов и CI нет** — всё запускается вручную из редактора.

Этот файл описывает структуру и порядок работы. Стиль кода — в
`.claude/rules/code-style.md`. Автогенерируемый код — в
`.claude/rules/generated-readonly.md`.

## Стек

- **Unity `2022.3.58f1`** (LTS).
- **Единая сборка `Assembly-CSharp`** — в проектном коде **нет `.asmdef`** (все
  asmdef'ы лежат только внутри пакетов). Namespace повторяет путь от `Assets/`,
  префикс `_Project.` обязателен.
- **Самописный DI** — `Infrastructure/DI/DIContainer.cs` + `Registration.cs`.
  Иерархия `parent → child`, защита от циклов. API:
  `RegisterAsSingle<T>(Func<DIContainer,T> creator)` → `.NonLazy()`,
  `Resolve<T>()`, `Initialize()`. Lifecycle сервисов — через интерфейсы
  `IInitializable` / `IDisposable`.
- **Самописный ECS** — `Gameplay/EntitiesCore/`.
- **Async — по факту корутины** через `ICoroutinesPerformer` (например
  `GameEntryPoint.Initialize()` возвращает `IEnumerator`).
  ⚠️ `code-style.md` предписывает `UniTask`, но пакет **не установлен** (нет
  `Cysharp/UniTask`). До его подключения используем корутины; правило про
  UniTask вступит в силу после установки пакета.
- **NuGetForUnity** — для NuGet-зависимостей.

## Структура каталогов

Весь продакшн-код — под `Assets/_Project/`. Папка `Assets/Scripts/` пустая.

```
Assets/_Project/
├── Develop/
│   ├── Runtime/                     весь рантайм-код (~249 .cs)
│   │   ├── Configs/                 ScriptableObject-конфиги (Gameplay, Meta)
│   │   ├── Data/                    данные игрока, сохранения
│   │   ├── Gameplay/
│   │   │   ├── EntitiesCore/        ядро ECS: Entity, системы, фабрики, MonoEntity
│   │   │   │   └── Generated/       EntityAPI.cs (автоген fluent-методов)
│   │   │   ├── Features/            фичи: Attack, MovementFeature, AI, LifeCycle, ...
│   │   │   ├── Infrastructure/      bootstrap'ы геймплея + *ContextRegistrations
│   │   │   └── States/              стейт-машина геймплея (Win/Defeat/...)
│   │   ├── Infrastructure/
│   │   │   ├── EntryPoint/          GameEntryPoint, ProjectContextRegistrations
│   │   │   ├── DI/                  DIContainer, Registration
│   │   │   └── SceneBootstrap.cs    базовый класс bootstrap'а сцены
│   │   ├── Meta/                    мета-слой: Wallet, Market, Progression, Statistic
│   │   ├── UI/                      экраны/презентеры по фичам
│   │   └── Utilities/               Reactive, StateMachine, Configs, Coroutines, Timer, ...
│   ├── Editor/                      генераторы и тулзы (только редактор)
│   └── Generated/                   R.cs, S.cs (автоген — НЕ ПРАВИТЬ)
├── Resources/                       ассеты для рантайм-загрузки
│   ├── Entities/                    префабы сущностей (Hero.prefab, Ghost.prefab, ...)
│   └── Configs/                     .asset-инстансы конфигов
└── Scenes/                          GameEntryPoint, MainMenu, Level, MovingGameplayScene, Empty
```

## Каркас

Три опоры:

1. **ECS** — `Entity` хранит компоненты (`IEntityComponent`) и системы
   (`IEntitySystem`). `entity.OnUpdate(dt)` гоняет `IUpdatableSystem`'ы.
2. **DI** — сервисы/фабрики регистрируются в `DIContainer` из классов
   `*ContextRegistrations` (`Project`, `MainMenu`, `Gameplay`,
   `MovingGameplay`), резолвятся через `Resolve<T>()`.
3. **Сцены** — каждая сцена имеет наследника `SceneBootstrap` с пайплайном
   `ProcessRegistrations()` → `Initialize()` → `Run()`.

**Поток запуска:**

```
GameEntryPoint.Awake (сцена GameEntryPoint)
  → создаёт корневой DIContainer
  → ProjectContextRegistrations.Process(container)   // глобальные сервисы
  → корутиной: грузит конфиги и данные игрока
  → SceneSwitcherService → MainMenu
MainMenu: кнопка → LevelStarterService
  → SceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MovingGameplayScene,
                                         new MovingGameplayInputArgs(levelNumber))
MovingGameplayBootstrap.ProcessRegistrations
  → MovingGameplayContextRegistrations.Process(container, args)
  → Initialize(): резолвит контексты, спавнит героя через MainHeroFactory.Create(...)
  → Run(): запускает стейт-машину; Update() гоняет контексты сущностей/AI/ввода
```

Контекст между сценами передаётся типизированными `*InputArgs`
(`MovingGameplayInputArgs` несёт номер уровня).

## Из чего состоит «вещь» (entity)

На примере героя — сущность собирается из слоёв:

| Слой | Что это | Пример |
|------|---------|--------|
| **Config** | `ScriptableObject` с данными/балансом | `HeroConfig : EntityConfig` |
| **Prefab** | GameObject с `MonoEntity` + регистраторами (мост ECS↔Unity) | `Resources/Entities/Hero.prefab` |
| **Components** | чистые данные, `IEntityComponent` | `MoveSpeed`, `CurrentHealth` |
| **Systems** | логика над компонентами | `RigidbodyMovementSystem` |
| **Conditions** | составные булевы условия | `CanMove`, `MustDie` |
| **Factory** | собирает компоненты+системы | `EntitiesFactory.CreateHero` |
| **Спец-фабрика** | добавляет специфику, AI, регистрацию | `MainHeroFactory` |

Детали:

- **Component** — класс, реализующий `IEntityComponent`, без логики. Конвенция:
  одно public-поле `Value` (часто `ReactiveVariable<T>`). По таким классам
  генерируется fluent-API (`AddMoveSpeed`, `MoveSpeed`, `TryGetMoveSpeed` — см.
  ниже про `EntityAPI.cs`).
- **System** — реализует один или несколько интерфейсов:
  `IInitializableSystem.OnInit(entity)` (кешируем ссылки на компоненты),
  `IUpdatableSystem.OnUpdate(dt)` (логика по кадру),
  `IDisposableSystem.OnDispose()` (очистка).
- **MonoEntity** на префабе связывает ECS-`Entity` с GameObject; наследники
  `MonoEntityRegistrator` (`TransformEntityRegistrator`,
  `RigidbodyEntityRegistrator`, …) при линковке добавляют в сущность ссылки на
  Unity-компоненты.
- **Factory** в `EntitiesFactory` через fluent `Add*()` навешивает компоненты,
  условия и системы. **Специализированная** фабрика (`MainHeroFactory`,
  `EnemiesFactory`) поверх базовой добавляет специфику (команду, AI-`Brain`) и
  регистрирует сущность в `EntitiesLifeContext` (тот гоняет её `OnUpdate`).

## Как добавить новую «вещь»

Пример — новый враг «Bomber»:

1. **Config** — `Configs/Gameplay/Entities/BomberConfig.cs`
   (`: EntityConfig`, атрибут `[CreateAssetMenu]`), создать `.asset` в
   `Resources/Configs/...` и зарегистрировать (см. раздел про конфиги).
2. **Components** — новые `IEntityComponent` (если нужно новое поведение),
   рядом с фичей в `Gameplay/Features/<Feature>/`.
3. **Systems** — новые системы под эти компоненты там же.
4. **Prefab** — `Resources/Entities/Bomber.prefab` с `MonoEntity` и нужными
   `MonoEntityRegistrator`-ами.
5. **Метод фабрики** — `EntitiesFactory.CreateBomber(...)`: fluent-сборка
   компонентов, условий и систем.
6. **Спец-фабрика** — `BomberFactory` (резолвит зависимости из `DIContainer`,
   добавляет команду/AI, кладёт в `EntitiesLifeContext`).
7. **Регистрация** — добавить `BomberFactory` в
   `MovingGameplayContextRegistrations.Process`.
8. **Перегенерировать API** — меню `Tools/GenerateEntityAPI`, чтобы появились
   `Add*()`/`TryGet*()` для новых компонентов.
9. **AI** (если автономный) — `Brain` в `Features/AI/`.
10. **Спавн** — добавить в список врагов соответствующего `StageConfig`.

## Как добавить конфигурацию

1. **Класс** — `: ScriptableObject` (или `: EntityConfig` для сущностей) с
   `[CreateAssetMenu(menuName = "Configs/...", fileName = "...")]` в
   `Develop/Runtime/Configs/...`. Значения — `[field: SerializeField]`
   автосвойства с приватным сеттером.
2. **Ассет** — создать `.asset` через `Create → Configs → ...` в
   `Assets/_Project/Resources/Configs/...` и заполнить в инспекторе.
3. **Путь** — константа в `R.cs` подхватится автоматически при компиляции
   (генератор сканирует всё под `Resources/`). Магические строки не пишем —
   берём путь из `R.Configs....`.
4. **Регистрация загрузки** — добавить пару `typeof(MyConfig) → R.Configs...` в
   словарь `ResourcesConfigsLoader`
   (`Utilities/ConfigsManagement/ResourcesConfigsLoader.cs`). Все конфиги
   грузятся разом на старте в `ConfigsProviderService`.
5. **Потребление** — `_configsProviderService.GetConfig<MyConfig>()` (сервис
   получаем через DI). Прямые `Resources.Load` вне загрузчика не используем.

## Генерируемый код

`R.cs`, `S.cs` (`Develop/Generated/`) и `EntityAPI.cs`
(`EntitiesCore/Generated/`) — **машинный вывод, править руками нельзя.**
Перегенерируются на **каждой компиляции** (`[InitializeOnLoad]` /
`[InitializeOnLoadMethod]`) и вручную через меню:

- `Tools/Regenerate R.cs` — пути ассетов под `Resources/`.
- `Tools/Regenerate S.cs` — имена сцен.
- `Tools/GenerateEntityAPI` — fluent `Add*()`/свойства по классам
  `IEntityComponent`.

Чтобы изменить вывод — меняем источник (ассеты в `Resources/`, классы
компонентов) и перегенерируем. Подробнее — `.claude/rules/generated-readonly.md`.

## Запуск

Билд-пайплайна и тестов нет. Запуск = **Play в редакторе**.
`EntryPointSceneAutoLoader` (`Editor/PlayFromEntryPoint.cs`) принудительно
стартует Play с первой build-сцены (`GameEntryPoint`), поэтому инициализация
проходит корректно из любой открытой сцены.

## Конвенции

Стиль кода — `.claude/rules/code-style.md`: namespace = путь с префиксом
`_Project.`; явные типы вместо `var`; `if (x == false)` вместо `if (!x)`;
порядок членов «поля → конструктор → свойства → методы»; суффикс `Async` для
асинхронных методов; без магических чисел.
