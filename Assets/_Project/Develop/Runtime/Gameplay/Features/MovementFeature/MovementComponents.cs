using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class MoveDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class IsMoving : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class TeleportRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanMove : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class CanRotate : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class TeleportRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class OnTeleportEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class PreviousBodyPosition : IEntityComponent
    {
        public Vector3 Value;
    }
}
