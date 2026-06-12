using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class CharacterControllerRotationApplierSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Quaternion> _rotation;
        private CharacterController          _characterController;

        public void OnInit(Entity entity)
        {
            _rotation            = entity.Rotation;
            _characterController = entity.CharacterController;
        }

        public void OnUpdate(float deltaTime)
        {
            _characterController.transform.rotation = _rotation.Value;
        }
    }
}
