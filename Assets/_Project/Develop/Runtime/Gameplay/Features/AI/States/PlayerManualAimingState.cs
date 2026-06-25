using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
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