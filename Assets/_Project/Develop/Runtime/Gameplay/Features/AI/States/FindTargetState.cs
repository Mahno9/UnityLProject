using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class FindTargetState : State, IUpdatableState
    {
        private readonly ITargetSelector          _targetSelector;
        private readonly EntitiesLifeContext      _entitiesLifeContext;
        private readonly ReactiveVariable<Entity> _currentTarget;

        public FindTargetState(
            ITargetSelector targetSelector,
            EntitiesLifeContext entitiesLifeContext,
            Entity entity)
        {
            _targetSelector = targetSelector;
            _entitiesLifeContext = entitiesLifeContext;
            _currentTarget = entity.CurrentTarget;

            SelectCurrentTarget();
        }

        public void Update(float deltaTime)
        {
            SelectCurrentTarget();
        }

        private void SelectCurrentTarget()
        {
            _currentTarget.Value = _targetSelector.SelectTargetFrom(_entitiesLifeContext.Entities);
        }
    }
}
