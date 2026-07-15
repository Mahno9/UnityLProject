---
paths: ["**/Generated/**/*.cs"]
---

# Генерируемый код — только чтение

Файлы в папках `Generated/` — **машинный вывод, править руками запрещено.**
Любая ручная правка будет затёрта при следующей перегенерации.

Это:

- `Assets/_Project/Develop/Generated/R.cs` — пути ассетов под `Resources/`
  (генератор `Editor/ResourcesReferenceGenerator.cs`).
- `Assets/_Project/Develop/Generated/S.cs` — имена сцен
  (генератор `Editor/ScenesReferenceGenerator.cs`).
- `Assets/_Project/Develop/Runtime/Gameplay/EntitiesCore/Generated/EntityAPI.cs`
  — fluent `Add*()`/свойства/`TryGet*()` по классам `IEntityComponent`
  (генератор `Editor/EntityAPIGenerator.cs`).

Перегенерация — автоматически на **каждой компиляции** и вручную через меню:
`Tools/Regenerate R.cs`, `Tools/Regenerate S.cs`, `Tools/GenerateEntityAPI`.

**Чтобы изменить содержимое — меняем источник, не вывод:**

- новый путь в `R.cs` → добавить ассет под `Assets/_Project/Resources/...`;
- новая сцена в `S.cs` → добавить `.unity` под `Assets/`;
- новый метод в `EntityAPI.cs` → добавить/изменить класс `IEntityComponent`.

Затем перегенерировать (пересборка проекта или пункт меню `Tools/*`).
