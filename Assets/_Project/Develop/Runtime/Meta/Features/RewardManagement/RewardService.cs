using _Project.Develop.Runtime.Configs.Meta.Rewards;

namespace _Project.Develop.Runtime.Meta.Logic.RewardManagement
{
    // Обобщённая выдача наград, переиспользуемая любым режимом. Тип/величина
    // награды описываются в RewardConfig; конкретное действие — в IReward.
    public class RewardService
    {
        private readonly RewardFactory _rewardFactory;

        public RewardService(RewardFactory rewardFactory)
        {
            _rewardFactory = rewardFactory;
        }

        public void Grant(RewardConfig rewardConfig)
        {
            if (rewardConfig == null)
                return;

            _rewardFactory.Create(rewardConfig).Apply();
        }
    }
}
