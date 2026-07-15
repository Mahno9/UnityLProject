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
}
