using System;

using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.TowerDefense
{
    public class WavePresenter : IPresenter
    {
        private readonly IconTextView         _view;
        private readonly StageProviderService _stageProviderService;

        private IDisposable _subscription;

        public WavePresenter(IconTextView view, StageProviderService stageProviderService)
        {
            _view = view;
            _stageProviderService = stageProviderService;
        }

        public void Initialize()
        {
            UpdateText(_stageProviderService.CurrentStageNumber.Value);

            _subscription = _stageProviderService.CurrentStageNumber.Subscribe(OnStageNumberChanged);
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }

        private void OnStageNumberChanged(int oldValue, int newValue) => UpdateText(newValue);

        private void UpdateText(int currentStage)
            => _view.SetText(currentStage + "/" + _stageProviderService.StagesCount);
    }
}
