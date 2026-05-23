using System;

using _Project.Develop.Runtime.Configs.Meta.Statistic;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.UI.Statistic
{
    public class MetricPresenter : IPresenter
    {
        private readonly IReadOnlyVariable<int> _statValue;
        private readonly Sprite                 _icon;
        private readonly IconTextView           _view;

        private IDisposable _subscription;

        public MetricPresenter(
            IReadOnlyVariable<int> statValue,
            Sprite                 icon,
            IconTextView           view)
        {
            _statValue = statValue;
            _icon = icon;
            _view = view;
        }

        public IconTextView View => _view;

        public void Initialize()
        {
            UpdateValue(_statValue.Value);
            _view.SetIcon(_icon);

            _subscription = _statValue.Subscribe(OnMetricChanged);
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }

        private void OnMetricChanged(int _, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetText(value.ToString());
    }
}