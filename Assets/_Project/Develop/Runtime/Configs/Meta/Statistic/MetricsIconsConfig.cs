using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Statistic
{
    [CreateAssetMenu(menuName = "Configs/Meta/Statistic/NewMetricsIconsConfig", fileName = "MetricsIconsConfig")]
    public class MetricsIconsConfig : ScriptableObject
    {
        [SerializeField] private Sprite _winSprite;
        [SerializeField] private Sprite _loseSprite;

        public Sprite WinSprite => _winSprite;
        public Sprite LoseSprite => _loseSprite;
    }
}