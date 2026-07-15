using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage
{
    public class AreaTargetsSelectorSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly bool  _excludeSelf;
        private readonly float _gizmoDuration;

        private Collider         _areaCollider;
        private Collider         _selfCollider;
        private Buffer<Collider> _targets;
        private LayerMask        _mask;
        private ReactiveEvent    _collectRequest;

        private IDisposable _collectRequestSubscription;

        public AreaTargetsSelectorSystem(bool excludeSelf = true, float gizmoDuration = 1f)
        {
            _excludeSelf = excludeSelf;
            _gizmoDuration = gizmoDuration;
        }

        public void OnInit(Entity entity)
        {
            _targets = entity.TargetsCollidersBuffer;
            _mask = entity.TargetsDetectingMask;
            _areaCollider = entity.AreaAttackCollider;
            _collectRequest = entity.AreaTargetsCollectRequest;

            // Self-exclusion only matters for entities whose own non-trigger body collider can
            // appear in the overlap; detection-only entities (explosion, mine) have no body collider.
            if (entity.TryGetBodyCollider(out CapsuleCollider selfBody))
                _selfCollider = selfBody;

            _collectRequestSubscription = _collectRequest.Subscribe(OnCollectRequest);
        }

        public void OnDispose()
        {
            _collectRequestSubscription.Dispose();
        }

        private void OnCollectRequest()
        {
            _targets.Count = PhysicsUtils.OverlapCollider(_areaCollider, _targets.Items, _mask);

            if (_excludeSelf)
                RemoveSelfFromTargets();

#if UNITY_EDITOR
            DebugDrawUtils.DrawWireCollider(_areaCollider, _targets.Count > 0 ? Color.red : Color.green, _gizmoDuration);
#endif
        }

        private void RemoveSelfFromTargets()
        {
            int idx = -1;
            for (int i = 0; i < _targets.Count; i++)
            {
                if (_targets.Items[i] != _selfCollider)
                    continue;

                idx = i;
                break;
            }

            if (idx < 0)
                return;

            for (int i = idx; i < _targets.Count - 1; i++)
                _targets.Items[i] = _targets.Items[i + 1];

            _targets.Count--;
        }
    }
}