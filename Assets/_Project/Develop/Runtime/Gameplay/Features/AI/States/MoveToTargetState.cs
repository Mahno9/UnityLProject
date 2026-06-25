using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class MoveToTargetState : State, IUpdatableState
    {
        private readonly ReactiveVariable<Vector3> _moveDirection;
        private readonly ReactiveVariable<Entity>  _currentTarget;
        private readonly Transform                 _transform;

        public MoveToTargetState(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;

            UpdateMoveDirection();
        }

        public override void Exit()
        {
            base.Exit();

            _moveDirection.Value = Vector3.zero;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value == null)
            {
                _moveDirection.Value = Vector3.zero;
                return;
            }

            UpdateMoveDirection();
        }

        private void UpdateMoveDirection()
        {
            _moveDirection.Value = (_currentTarget.Value.Transform.position - _transform.position).normalized;
        }
    }
}
