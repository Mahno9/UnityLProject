using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Logic.KeyInputManagement;
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

        private Coroutine            _gameplayCycleCoroutine;
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
            _matcherService = new StringMatcherService(stringGenerator.Generate());

            _gameplayCycle = new GameplayCycle(_container, _matcherService, EndGameAction);

            yield break;
        }

        private void EndGameAction(bool isWin)
        {
            _container.Resolve<ICoroutinesPerformer>().StopPerform(_gameplayCycleCoroutine);

            if (isWin)
            {
                Debug.Log("Победа! Поздравляем!");
                _container.Resolve<WaitForKeyService>().ListenForKeyCodeOnce(KeyCode.Space, BackToMenu);
            }
            else
            {
                Debug.Log("Не получилось. Попробуй ещё раз!");
                _container.Resolve<WaitForKeyService>().ListenForKeyCodeOnce(KeyCode.Space, RestartLevel);
            }

            Debug.Log("Нажмите Пробел чтобы продолжить");
        }

        public override void Run()
        {
            Debug.Log($"Введите пин, состоящий из {(_inputArgs.StringGeneratorType == StringGeneratorType.RandomLetters ? "букв" : "цифр")}: {_matcherService.GetTargetString()}");

            _gameplayCycleCoroutine = _container.Resolve<ICoroutinesPerformer>().StartPerform(_gameplayCycle.Update());
        }

        private void BackToMenu() => GoToScene(S._Project.Scenes.MainMenu);

        private void RestartLevel() => GoToScene(S._Project.Scenes.Level);

        private void GoToScene(string scene)
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer  = _container.Resolve<ICoroutinesPerformer>();
            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(scene, _inputArgs));
        }
    }
}