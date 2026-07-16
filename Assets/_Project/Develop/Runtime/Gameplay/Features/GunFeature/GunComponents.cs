using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.GunFeature
{
    public class GunTransform : IEntityComponent
    {
        public Transform Value;
    }

    public class GunRotationDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class GunRotationSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}