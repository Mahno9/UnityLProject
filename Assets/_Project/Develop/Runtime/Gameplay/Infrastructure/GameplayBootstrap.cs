using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringMatchingManagment;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer       _container;
        private GameplayInputArgs _inputArgs;

        private Coroutine            _gameplayCoroutine;
        private GameplayCycle        _gameplayCycle;
        private bool                 _gonnaBackToMenu;
        private StringMatcherService _matcherService;

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
            _matcherService  = new StringMatcherService(stringGenerator.Generate());

            TypingInputService inputService = _container.Resolve<TypingInputService>();

            _gameplayCycle = new GameplayCycle(inputService, _matcherService, EndGameAction);

            yield break;
        }

        private void EndGameAction(bool isWin)
        {
            Debug.Log(isWin ? "Победа! Поздравляю!" : "Не получилось. Попробуй ещё раз!");

            _container.Resolve<ICoroutinesPerformer>().StopPerform(_gameplayCoroutine);
            _gonnaBackToMenu = true;
        }

        public override void Run()
        {
            Debug.Log($"Введите пин, состоящий из {(_inputArgs.StringGeneratorType == StringGeneratorType.RandomLetters ? "букв" : "цифр")}: {_matcherService.GetTargetString()}");

            _gameplayCoroutine = _container.Resolve<ICoroutinesPerformer>().StartPerform(_gameplayCycle.Update());
        }

        private void Update()
        {
            if (_gonnaBackToMenu)
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer  = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu));
            }
        }
    }
}