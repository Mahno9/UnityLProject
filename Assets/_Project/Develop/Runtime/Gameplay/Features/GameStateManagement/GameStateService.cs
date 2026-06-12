using System;
using System.Collections;
using System.Collections.Generic;

using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic.GameStateManagement
{
    public class GameStateService : IInitializable
    {
        private readonly GameStateFactory _stateFactory;

        private readonly Dictionary<Type, IGameState> _states = new ();
        private          IGameState                   _currentState;

        public GameStateService(GameStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Initialize()
        {
            AddState(_stateFactory.CreateTypingGameState());
            AddState(_stateFactory.CreateWinGameState());
            AddState(_stateFactory.CreateLoseGameState());

            SetState(typeof(TypingGameState));
        }

        public IEnumerator Update()
        {
            while (true)
            {
                _currentState.Update();
                yield return null;
            }
        }

        public void SetState(Type stateType)
        {
            if (stateType is null)
                return;

            Debug.Log($"Leaving state: {_currentState?.GetType()}");
            _currentState?.OnExit();

            _currentState = _states[stateType];

            Debug.Log($"Entering state: {_currentState.GetType()}");
            _currentState.OnEnter();
        }

        private void AddState<T>(T newGameState) where T : IGameState
            => _states[typeof(T)] = newGameState;
    }
}