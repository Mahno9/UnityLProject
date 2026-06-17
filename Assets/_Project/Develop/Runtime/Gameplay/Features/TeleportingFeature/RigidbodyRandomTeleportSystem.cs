using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyRandomTeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _teleportRadius;
        private Rigidbody               _rigidbody;

        private ICompositeCondition _canMove;
        private ReactiveEvent       _randomTeleportRequest;
        private ReactiveEvent       _teleportPlannedEvent;

        private IDisposable _onRandomTeleportRequestSubscription;

        public void OnInit(Entity entity)
        {
            _teleportRadius = entity.TeleportRadius;
            _randomTeleportRequest = entity.RandomTeleportRequest;
            _rigidbody = entity.Rigidbody;
            _canMove = entity.CanMove;
            _teleportPlannedEvent = entity.TeleportPlannedEvent;

            _onRandomTeleportRequestSubscription = _randomTeleportRequest.Subscribe(OnRandomTeleportRequest);
        }

        public void OnDispose()
        {
            _onRandomTeleportRequestSubscription.Dispose();
        }

        private void OnRandomTeleportRequest()
        {
            if (_canMove.Evaluate() == false)
                return;

            Vector2 randomPoint = Random.insideUnitCircle * _teleportRadius.Value;
            _rigidbody.position += new Vector3(randomPoint.x, 0, randomPoint.y);

            // _rigidbody.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));

            _teleportPlannedEvent?.Invoke();
        }
    }
}