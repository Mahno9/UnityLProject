using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace _Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    // Отслеживает одну сущность любого типа: подписка на смерть (Died),
    // здоровье (Health) и выдача самой сущности (Tracked).
    public class EntityTrackingService
    {
        private readonly ReactiveEvent _died = new();

        private Entity _entity;

        private IDisposable _deathSubscription;

        public IReadOnlyEvent Died => _died;

        public IReadOnlyVariable<float> Health { get; private set; }

        public Entity Tracked => _entity;

        public bool IsDead => _entity != null && _entity.IsDead.Value;

        public void Track(Entity entity)
        {
            _entity = entity;
            Health = entity.CurrentHealth;

            _deathSubscription = entity.IsDead.Subscribe((oldValue, isDead) =>
            {
                if (isDead)
                    _died.Invoke();
            });
        }
    }
}
