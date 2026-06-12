using System;

using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Statistic
{
    [CreateAssetMenu(menuName = "Configs/Meta/Statistic/NewMetricsIconsConfig", fileName = "MetricsIconsConfig")]
    public class MetricsIconsConfig : ScriptableObject
    {
        [SerializeField] private Sprite _winSprite;
        [SerializeField] private Sprite _loseSprite;

        public Sprite GetSprite(StatisticMetricType type) => type switch
        {
            StatisticMetricType.Win  => _winSprite,
            StatisticMetricType.Lose => _loseSprite,
            _                        => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}