using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.Features.AI;
using _Project.Develop.Runtime.Gameplay.Features.Enemies;
using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.MainHero;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.States;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.AssetManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;

using UnityEngine;


namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public static class MovingGameplayContextRegistrations
    {
        public static void Process(DIContainer container, MovingGameplayInputArgs args)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея движения");

            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateColliderRegistryService);
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateExplosionFactory);
            container.RegisterAsSingle(CreateAIBrainsContext);
            container.RegisterAsSingle(CreateBrainsFactory);
            container.RegisterAsSingle<IInputService>(CreateDesktopInput);
            container.RegisterAsSingle(CreateMonoEntitiesFactory);
            container.RegisterAsSingle((c) => CreateGameplayStatesContext(c, args));
            container.RegisterAsSingle(CreateGameplayStatesFactory);
            container.RegisterAsSingle(CreateMainHeroHolderService);
            container.RegisterAsSingle(CreatePreparationTriggerService);
            container.RegisterAsSingle((c) => CreateStageProviderService(c, args));
            container.RegisterAsSingle(CreateStagesFactory);
            container.RegisterAsSingle(CreateEnemiesFactory);
            container.RegisterAsSingle(CreateMainHeroFactory);

            container.Initialize();
        }

        private static GameplayStatesContext CreateGameplayStatesContext(DIContainer c, MovingGameplayInputArgs args)
        {
            return new GameplayStatesContext(c.Resolve<GameplayStatesFactory>().CreateGameplayStateMachine(args));
        }

        private static GameplayStatesFactory CreateGameplayStatesFactory(DIContainer c)
        {
            return new GameplayStatesFactory(c);
        }

        private static MainHeroHolderService CreateMainHeroHolderService(DIContainer c)
        {
            return new MainHeroHolderService(c.Resolve<EntitiesLifeContext>());
        }

        private static PreparationTriggerService CreatePreparationTriggerService(DIContainer c)
        {
            return new PreparationTriggerService(
                c.Resolve<EntitiesFactory>(),
                c.Resolve<EntitiesLifeContext>());
        }

        private static StageProviderService CreateStageProviderService(DIContainer c, MovingGameplayInputArgs args)
        {
            return new StageProviderService(
                c.Resolve<ConfigsProviderService>().GetConfig<LevelsListConfig>().GetBy(args.LevelNumber),
                c.Resolve<StagesFactory>());
        }

        private static StagesFactory CreateStagesFactory(DIContainer c)
        {
            return new StagesFactory(c);
        }

        private static EnemiesFactory CreateEnemiesFactory(DIContainer c)
        {
            return new EnemiesFactory(c);
        }

        private static MainHeroFactory CreateMainHeroFactory(DIContainer c)
        {
            return new MainHeroFactory(c);
        }

        private static DesktopInput CreateDesktopInput(DIContainer c)
        {
            return new DesktopInput();
        }

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

        private static ExplosionFactory CreateExplosionFactory(DIContainer c)
            => new(c);

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer c)
        {
            return new MonoEntitiesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<CollidersRegistryService>()
            );
        }
    }
}