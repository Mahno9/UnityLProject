using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.MainMenu;
using _Project.Develop.Runtime.Utilities.AssetManagement;
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
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPopupService);

            container.Initialize();
        }

        private static MenuGameplayCycle CreateGameplayCycle(DIContainer c)
            => new(c);

        private static MarketService CreateMarketService(DIContainer c)
            => new(c.Resolve<WalletService>(), c.Resolve<ConfigsProviderService>().GetConfig<MarketConfig>(), c.Resolve<ProductItemsFactory>());

        private static ProductItemsFactory CreateProductItemsFactory(DIContainer c)
            => new(c);

        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            MainMenuUIRoot rootPrefab = c.Resolve<ResourcesAssetsLoader>().Load<MainMenuUIRoot>(R.UI.MainMenu.MainMenuUIRoot);
            return Object.Instantiate(rootPrefab);
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer c)
            => new(c);

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer c)
        {
            MainMenuUIRoot     uiRoot       = c.Resolve<MainMenuUIRoot>();
            MainMenuScreenView mainMenuView = c.Resolve<ViewsFactory>().Create<MainMenuScreenView>(ViewIDs.MainMenuScreen, uiRoot.HUDLayer);

            return c.Resolve<MainMenuPresentersFactory>().CreateMainMenuScreen(mainMenuView);
        }

        private static MainMenuPopupService CreateMainMenuPopupService(DIContainer c)
        {
            return new MainMenuPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<MainMenuUIRoot>()
            );
        }
    }
}