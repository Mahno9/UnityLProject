using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.TeamsFeature
{
    public class Team : IEntityComponent
    {
        public ReactiveVariable<Teams> Value;
    }
}