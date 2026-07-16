using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    [RequireComponent(typeof(Animator))]
    public class DeadView : EntityView
    {
        [SerializeField] private Animator _animator;

        private readonly int _deathAnimationKey = Animator.StringToHash("IsDead");

        private IDisposable _isDeadChangedSubscription;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isDeadChangedSubscription = entity.IsDead.Subscribe(OnDeadChanged);
            UpdateIsDead(entity.IsDead.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isDeadChangedSubscription.Dispose();
        }

        private void OnDeadChanged(bool _, bool isDead) => UpdateIsDead(isDead);

        private void UpdateIsDead(bool isDead) => _animator.SetBool(_deathAnimationKey, isDead);
    }
}