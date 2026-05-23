using System.Collections.Generic;

using _Project.Develop.Runtime.Configs.Meta.Statistic;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

using Assets._Project.Develop.Runtime.UI.CommonViews;

namespace _Project.Develop.Runtime.UI.Statistic
{
    public class StatisticPresenter : IPresenter
    {
        private readonly ProjectPresentersFactory _presentersFactory;
        private readonly MetricsIconsConfig       _iconsConfig;
        private readonly StatisticService         _statisticService;
        private readonly ViewsFactory             _viewsFactory;
        private readonly IconTextListView         _view;

        private readonly List<MetricPresenter> _presenters = new();

        public StatisticPresenter(
            ProjectPresentersFactory presentersFactory,
            MetricsIconsConfig       iconsConfig,
            StatisticService         statisticService,
            ViewsFactory             viewsFactory,
            IconTextListView         view)
        {
            _presentersFactory = presentersFactory;
            _iconsConfig = iconsConfig;
            _statisticService = statisticService;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            IconTextView winsView = _viewsFactory.Create<IconTextView>(ViewIDs.MetricView);
            _view.Add(winsView);
            MetricPresenter winsPresenter = _presentersFactory.CreateMetricPresenter(
                _statisticService.GetWins(),
                _iconsConfig.WinSprite,
                winsView
            );
            winsPresenter.Initialize();
            _presenters.Add(winsPresenter);

            IconTextView losesView = _viewsFactory.Create<IconTextView>(ViewIDs.MetricView);
            _view.Add(losesView);
            MetricPresenter losesPresenter = _presentersFactory.CreateMetricPresenter(
                _statisticService.GetLoses(),
                _iconsConfig.LoseSprite,
                losesView
            );
            losesPresenter.Initialize();
            _presenters.Add(losesPresenter);
        }

        public void Dispose()
        {
            foreach (MetricPresenter metricPresenter in _presenters)
            {
                _view.Remove(metricPresenter.View);
                _viewsFactory.Release(metricPresenter.View);
                metricPresenter.Dispose();
            }

            _presenters.Clear();
        }
    }
}