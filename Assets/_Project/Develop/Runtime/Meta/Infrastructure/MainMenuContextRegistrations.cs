using _Project.Develop.Runtime.Infrastructure.DI;

using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public static class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Процесс регистрации сервисов на сцене меню");

            container.RegisterAsSingle(CreateGameplayCycle);

            container.Initialize();
        }

        private static MenuGameplayCycle CreateGameplayCycle(DIContainer c)
        {
            return new MenuGameplayCycle(c);
        }
    }
}