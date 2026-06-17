using _Project.Develop.Runtime.Utilities.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;

using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Utilities.StateMachineCore
{
    public abstract class StateMachine<TState> : State, IDisposable, IUpdatableState where TState : class, IState
    {
        private List<StateNode<TState>> _states = new();

        private StateNode<TState> _currentState;

        private bool _isRunning;

        private List<IDisposable> _disposables;

        protected StateMachine(List<IDisposable> disposables)
        {
            _disposables = new List<IDisposable>(disposables);
        }

        protected TState CurrentState => _currentState.State;

        public void AddState(TState state) => _states.Add(new StateNode<TState>(state));

        public void AddTransition(TState fromState, TState toState, ICondition condition)
        {
            StateNode<TState> from = _states.First(stateNode => stateNode.State == fromState);
            StateNode<TState> to = _states.First(stateNode => stateNode.State == toState);

            from.AddTransition(new StateTransition<TState>(to, condition));
        }

        public void AddTransition(TState fromState, TState toState, ReactiveEvent triggerEvent)
        {
            StateNode<TState> from = _states.First(stateNode => stateNode.State == fromState);
            StateNode<TState> to = _states.First(stateNode => stateNode.State == toState);

            from.AddTransition(new StateTransitionOnEvent<TState>(to, triggerEvent));
        }

        public void Update(float deltaTime)
        {
            if (_isRunning == false)
                return;

            foreach (StateTransition<TState> transition in _currentState.Transitions)
            {
                if (transition.Condition.Evaluate())
                {
                    SwitchState(transition.ToState);
                    break;
                }
            }

            UpdateLogic(deltaTime);
        }

        protected virtual void UpdateLogic(float deltaTime) { }

        public void Dispose()
        {
            _isRunning = false;

            foreach (StateNode<TState> stateNode in _states)
                if (stateNode.State is IDisposable disposableState)
                    disposableState.Dispose();

            _states.Clear();

            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();

            _disposables.Clear();
        }

        public override void Enter()
        {
            base.Enter();

            if (_currentState == null)
                SwitchState(_states[0]);

            _isRunning = true;
        }

        public override void Exit()
        {
            base.Exit();

            _currentState?.State.Exit();

            _isRunning = false;
        }

        private void SwitchState(StateNode<TState> nextState)
        {
            if (_currentState is not null)
            {
                _currentState.State.Exit();
                foreach (StateTransition<TState> currentStateTransition in _currentState.Transitions)
                    currentStateTransition.Discharge();

                Debug.Log($"State change: {_currentState.State.GetType().Name} -> {nextState.State.GetType().Name}");
            }
            else
            {
                Debug.Log($"State init: {nextState.State.GetType().Name}");
            }

            _currentState = nextState;
            _currentState.State.Enter();
            foreach (StateTransition<TState> currentStateTransition in _currentState.Transitions)
                currentStateTransition.Charge();
        }
    }
}
