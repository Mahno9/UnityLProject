using System;

using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Utilities.StateMachineCore
{
    public class StateTransitionOnEvent<TState> : StateTransition<TState> where TState : class, IState
    {
        private          bool          _isTriggered;
        private readonly ReactiveEvent _triggerEvent;
        private          IDisposable   _triggerSubscription;

        public StateTransitionOnEvent(StateNode<TState> toState, ReactiveEvent triggerEvent) : base(toState, null)
        {
            _triggerEvent = triggerEvent;
            Condition = new FuncCondition(() => _isTriggered);
        }

        public override void Charge()
        {
            base.Charge();
            _isTriggered = false;
            _triggerSubscription = _triggerEvent.Subscribe(OnTrigger);
        }

        public override void Discharge()
        {
            base.Discharge();
            _triggerSubscription.Dispose();
        }

        private void OnTrigger()
        {
            _isTriggered = true;
            _triggerSubscription.Dispose();
        }
    }
}