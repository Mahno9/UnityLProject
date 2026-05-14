using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public static class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Процесс регистрации сервисов на сцене меню");

            container.RegisterAsSingle(CreateGameplayCycle);
            container.RegisterAsSingle(CreateMarketService);
            container.RegisterAsSingle(CreateProductItemsFactory);

            container.Initialize();
        }

        private static MenuGameplayCycle CreateGameplayCycle(DIContainer c)
            => new(c);

        private static MarketService CreateMarketService(DIContainer c)
            => new(c.Resolve<WalletService>(), c.Resolve<ConfigsProviderService>().GetConfig<MarketConfig>(), c.Resolve<ProductItemsFactory>());

        private static ProductItemsFactory CreateProductItemsFactory(DIContainer c)
            => new(c);
    }
}