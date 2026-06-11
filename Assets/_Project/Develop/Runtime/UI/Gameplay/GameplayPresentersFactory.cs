using _Project.Develop.Runtime.Gameplay.Features.StringMatchingManagement;
using _Project.Develop.Runtime.Gameplay.Features.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public LevelScreenPresenter CreateLevelScreenPresenter()
        {
            LevelUIRoot     uiRoot          = _container.Resolve<LevelUIRoot>();
            LevelScreenView levelScreenView = _container.Resolve<ViewsFactory>().Create<LevelScreenView>(ViewIDs.LevelScreen, uiRoot.HUDLayer);

            return new LevelScreenPresenter(
                levelScreenView,
                _container.Resolve<GameplayPresentersFactory>(),
                _container.Resolve<ProjectPresentersFactory>()
            );
        }

        public LevelInterfacePresenter CreateLevelInterfacePresenter(LevelInterfaceView screenLevelInterfaceView)
        {
            return new LevelInterfacePresenter(
                screenLevelInterfaceView,
                _container.Resolve<TypingInputService>(),
                _container.Resolve<StringMatcherService>()
            );
        }
    }
}