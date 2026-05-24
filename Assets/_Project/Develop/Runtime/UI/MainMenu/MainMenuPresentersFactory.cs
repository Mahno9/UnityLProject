using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.LevelStartManagement;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreen()
        {
            MainMenuUIRoot     uiRoot       = _container.Resolve<MainMenuUIRoot>();
            MainMenuScreenView mainMenuView = _container.Resolve<ViewsFactory>().Create<MainMenuScreenView>(ViewIDs.MainMenuScreen, uiRoot.HUDLayer);

            return new MainMenuScreenPresenter(
                mainMenuView,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<MainMenuPopupService>(),
                _container.Resolve<MainMenuPresentersFactory>()
            );
        }

        public MainMenuItemsPresenter CreateMainMenuItems(MainMenuItemsView view)
        {
            return new MainMenuItemsPresenter(
                view,
                _container.Resolve<LevelStarterService>(),
                _container.Resolve<MarketService>()
            );
        }
    }
}