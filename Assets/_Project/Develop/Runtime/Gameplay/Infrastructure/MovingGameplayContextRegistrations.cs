using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.Infrastructure.MovingGameplayInputArgsManagement;
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
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateMonoEntitiesFactory);

            container.Initialize();
        }

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
            => new();

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
            => new(c);

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer c)
        {
            return new MonoEntitiesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>()
            );
        }
    }
}