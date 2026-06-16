using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.Features.AI;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.AssetManagement;

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
            container.RegisterAsSingle(CreateAIBrainsContext);
            container.RegisterAsSingle(CreateBrainsFactory);
            container.RegisterAsSingle<IInputService>(CreateDesktopInput);
            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();

            container.Initialize();
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