using _Project.Develop.Runtime.Configs.Meta.Progression;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Features.GameStateManagement.GameStates;
using _Project.Develop.Runtime.Gameplay.Features.KeyInputManagement;
using _Project.Develop.Runtime.Gameplay.Features.StringMatchingManagement;
using _Project.Develop.Runtime.Gameplay.Features.TypingInputManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.UI.Gameplay;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Gameplay.Features.GameStateManagement
{
    public class GameStateFactory
    {
        private readonly DIContainer _container;

        public GameStateFactory(DIContainer container)
        {
            _container = container;
        }

        public TypingGameState CreateTypingGameState()
        {
            return new TypingGameState(
                _container.Resolve<GameStateService>(),
                _container.Resolve<TypingInputService>(),
                _container.Resolve<StringMatcherService>()
            );
        }

        public WinGameState CreateWinGameState()
        {
            return new WinGameState(
                _container.Resolve<StatisticService>(),
                _container.Resolve<WaitForKeyService>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<ProgressionConfig>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<LevelScreenPresenter>().GetPresenter<LevelInterfacePresenter>()
            );
        }

        public LoseGameState CreateLoseGameState()
        {
            return new LoseGameState(
                _container.Resolve<StatisticService>(),
                _container.Resolve<WaitForKeyService>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<ProgressionConfig>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<LevelScreenPresenter>().GetPresenter<LevelInterfacePresenter>()
            );
        }
    }
}