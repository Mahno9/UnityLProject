using System;

using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.TowerDefense
{
    public class HealthPresenter : IPresenter
    {
        private readonly IconTextView          _view;
        private readonly EntityTrackingService _towerTracking;

        private IDisposable _subscription;

        public HealthPresenter(IconTextView view, EntityTrackingService towerTracking)
        {
            _view = view;
            _towerTracking = towerTracking;
        }

        public void Initialize()
        {
            UpdateText(_towerTracking.Health.Value);

            _subscription = _towerTracking.Health.Subscribe(OnHealthChanged);
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }

        private void OnHealthChanged(float oldValue, float newValue) => UpdateText(newValue);

        private void UpdateText(float health) => _view.SetText(health.ToString("F0"));
    }
}
