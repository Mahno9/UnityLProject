using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Wallet;
using System.Collections.Generic;

using _Project.Develop.Runtime.UI.Statistic;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screen;

        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly MainMenuPopupService _popupService;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService popupService)
        {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
        }

        public void Initialize()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;

            CreateStatistic();
            CreateWallet();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OnOpenLevelsMenuButtonClicked;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screen.WalletView);

            _childPresenters.Add(walletPresenter);
        }

        private void CreateStatistic()
        {
            StatisticPresenter statisticPresenter = _projectPresentersFactory.CreateStatisticPresenter(_screen.StatisticView);

            _childPresenters.Add(statisticPresenter);
        }

        private void OnOpenLevelsMenuButtonClicked()
        {
            // _popupService.OpenLevelsMenuPopup();
        }
    }
}
