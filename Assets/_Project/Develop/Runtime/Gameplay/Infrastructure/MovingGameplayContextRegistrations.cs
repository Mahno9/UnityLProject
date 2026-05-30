using _Project.Develop.Runtime.Gameplay.Infrastructure.MovingGameplayInputArgsManagement;
using _Project.Develop.Runtime.Infrastructure.DI;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public static class MovingGameplayContextRegistrations
    {
        public static void Process(DIContainer container, MovingGameplayInputArgs args)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея движения");

            container.RegisterAsSingle(CreateMovingGameplayCycle);

            // register feature services here

            container.Initialize();
        }

        private static MovingGameplayCycle CreateMovingGameplayCycle(DIContainer c)
            => new(c);
    }
}
