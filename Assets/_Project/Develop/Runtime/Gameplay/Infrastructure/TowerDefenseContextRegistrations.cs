using _Project.Develop.Runtime.Configs.Gameplay.Entities;
using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.Features.AI;
using _Project.Develop.Runtime.Gameplay.Features.Enemies;
using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.Mine;
using _Project.Develop.Runtime.Gameplay.Features.PlayerStructures;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.States;
using _Project.Develop.Runtime.Gameplay.States.TowerDefense;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.Utilities.AssetManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.Timer;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public static class TowerDefenseContextRegistrations
    {
        public static void Process(DIContainer container, TowerDefenseInputArgs args, LevelsListConfig levelsList)
        {
            Debug.Log("Процесс регистрации сервисов на сцене tower-defense");

            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateColliderRegistryService);
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateMonoEntitiesFactory);
            container.RegisterAsSingle(CreateAIBrainsContext);
            container.RegisterAsSingle(CreateBrainsFactory);
            container.RegisterAsSingle(CreateExplosionFactory);
            container.RegisterAsSingle(CreatePlayerStructuresFactory);
            container.RegisterAsSingle(CreateEnemiesFactory);
            container.RegisterAsSingle<IInputService>(CreateDesktopInput);

            container.RegisterAsSingle((c) => levelsList.GetBy(args.LevelNumber)); // LevelConfig
            container.RegisterAsSingle(CreateProductItemsFactory);
            container.RegisterAsSingle(CreateMarketService);

            container.RegisterAsSingle(CreateClickAreaService);
            container.RegisterAsSingle(CreateEntityTrackingService);
            container.RegisterAsSingle(CreateWaveEnemyCounterService);
            container.RegisterAsSingle(CreateEnemySpawnService);
            container.RegisterAsSingle(CreateMineSpawnService);
            container.RegisterAsSingle(CreatePlayerExplosionOnClickService);
            container.RegisterAsSingle(CreateStartBattleService);

            container.RegisterAsSingle(CreateStagesFactory);
            container.RegisterAsSingle(CreateStageProviderService);
            container.RegisterAsSingle(CreateStatesFactory);
            container.RegisterAsSingle((c) => CreateGameplayStatesContext(c, args));

            container.Initialize();
        }

        private static StageProviderService CreateStageProviderService(DIContainer c)
        {
            return new StageProviderService(c.Resolve<LevelConfig>(), c.Resolve<StagesFactory>());
        }

        private static ProductItemsFactory CreateProductItemsFactory(DIContainer c)
            => new(c);

        private static MarketService CreateMarketService(DIContainer c)
            => new(
                c.Resolve<WalletService>(),
                c.Resolve<ConfigsProviderService>().GetConfig<MarketConfig>(),
                c.Resolve<ProductItemsFactory>());

        private static GameplayStatesContext CreateGameplayStatesContext(DIContainer c, TowerDefenseInputArgs args)
        {
            return new GameplayStatesContext(
                c.Resolve<TowerDefenseStatesFactory>().CreateGameplayStateMachine(args));
        }

        private static TowerDefenseStatesFactory CreateStatesFactory(DIContainer c)
            => new(c);

        private static StagesFactory CreateStagesFactory(DIContainer c)
            => new(c);

        private static ClickAreaService CreateClickAreaService(DIContainer c)
            => new();

        private static EntityTrackingService CreateEntityTrackingService(DIContainer c)
            => new();

        private static WaveEnemyCounterService CreateWaveEnemyCounterService(DIContainer c)
            => new(c.Resolve<EntitiesLifeContext>());

        private static EnemyRandomPointSpawnService CreateEnemySpawnService(DIContainer c)
            => new(c.Resolve<EnemiesFactory>());

        private static MineSpawnService CreateMineSpawnService(DIContainer c)
            => new(c.Resolve<ClickAreaService>(), c.Resolve<PlayerStructuresFactory>(), c.Resolve<MarketService>());

        private static PlayerExplosionOnClickService CreatePlayerExplosionOnClickService(DIContainer c)
        {
            ExplosionConfig config = c.Resolve<ConfigsProviderService>().GetConfig<ExplosionConfig>();

            return new PlayerExplosionOnClickService(
                c.Resolve<ClickAreaService>(),
                c.Resolve<ExplosionFactory>(),
                config.Damage,
                new TimerService(config.CreationCooldown, c.Resolve<ICoroutinesPerformer>()));
        }

        private static StartBattleService CreateStartBattleService(DIContainer c)
            => new();

        private static EnemiesFactory CreateEnemiesFactory(DIContainer c)
            => new(c);

        private static DesktopInput CreateDesktopInput(DIContainer c)
            => new();

        private static PlayerStructuresFactory CreatePlayerStructuresFactory(DIContainer c)
            => new(c);

        private static ExplosionFactory CreateExplosionFactory(DIContainer c)
            => new(c);

        private static AIBrainsContext CreateAIBrainsContext(DIContainer c)
            => new();

        private static BrainsFactory CreateBrainsFactory(DIContainer c)
            => new(c);

        private static CollidersRegistryService CreateColliderRegistryService(DIContainer c)
            => new();

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
            => new();

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
            => new(c);

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer c)
        {
            return new MonoEntitiesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<CollidersRegistryService>());
        }
    }
}
