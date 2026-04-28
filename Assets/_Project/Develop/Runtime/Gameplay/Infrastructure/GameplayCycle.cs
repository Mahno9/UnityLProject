using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Logic.TypeInputManagement;
using _Project.Develop.Runtime.Gameplay.Logic.TypeStringManagement;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle : IPlayerTypingSubscriber, IDisposable
    {
        private readonly TypingInputService   _inputService;
        private readonly StringMatcherService _matcherService;

        public GameplayCycle(TypingInputService inputService, StringMatcherService matcherService)
        {
            _inputService = inputService;
            _matcherService = matcherService;

            _inputService.SubscribeOnTyping(this);
        }

        public void Dispose() => _inputService.UnsubscribeOnTyping(this);

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
                    break;
                case CompareResultType.PartMatch:
                    Debug.Log($"Частичное совпадение: \"{typedString}\"");
                    break;
                case CompareResultType.MissMatch:
                    Debug.Log($"Нет совпадения: \"{typedString}\"");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}