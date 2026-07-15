using System.Collections.Generic;

using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.TowerDefense
{
    public class TowerDefenseScreenPresenter : IPresenter
    {
        private readonly TowerDefenseScreenView        _screen;
        private readonly TowerDefensePresentersFactory _presentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public TowerDefenseScreenPresenter(
            TowerDefenseScreenView screen,
            TowerDefensePresentersFactory presentersFactory)
        {
            _screen = screen;
            _presentersFactory = presentersFactory;
        }

        public void Initialize()
        {
            CreateChildPresenters();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateChildPresenters()
        {
            _childPresenters.Add(_presentersFactory.CreateWalletPresenter(_screen.WalletView));
            _childPresenters.Add(_presentersFactory.CreateWavePresenter(_screen.WaveView));
            _childPresenters.Add(_presentersFactory.CreateHealthPresenter(_screen.HealthView));
            _childPresenters.Add(_presentersFactory.CreateEnemyCountPresenter(_screen.EnemyCountView));
            _childPresenters.Add(_presentersFactory.CreateStartButtonPresenter(_screen.StartButton, _screen.StartButtonText));
        }
    }
}
