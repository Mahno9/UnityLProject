using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewExplosionConfig", fileName = "ExplosionConfig")]
    public class ExplosionConfig : EntityConfig
    {
        [field: SerializeField, Min(0)] public float Radius { get; private set; } = 3;
        [field: SerializeField, Min(0)] public float Lifetime { get; private set; } = 0.4f;
    }
}
