using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class GunTransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float>   _rotationSpeed;
        private ICompositeCondition       _canRotate;
        private Transform                 _transform;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.GunRotationDirection;
            _rotationSpeed     = entity.GunRotationSpeed;
            _transform         = entity.GunTransform;
            
            _canRotate         = entity.CanRotate;

            if (_rotationDirection.Value != Vector3.zero)
                _transform.rotation = Quaternion.LookRotation(_rotationDirection.Value.normalized);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (_rotationDirection.Value == Vector3.zero)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_rotationDirection.Value.normalized);
            float      step         = _rotationSpeed.Value * deltaTime;
            Quaternion rotation     = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);

            _transform.rotation = rotation; // TODO: Check
        }
    }
}