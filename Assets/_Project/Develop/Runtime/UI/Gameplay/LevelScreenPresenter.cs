using System.Collections.Generic;

using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Statistic;
using _Project.Develop.Runtime.UI.Wallet;

namespace _Project.Develop.Runtime.UI.Level
{
    public class LevelScreenPresenter : IPresenter
    {
        private readonly LevelScreenView           _screen;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly ProjectPresentersFactory  _projectPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public LevelScreenPresenter(
            LevelScreenView screen,
            GameplayPresentersFactory gameplayPresentersFactory,
            ProjectPresentersFactory projectPresentersFactory)
        {
            _screen = screen;
            _gameplayPresentersFactory = gameplayPresentersFactory;
            _projectPresentersFactory = projectPresentersFactory;
        }

        public void Initialize()
        {
            CreateStatistic();
            CreateWallet();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
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
    }
}