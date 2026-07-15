using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float>   _rotationSpeed;
        private ICompositeCondition       _canRotate;
        private Rigidbody                 _rigidbody;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed     = entity.RotationSpeed;
            _canRotate         = entity.CanRotate;
            _rigidbody         = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (_rotationDirection.Value == Vector3.zero)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_rotationDirection.Value.normalized);
            float      step         = _rotationSpeed.Value * deltaTime;
            Quaternion rotation     = Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step);

            _rigidbody.MoveRotation(rotation);
        }
    }
}
