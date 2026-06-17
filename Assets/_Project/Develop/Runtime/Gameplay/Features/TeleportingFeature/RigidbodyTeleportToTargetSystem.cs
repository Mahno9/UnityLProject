using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyTeleportToTargetSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float>  _teleportRadius;
        private Rigidbody                _ownRigidbody;
        private ReactiveVariable<Entity> _currentTarget;

        private ICompositeCondition _canMove;
        private ICompositeCondition _canTeleportToTarget;
        private ReactiveEvent       _teleportToTargetRequest;
        private ReactiveEvent       _teleportPlannedEvent;

        private IDisposable         _teleportRequestSubscription;

        public void OnInit(Entity entity)
        {
            _teleportRadius = entity.TeleportRadius;
            _teleportToTargetRequest = entity.TeleportToTargetRequest;
            _ownRigidbody = entity.Rigidbody;
            _canMove = entity.CanMove;
            _canTeleportToTarget = entity.CanTeleportToTarget;
            _teleportPlannedEvent = entity.TeleportPlannedEvent;
            _currentTarget = entity.CurrentTarget;

            _teleportRequestSubscription = _teleportToTargetRequest.Subscribe(OnTeleportToTargetRequest);
        }

        public void OnDispose()
        {
            _teleportRequestSubscription.Dispose();
        }

        private void OnTeleportToTargetRequest()
        {
            if (_canMove.Evaluate() == false || _canTeleportToTarget.Evaluate() == false)
                return;

            Vector3 targetShift = _currentTarget.Value.Rigidbody.position - _ownRigidbody.position;
            Vector3 teleportationShift = (targetShift.magnitude > _teleportRadius.Value)
                ? targetShift.normalized * _teleportRadius.Value
                : targetShift;

            _ownRigidbody.position += teleportationShift;

            _teleportPlannedEvent?.Invoke();
        }
    }
}