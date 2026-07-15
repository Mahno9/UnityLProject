using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class AlongMovementRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<Vector3> _rotationDirection;

        public void OnInit(Entity entity)
        {
            _moveDirection     = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

            if (_moveDirection.Value != Vector3.zero)
                _rotationDirection.Value = _moveDirection.Value;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_moveDirection.Value != Vector3.zero)
                _rotationDirection.Value = _moveDirection.Value;
        }
    }
}
