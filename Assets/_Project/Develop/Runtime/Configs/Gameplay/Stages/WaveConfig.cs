using _Project.Develop.Runtime.Configs.Gameplay.Entities;
using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Stages
{
    [Serializable]
    public class WaveConfig
    {
        [field: SerializeField] public EntityConfig EnemyConfig { get; private set; }
        [field: SerializeField, Min(0)] public int TotalCount { get; private set; } = 5;
        [field: SerializeField, Min(1)] public int MaxAliveAtOnce { get; private set; } = 5;
    }
}
