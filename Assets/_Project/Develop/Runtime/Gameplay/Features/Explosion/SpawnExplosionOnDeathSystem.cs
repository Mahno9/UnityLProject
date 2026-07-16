using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Explosion
{
    public class SpawnExplosionOnDeathSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly ExplosionFactory _explosionFactory;
        private readonly float            _damage;
        private readonly Func<bool>       _shouldSpawn;

        private ReactiveVariable<bool>  _isDead;
        private ReactiveVariable<Teams> _team;
        private Transform               _transform;

        private IDisposable _isDeadSubscription;

        public SpawnExplosionOnDeathSystem(
            ExplosionFactory explosionFactory,
            float damage,
            Func<bool> shouldSpawn)
        {
            _explosionFactory = explosionFactory;
            _damage = damage;
            _shouldSpawn = shouldSpawn;
        }

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _team = entity.Team;
            _transform = entity.Transform;

            _isDeadSubscription = _isDead.Subscribe(OnIsDeadChanged);
        }

        public void OnDispose()
        {
            _isDeadSubscription.Dispose();
        }

        private void OnIsDeadChanged(bool oldValue, bool isDead)
        {
            if (isDead == false)
                return;

            if (_shouldSpawn() == false)
                return;

            if (_team.Value == Teams.Enemies)
                _explosionFactory.CreateEnemyExplosion(_transform.position, _damage, _team.Value);
            else
                _explosionFactory.CreatePlayerExplosion(_transform.position, _damage, _team.Value);
        }
    }
}
