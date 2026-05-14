using System.Collections.Generic;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement
{
    public class TypingInputService
    {
        private readonly List<IPlayerTypingSubscriber> _subscribers = new();
        private          string                        _typedString;

        public void SubscribeOnTyping(IPlayerTypingSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void UnsubscribeOnTyping(IPlayerTypingSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Update()
        {
            string input = Input.inputString;
            if (string.IsNullOrEmpty(input))
                return;

            foreach (char symbol in input)
                _typedString += symbol;

            for (int i = _subscribers.Count - 1; i >= 0; i--)
                _subscribers[i].OnPlayerInput(_typedString);
        }
    }
}