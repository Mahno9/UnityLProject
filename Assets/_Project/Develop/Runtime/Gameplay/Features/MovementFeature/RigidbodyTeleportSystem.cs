using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyTeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _teleportRadius;
        private Rigidbody               _rigidbody;

        private ICompositeCondition _canMove;
        private ReactiveEvent       _teleportRequest;
        private ReactiveEvent       _teleportPlannedEvent;

        private IDisposable _onTeleportRequestSubscription;

        public void OnInit(Entity entity)
        {
            _teleportRadius = entity.TeleportRadius;
            _teleportRequest = entity.TeleportRequest;
            _rigidbody = entity.Rigidbody;
            _canMove = entity.CanMove;
            _teleportPlannedEvent = entity.TeleportPlannedEvent;

            _onTeleportRequestSubscription = _teleportRequest.Subscribe(OnTeleportRequest);
        }

        public void OnDispose()
        {
            _onTeleportRequestSubscription.Dispose();
        }

        private void OnTeleportRequest()
        {
            if (_canMove.Evaluate() == false)
                return;

            // Vector2 randomPoint = Random.insideUnitCircle * _teleportRadius.Value;
            // _rigidbody.position += new Vector3(randomPoint.x, 0, randomPoint.y);

            _rigidbody.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));

            _teleportPlannedEvent?.Invoke();
        }
    }
}