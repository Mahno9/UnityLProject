using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.LevelStartManagement;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreen(MainMenuScreenView view)
        {
            return new MainMenuScreenPresenter(
                view,
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


        // public MainMenuItemsPresenter CreateMainMenuItems()
        // {
        //     return new MainMenuItemsPresenter(
        //         )
        // }
    }
}