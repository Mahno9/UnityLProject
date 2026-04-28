using _Project.Develop.Runtime.Gameplay.Logic.KeyInputManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея");

            container.RegisterAsSingle(CreateTypingInputService);
            container.RegisterAsSingle(CreateStringGeneratorFactory);
            container.RegisterAsSingle(CreateWaitForKeyService);
        }

        private static StringGeneratorFactory CreateStringGeneratorFactory(DIContainer _) => new();

        private static TypingInputService CreateTypingInputService(DIContainer _) => new();

        private static WaitForKeyService CreateWaitForKeyService(DIContainer c)
            => new(c.Resolve<ICoroutinesPerformer>());
    }
}