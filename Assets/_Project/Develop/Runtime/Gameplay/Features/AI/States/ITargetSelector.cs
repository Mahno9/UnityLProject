using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public interface ITargetSelector
    {
        Entity SelectTargetFrom(IEnumerable<Entity> targets);
    }
}
