using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.LevelsManagment;

using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public static class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Процесс регистрации сервисов на сцене меню");

            container.RegisterAsSingle(CreateGameplayCycle);
            container.RegisterAsSingle(CreateLevelLoaderService);

            container.Initialize();
        }

        private static MenuGameplayCycle CreateGameplayCycle(DIContainer c)
        {
            return new MenuGameplayCycle(c);
        }

        private static LevelLoaderService CreateLevelLoaderService(DIContainer c)
        {
            return new LevelLoaderService(c);
        }
    }
}