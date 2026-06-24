using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

using System;

namespace _Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    // Отслеживает одну сущность любого типа: подписка на смерть (Died),
    // здоровье (Health) и выдача самой сущности (Tracked).
    // Health — собственная реактивная переменная: существует до Track (значение 0)
    // и переподключается к здоровью отслеживаемой сущности при Track.
    public class EntityTrackingService : IDisposable
    {
        public IReadOnlyEvent           Died    => _died;
        public IReadOnlyVariable<float> Health  => _health;
        public bool                     IsDead  => _entity != null && _entity.IsDead.Value;

        private readonly ReactiveEvent           _died   = new();
        private readonly ReactiveVariable<float> _health = new();

        private Entity      _entity;
        private IDisposable _deathSubscription;
        private IDisposable _healthSubscription;

        public void Dispose()
        {
            _entity?.Dispose();
            _deathSubscription?.Dispose();
            _healthSubscription?.Dispose();
        }

        public void Track(Entity entity)
        {
            _entity = entity;

            _healthSubscription?.Dispose();
            _health.Value = entity.CurrentHealth.Value;
            _healthSubscription = entity.CurrentHealth.Subscribe((oldValue, newValue) => _health.Value = newValue);

            _deathSubscription = entity.IsDead.Subscribe((oldValue, isDead) =>
            {
                if (isDead)
                    _died.Invoke();
            });
        }
    }
}