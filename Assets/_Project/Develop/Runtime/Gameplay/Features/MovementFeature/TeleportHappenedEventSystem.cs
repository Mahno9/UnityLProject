using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class TeleportHappenedEventSystem : IInitializableSystem, IUpdatableSystem
    {
        private Rigidbody            _rigidbody;
        private ReactiveEvent        _onTeleportEvent;
        private PreviousBodyPosition _previousBodyPosition;

        public void OnInit(Entity entity)
        {
            _rigidbody            = entity.Rigidbody;
            _onTeleportEvent      = entity.TeleportHappenedEvent;
            _previousBodyPosition = entity.PreviousBodyPositionC;
            _previousBodyPosition.Value = _rigidbody.position;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_rigidbody.position == _previousBodyPosition.Value)
                return;

            _previousBodyPosition.Value = _rigidbody.position;
            _onTeleportEvent?.Invoke();
        }
    }
}
