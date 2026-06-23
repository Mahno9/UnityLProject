using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewMineConfig", fileName = "MineConfig")]
    public class MineConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Mine";
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 0.1f;
        [field: SerializeField, Min(0)] public float ExplosionDamage { get; private set; } = 80;
    }
}
