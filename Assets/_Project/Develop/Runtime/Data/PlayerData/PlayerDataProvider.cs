using _Project.Develop.Runtime.Utilities.ConfigsManagement;

using LProject.Assets._Project.Develop.Runtime.Configs.Meta.Statistic;
using LProject.Assets._Project.Develop.Runtime.Configs.Meta.Wallet;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProviderService _configsProviderService;

        public PlayerDataProvider(
            ISaveLoadSerivce saveLoadSerivce,
            ConfigsProviderService configsProviderService) : base(saveLoadSerivce)
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
