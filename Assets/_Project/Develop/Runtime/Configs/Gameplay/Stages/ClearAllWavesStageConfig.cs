using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Stages
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Stages/NewClearAllWavesStage", fileName = "ClearAllWavesStage")]
    public class ClearAllWavesStageConfig : StageConfig
    {
        [SerializeField] private List<WaveConfig> _waves;

        public IReadOnlyList<WaveConfig> Waves => _waves;
    }
}
