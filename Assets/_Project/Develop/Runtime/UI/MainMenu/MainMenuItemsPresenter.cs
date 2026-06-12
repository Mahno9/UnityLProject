using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Meta.Logic.LevelStartManagement;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuItemsPresenter : IPresenter
    {
        private readonly MainMenuItemsView   _view;
        private readonly LevelStarterService _levelStarter;
        private readonly MarketService       _marketService;

        public MainMenuItemsPresenter(MainMenuItemsView view, LevelStarterService levelStarter, MarketService marketService)
        {
            _view = view;
            _levelStarter = levelStarter;
            _marketService = marketService;
        }

        public void Initialize()
        {
            _view.StartLettersGameClicked += OnStartLettersGameClicked;
            _view.StartNumbersGameClicked += OnStartNumbersGameClicked;
            _view.ResetStatisticClicked += OnResetStatisticClicked;

            _view.SetResetPrice(_marketService.GetPrice(ProductName.StatisticReset));
        }

        public void Dispose()
        {
            _view.StartLettersGameClicked -= OnStartLettersGameClicked;
            _view.StartNumbersGameClicked -= OnStartNumbersGameClicked;
            _view.ResetStatisticClicked -= OnResetStatisticClicked;
        }

        private void OnStartLettersGameClicked()
            => _levelStarter.StartLevel(StringGeneratorType.RandomLetters);

        private void OnStartNumbersGameClicked()
            => _levelStarter.StartLevel(StringGeneratorType.RandomNumbers);

        private void OnResetStatisticClicked()
            => _marketService.TryBuy(ProductName.StatisticReset);
    }
}