using _Project.Develop.Runtime.Gameplay.Logic.KeyInputManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringMatchingManagment;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public static class GameplayContextRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея");

            container.RegisterAsSingle(CreateStringGeneratorFactory);
            container.RegisterAsSingle(CreateStringMatcherService);
            container.RegisterAsSingle(CreateGameplayCycle);
            container.RegisterAsSingle(CreateTypingInputService);
            container.RegisterAsSingle(CreateWaitForKeyService);
            container.RegisterAsSingle(c => CreateGameplayInputArgsService(c, args));

            container.Initialize();
        }

        private static StringGeneratorFactory CreateStringGeneratorFactory(DIContainer _) => new();

        private static StringMatcherService CreateStringMatcherService(DIContainer c)
        {
            GameplayInputArgsService inputArgsService = c.Resolve<GameplayInputArgsService>();
            ITypeStringGenerator     stringGenerator  = c.Resolve<StringGeneratorFactory>().Create(inputArgsService.Get().StringGeneratorType);
            return new StringMatcherService(stringGenerator.Generate());
        }

        private static GameplayCycle CreateGameplayCycle(DIContainer c)
            => new(c, c.Resolve<StringMatcherService>());

        private static TypingInputService CreateTypingInputService(DIContainer _) => new();

        private static WaitForKeyService CreateWaitForKeyService(DIContainer c)
            => new(c.Resolve<ICoroutinesPerformer>());

        private static GameplayInputArgsService CreateGameplayInputArgsService(DIContainer c, GameplayInputArgs args) => new(args);
    }
}