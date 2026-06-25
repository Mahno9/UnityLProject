using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Rewards
{
    [CreateAssetMenu(menuName = "Configs/Meta/Rewards/NewGoldRewardConfig", fileName = "GoldRewardConfig")]
    public class GoldRewardConfig : RewardConfig
    {
        [field: SerializeField, Min(0)] public int Amount { get; private set; }
    }
}
