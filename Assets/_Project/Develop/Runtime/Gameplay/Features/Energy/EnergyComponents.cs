using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class Energy : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class InitialEnergy : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class EnergyRegenerateCooldown : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class RestTimeToEnergyRegenerate : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}