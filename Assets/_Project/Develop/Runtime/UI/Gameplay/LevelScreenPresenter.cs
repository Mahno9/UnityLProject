using System;
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
            CreateLevelInterface();

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

        private void CreateLevelInterface()
        {
            LevelInterfacePresenter levelInterfacePresenter = _gameplayPresentersFactory.CreateLevelInterfacePresenter(_screen.LevelInterfaceView);

            _childPresenters.Add(levelInterfacePresenter);
        }

        public T GetPresenter<T>() where T : IPresenter
        {
            foreach (IPresenter childPresenter in _childPresenters)
                if (childPresenter is T presenter)
                    return presenter;

            throw new ArgumentException($"Unable to find presenter of type {typeof(T)} on current screen");
        }
    }
}