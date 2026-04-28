using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
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
        }

        private static StringGeneratorFactory CreateStringGeneratorFactory(DIContainer _) => new();

        private static TypingInputService CreateTypingInputService(DIContainer _) => new();
    }
}
