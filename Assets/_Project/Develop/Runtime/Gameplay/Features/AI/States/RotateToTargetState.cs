using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class RotateToTargetState : State, IUpdatableState
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<Entity>  _currentTarget;
        private Transform                 _transform;

        public RotateToTargetState(Entity entity) : base()
        {
            // _rotationDirection = entity.RotationDirection; // TODO
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value != null)
                _rotationDirection.Value = (_currentTarget.Value.Transform.position - _transform.position).normalized;
        }
    }
}
