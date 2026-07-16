using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;

namespace _Project.Develop.Runtime.Gameplay.Features.GunFeature
{
    public class GunTransformRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddGunTransform(transform);
        }
    }
}