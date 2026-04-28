using _Project.Develop.Runtime.Gameplay.Logic.TypeInputManagement;
using _Project.Develop.Runtime.Gameplay.Logic.TypeStringManagement;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
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
