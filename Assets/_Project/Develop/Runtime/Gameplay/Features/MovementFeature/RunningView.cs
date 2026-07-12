using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    [RequireComponent(typeof(Animator))]
    public class RunningView : EntityView
    {
        private readonly int IsRunningKey = Animator.StringToHash("IsRunning");

        [SerializeField] private Animator _animator;

        private IReadOnlyVariable<bool> _isMoving;

        private IDisposable _isMovingChangedSubscription;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isMoving = entity.IsMoving;

            _isMovingChangedSubscription = _isMoving.Subscribe(OnIsMovingChanged);
            UpdateIsMoving(_isMoving.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isMovingChangedSubscription.Dispose();
        }

        private void OnIsMovingChanged(bool oldIsMoving, bool isMoving) => UpdateIsMoving(isMoving);

        private void UpdateIsMoving(bool value) => _animator.SetBool(IsRunningKey, value);
    }
}
