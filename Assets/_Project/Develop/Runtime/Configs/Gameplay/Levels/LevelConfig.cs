using _Project.Develop.Runtime.Configs.Gameplay.Stages;
using _Project.Develop.Runtime.Configs.Meta.Rewards;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<StageConfig> _stageConfigs;

        [field: SerializeField, Min(0)] public float TowerMaxHealth { get; private set; } = 300;
        [field: SerializeField] public RewardConfig WinReward { get; private set; }
        [field: SerializeField, Min(0)] public float EnemySpawnRadius { get; private set; } = 10;

        public IReadOnlyList<StageConfig> StageConfigs => _stageConfigs;
    }
}
