using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Progression
{
    [CreateAssetMenu(menuName = "Configs/Meta/Progression/ProgressionConfig", fileName = "ProgressionConfig")]
    public class ProgressionConfig : ScriptableObject
    {
        [SerializeField] private int _winGoldReward;

        [SerializeField] private int _loseGoldFine;

        public int GetWinGoldReward()
        {
            return _winGoldReward;
        }

        public int GetLoseGoldFine()
        {
            return _loseGoldFine;
        }
    }
}