using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Wallet;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using TMPro;

using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.TowerDefense
{
    public class TowerDefensePresentersFactory
    {
        private readonly DIContainer _container;

        public TowerDefensePresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public WalletPresenter CreateWalletPresenter(IconTextView view)
            => _container.Resolve<ProjectPresentersFactory>().CreateWalletPresenter(view);

        public WavePresenter CreateWavePresenter(IconTextView view)
            => new WavePresenter(view, _container.Resolve<StageProviderService>());

        public HealthPresenter CreateHealthPresenter(IconTextView view)
            => new HealthPresenter(view, _container.Resolve<EntityTrackingService>());

        public EnemyCountPresenter CreateEnemyCountPresenter(IconTextView view)
            => new EnemyCountPresenter(
                view,
                _container.Resolve<WaveEnemyCounterService>(),
                _container.Resolve<StageProviderService>(),
                _container.Resolve<LevelConfig>(),
                _container.Resolve<TowerDefensePhaseService>());

        public StartButtonPresenter CreateStartButtonPresenter(Button button, TMP_Text label)
            => new StartButtonPresenter(
                button,
                label,
                _container.Resolve<TowerDefensePhaseService>(),
                _container.Resolve<StartBattleService>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
    }
}
