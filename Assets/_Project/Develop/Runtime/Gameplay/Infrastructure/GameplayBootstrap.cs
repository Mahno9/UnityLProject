using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Logic.TypeInputManagement;
using _Project.Develop.Runtime.Gameplay.Logic.TypeStringManagement;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer       _container;
        private GameplayInputArgs _inputArgs;

        private Coroutine     _gameplayCoroutine;
        private GameplayCycle _gameplayCycle;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log($"Вы попали на уровень {_inputArgs.StringGeneratorType}");
            Debug.Log("Инициализация геймплейной сцены");

            ITypeStringGenerator stringGenerator = _container.Resolve<StringGeneratorFactory>().Create(_inputArgs.StringGeneratorType);
            StringMatcherService matcherService  = new StringMatcherService(stringGenerator.Generate());

            TypingInputService inputService = _container.Resolve<TypingInputService>();

            _gameplayCycle = new GameplayCycle(inputService, matcherService);

            yield break;
        }

        public override void Run()
        {
            Debug.Log($"Введите пин, состоящий из {(_inputArgs.StringGeneratorType == StringGeneratorType.RandomLetters ? "букв" : "цифр")}");

            _gameplayCoroutine = _container.Resolve<ICoroutinesPerformer>().StartPerform(_gameplayCycle.Update());
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.F))
        //     {
        //         SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
        //         ICoroutinesPerformer coroutinesPerformer  = _container.Resolve<ICoroutinesPerformer>();
        //         coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu));
        //     }
        // }
    }
}