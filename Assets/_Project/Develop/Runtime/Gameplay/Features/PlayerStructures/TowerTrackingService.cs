using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace _Project.Develop.Runtime.Gameplay.Features.PlayerStructures
{
    // Отслеживает башню: подписка на смерть (Died) и на количество жизней (Health).
    public class TowerTrackingService
    {
        private readonly ReactiveEvent _died = new();

        private Entity _tower;

        private IDisposable _deathSubscription;

        public IReadOnlyEvent Died => _died;

        public IReadOnlyVariable<float> Health { get; private set; }

        public bool IsTowerDead => _tower != null && _tower.IsDead.Value;

        public void Track(Entity tower)
        {
            _tower = tower;
            Health = tower.CurrentHealth;

            _deathSubscription = tower.IsDead.Subscribe((oldValue, isDead) =>
            {
                if (isDead)
                    _died.Invoke();
            });
        }
    }
}
