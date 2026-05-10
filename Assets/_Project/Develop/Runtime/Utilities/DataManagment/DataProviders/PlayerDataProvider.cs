using _Project.Develop.Runtime.Utilities.ConfigsManagement;

using Assets._Project.Develop.Runtime.Meta.Features.Wallet;

using LProject.Assets._Project.Develop.Runtime.Configs.Meta.Wallet;

using System.Collections.Generic;

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
            return new PlayerData()
            {
                WalletData = InitWalletData(),
            };
        }

        private Dictionary<CurrencyTypes, int> InitWalletData()
        {
            Dictionary<CurrencyTypes, int> walletData = new();

            StartWalletConfig walletConfig = _configsProviderService.GetConfig<StartWalletConfig>();

			// TODO rewrite this
            // foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
            //     walletData[currencyType] = walletConfig.GetValueFor(currencyType);

            return walletData;
        }
    }
}
