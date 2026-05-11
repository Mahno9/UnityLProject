using System;
using System.Collections;

using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagment;
using _Project.Develop.Runtime.Gameplay.Logic.KeyInputManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringMatchingManagment;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle : IPlayerTypingSubscriber, IDisposable
    {
        private readonly TypingInputService   _inputService;
        private readonly DIContainer          _container;
        private readonly StringMatcherService _matcherService;
        private          Coroutine            _gameplayCycleCoroutine;

        public GameplayCycle(DIContainer container, StringMatcherService matcherService)
        {
            _container = container;
            _inputService = _container.Resolve<TypingInputService>();
            _matcherService = matcherService;

            _inputService.SubscribeOnTyping(this);
        }

        public void Dispose() => StopListenTyping();

        public void Start()
        {
            _gameplayCycleCoroutine = _container.Resolve<ICoroutinesPerformer>().StartPerform(Update());
        }

        private IEnumerator Update()
        {
            StringGeneratorType stringType = _container.Resolve<GameplayInputArgsService>().Get().StringGeneratorType;
            Debug.Log($"Введите пин, состоящий из {(stringType == StringGeneratorType.RandomLetters ? "букв" : "цифр")}: {_matcherService.GetTargetString()}");

            while (true)
            {
                _inputService.Update();
                yield return null;
            }
        }

        public void OnPlayerInput(string typedString)
        {
            CompareResultType result = _matcherService.MatchString(typedString);

            switch (result)
            {
                case CompareResultType.FullMatch:
                    Debug.Log($"Полное совпадение: \"{typedString}\"");
                    EndGameAction(true);
                    break;

                case CompareResultType.PartMatch:
                    Debug.Log($"Продолжайте: \"{typedString}\" / {_matcherService.GetTargetString()}");
                    break;

                case CompareResultType.MissMatch:
                    Debug.Log($"Не совпадает: \"{typedString}\" / {_matcherService.GetTargetString()}");
                    EndGameAction(false);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
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

        private void StopListenTyping() => _inputService.UnsubscribeOnTyping(this);

        private void BackToMenu() => GoToScene(S._Project.Scenes.MainMenu);

        private void RestartLevel() => GoToScene(S._Project.Scenes.Level);

        private void GoToScene(string scene)
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer  = _container.Resolve<ICoroutinesPerformer>();
            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(scene, _container.Resolve<GameplayInputArgsService>().Get()));
        }
    }
}