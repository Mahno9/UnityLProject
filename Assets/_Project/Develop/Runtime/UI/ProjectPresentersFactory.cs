using _Project.Develop.Runtime.Configs.Meta.Statistic;
using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Core.TestPopup;
using _Project.Develop.Runtime.UI.Statistic;
using _Project.Develop.Runtime.UI.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.Reactive;

using Assets._Project.Develop.Runtime.UI.CommonViews;

using UnityEngine;

namespace _Project.Develop.Runtime.UI
{
    public class ProjectPresentersFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MetricPresenter CreateMetricPresenter(IReadOnlyVariable<int> metricVariable, Sprite metricIcon, IconTextView view)
        {
            return new MetricPresenter(metricVariable, metricIcon, view);
        }

        public StatisticPresenter CreateStatisticPresenter(IconTextListView view)
        {
            return new StatisticPresenter(
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<MetricsIconsConfig>(),
                _container.Resolve<StatisticService>(),
                _container.Resolve<ViewsFactory>(),
                view
            );
        }

        public WalletPresenter CreateWalletPresenter(IconTextView view)
        {
            return new WalletPresenter(
                _container.Resolve<WalletService>().GetGold(),
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(),
                view);
        }

        public TestPopupPresenter CreateTestPopupPresenter(TestPopupView view)
        {
            return new TestPopupPresenter(
                view,
                _container.Resolve<ICoroutinesPerformer>());
        }
    }
}