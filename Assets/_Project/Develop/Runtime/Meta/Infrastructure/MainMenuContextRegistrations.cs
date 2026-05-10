using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.LevelPickerService;
using LProject.Assets._Project.Develop.Runtime.Meta.Infrastructure;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Процесс регистрации сервисов на сцене меню");
            container.RegisterAsSingle(CreateGameplayCycle);
            container.RegisterAsSingle(CreateLevelLoaderService);
        }

        private static GameplayCycle CreateGameplayCycle(DIContainer c) => new(c);

        private static LevelLoaderService CreateLevelLoaderService(DIContainer c) => new(c);
    }
}
