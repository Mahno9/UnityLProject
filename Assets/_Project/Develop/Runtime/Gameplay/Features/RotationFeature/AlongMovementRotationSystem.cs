using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class AlongMovementRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3>    _moveDirection;
        private ReactiveVariable<float>      _rotationSpeed;
        private ReactiveVariable<Quaternion> _rotation;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _rotationSpeed = entity.RotationSpeed;
            _rotation = entity.Rotation;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 targetLookDirection = _moveDirection.Value.normalized;

            Quaternion toRotation = Quaternion.LookRotation(targetLookDirection);
            float      step       = _rotationSpeed.Value * deltaTime;

            _rotation.Value = Quaternion.RotateTowards(_rotation.Value, toRotation, step);
        }
    }
}