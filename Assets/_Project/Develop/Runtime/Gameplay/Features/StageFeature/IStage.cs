using _Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace _Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    public interface IStage : IDisposable
    {
        IReadOnlyEvent Completed { get; }

        void Start();
        void Update(float deltaTime);
        void Cleanup();
    }
}
