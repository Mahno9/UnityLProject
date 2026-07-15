using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class TeleportRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class RandomTeleportRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class TeleportToTargetRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class TeleportPlannedEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class TeleportDoneEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class PreviousBodyPosition : IEntityComponent
    {
        public Vector3 Value;
    }

    public class TeleportEnergyCost : IEntityComponent
    {
        public int Value;
    }

    public class InitialTeleportCooldownTimer : IEntityComponent
    {
        public float Value;
    }

    public class TeleportCooldownTimer : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportCooldownDoneEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class CanTeleportToTarget : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}