using System;

using _Project.Develop.Runtime.Configs.Meta.Rewards;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.RewardManagement.Rewards;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;

namespace _Project.Develop.Runtime.Meta.Logic.RewardManagement
{
    // Маппит конфиг награды в исполняемую награду. Новый тип награды = новый
    // RewardConfig-наследник + IReward + ветка switch (как StagesFactory.Create).
    public class RewardFactory
    {
        private readonly DIContainer _container;

        public RewardFactory(DIContainer container)
        {
            _container = container;
        }

        public IReward Create(RewardConfig config)
        {
            switch (config)
            {
                case GoldRewardConfig gold:
                    return new GoldReward(gold.Amount, _container.Resolve<WalletService>());

                default:
                    throw new ArgumentException($"Not supported {config.GetType()} reward config");
            }
        }
    }
}
