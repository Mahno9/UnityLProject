using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
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
            if (_rotation.Value == Quaternion.identity)
                return;

            _rigidbody.rotation = Quaternion.Normalize(_rotation.Value);
        }
    }
}