using System.Collections.Generic;

using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement
{
    public class TypingInputService
    {
        private readonly ReactiveVariable<string> _typedString = new();

        public IReadOnlyVariable<string> TypeString => _typedString;

        public void Update()
        {
            string input = Input.inputString;
            if (string.IsNullOrEmpty(input))
                return;

            foreach (char symbol in input)
                _typedString.Value += symbol;
        }
    }
}