using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.Shoot
{
    public class AreaDamageColliderRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Collider _collider;

        public override void Register(Entity entity)
        {
            entity.AddAreaAttackCollider(_collider);
        }
    }
}
