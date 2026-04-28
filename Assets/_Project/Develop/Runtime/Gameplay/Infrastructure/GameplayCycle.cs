using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Logic.StringMatchingManagment;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle : IPlayerTypingSubscriber, IDisposable
    {
        private readonly TypingInputService   _inputService;
        private readonly DIContainer          _container;
        private readonly StringMatcherService _matcherService;
        private readonly Action<bool>         _endGameAction;

        public GameplayCycle(DIContainer container, StringMatcherService matcherService, Action<bool> endGameAction)
        {
            _container = container;
            _inputService = _container.Resolve<TypingInputService>();
            _matcherService = matcherService;
            _endGameAction = endGameAction;

            _inputService.SubscribeOnTyping(this);
        }

        public void Dispose() => StopListenTyping();

        public IEnumerator Update()
        {
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
                    _endGameAction(true);
                    break;

                case CompareResultType.PartMatch:
                    Debug.Log($"Продолжайте: \"{typedString}\" / {_matcherService.GetTargetString()}");
                    break;

                case CompareResultType.MissMatch:
                    Debug.Log($"Не совпадает: \"{typedString}\" / {_matcherService.GetTargetString()}");
                    _endGameAction(false);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StopListenTyping() => _inputService.UnsubscribeOnTyping(this);
    }
}