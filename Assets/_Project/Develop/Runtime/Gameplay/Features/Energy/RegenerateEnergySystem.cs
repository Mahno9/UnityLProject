using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class RegenerateEnergySystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<int>   _energy;
        private ReactiveVariable<float> _regenerateCooldown;
        private ReactiveVariable<float> _timeTilRegeneration;
        private ReactiveVariable<int>   _initialEnergy;

        public void OnInit(Entity entity)
        {
            _energy = entity.Energy;
            _initialEnergy = entity.InitialEnergy;
            _regenerateCooldown = entity.EnergyRegenerateCooldown;
            _timeTilRegeneration = entity.RestTimeToEnergyRegenerate;

            _energy.Subscribe(LogEnergyRegen);
        }

        public void OnUpdate(float deltaTime)
        {
            _timeTilRegeneration.Value -= deltaTime;

            if (_timeTilRegeneration.Value <= 0)
            {
                float energyToRegenerate = _initialEnergy.Value * 0.1f;
                _energy.Value = (int)MathF.Min(_initialEnergy.Value, _energy.Value + energyToRegenerate);
                _timeTilRegeneration.Value = _regenerateCooldown.Value;
            }
        }

        private void LogEnergyRegen(int _, int newEnergyValue)
        {
            Debug.Log($"Energy new value: {newEnergyValue}");
        }
    }
}