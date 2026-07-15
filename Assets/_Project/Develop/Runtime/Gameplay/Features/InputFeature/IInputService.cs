using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public interface IInputService : IUpdatableService
    {
        bool IsEnabled { get; set; }

        Vector3 Direction { get; }

        Vector3 RotationDelta { get; }

        ReactiveEvent FireEvent { get; }
    }
}