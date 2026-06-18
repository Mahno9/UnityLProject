using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerInputMovementState : State, IUpdatableState
    {
        private readonly IInputService             _inputService;
        private readonly ReactiveVariable<Vector3> _movementDirection;
        private readonly ReactiveVariable<Vector3> _rotationDirection;

        public PlayerInputMovementState(
            Entity entity,
            IInputService inputService)
        {
            _inputService = inputService;
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;
        }

        public void Update(float deltaTime)
        {
            _movementDirection.Value = _inputService.Direction;
            _rotationDirection.Value = _inputService.Direction;
        }

        public override void Exit()
        {
            base.Exit();

            _movementDirection.Value = Vector3.zero;
        }
    }

    public class PlayerManualAimingState : UpdatableState
    {
        private readonly IInputService             _inputService;
        private readonly ReactiveVariable<Vector3> _rotationDirection;
        private readonly ReactiveEvent             _attackRequest;

        public PlayerManualAimingState(Entity entity, IInputService inputService)
        {
            _inputService = inputService;
            _rotationDirection = entity.RotationDirection;
            _attackRequest = entity.StartAttackRequest;

            _inputService.FireEvent.Subscribe(OnFireEvent);
        }

        private void OnFireEvent()
        {
            _attackRequest.Invoke();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _rotationDirection.Value = Quaternion.AngleAxis(_inputService.RotationDelta.y, Vector3.up) * _rotationDirection.Value;
        }
    }
}
