using _Project.Develop.Runtime.Configs.Meta.Statistic;
using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.DataManagement.SaveLoadManagement;

namespace _Project.Develop.Runtime.Data.PlayerData
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProviderService _configsProviderService;

        public PlayerDataProvider(
            ISaveLoadService saveLoadService,
            ConfigsProviderService configsProviderService) : base(saveLoadService)
        {
            _configsProviderService = configsProviderService;
        }

        protected override PlayerData GetOriginData()
        {
            StartWalletConfig walletConfig = _configsProviderService.GetConfig<StartWalletConfig>();
            StartStatisticConfig statisticConfig = _configsProviderService.GetConfig<StartStatisticConfig>();

            return new PlayerData()
            {
                Gold = walletConfig.GetGold(),
                Wins = statisticConfig.GetWins(),
                Loses = statisticConfig.GetLoses(),
            };
        }
    }
}
