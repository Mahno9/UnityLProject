using System;
using System.Collections.Generic;

using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.Statistic
{
    public class StatisticPresenter : IPresenter
    {
        private readonly ProjectPresentersFactory _presentersFactory;
        private readonly ViewsFactory             _viewsFactory;
        private readonly IconTextListView         _view;

        private readonly List<MetricPresenter> _presenters = new();

        public StatisticPresenter(
            ProjectPresentersFactory presentersFactory,
            ViewsFactory             viewsFactory,
            IconTextListView         view)
        {
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            foreach (StatisticMetricType metricType in Enum.GetValues(typeof(StatisticMetricType)))
            {
                IconTextView view = _viewsFactory.Create<IconTextView>(ViewIDs.MetricView);
                _view.Add(view);
                MetricPresenter presenter = _presentersFactory.CreateMetricPresenter(metricType, view);
                presenter.Initialize();
                _presenters.Add(presenter);
            }
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
