using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyRotationApplierSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Quaternion> _rotation;
        private Rigidbody                    _rigidbody;

        public void OnInit(Entity entity)
        {
            _rotation = entity.Rotation;
            _rigidbody = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            _rigidbody.rotation = _rotation.Value;
        }
    }
}