using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class SpendEnergySystem : IInitializableSystem, IDisposableSystem
    {
        private readonly int                   _cost;
        private readonly ReactiveEvent         _event;
        private          ReactiveVariable<int> _energy;
        private          IDisposable           _eventSubscription;

        public SpendEnergySystem(int cost, ReactiveEvent @event)
        {
            _cost = cost;
            _event = @event;
        }

        public void OnInit(Entity entity)
        {
            _energy = entity.Energy;

            _eventSubscription = _event.Subscribe(OnEventHappened);
        }

        public void OnDispose()
        {
            _eventSubscription.Dispose();
        }

        private void OnEventHappened()
        {
            _energy.Value = (int)MathF.Max(0, _energy.Value - _cost);

            Debug.Log($"Потрачено {_cost} энергии. Осталось: {_energy.Value}");
        }
    }
}