using System;

using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Configs.Gameplay.Stages;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.TowerDefense
{
    // Во время боя показывает, сколько врагов осталось зачистить на весь стейдж (по всем волнам),
    // а не на текущую волну. Видимость привязана к фазе боя (Combat).
    public class EnemyCountPresenter : IPresenter
    {
        private readonly IconTextView             _view;
        private readonly WaveEnemyCounterService  _waveEnemyCounter;
        private readonly StageProviderService     _stageProviderService;
        private readonly LevelConfig              _levelConfig;
        private readonly ITowerDefencePhaseReader _phaseService;

        private IDisposable _killedSubscription;
        private IDisposable _stageNumberSubscription;
        private IDisposable _phaseSubscription;

        private int _stageTotal;
        private int _stageKilled;

        public EnemyCountPresenter(
            IconTextView view,
            WaveEnemyCounterService waveEnemyCounter,
            StageProviderService stageProviderService,
            LevelConfig levelConfig,
            ITowerDefencePhaseReader phaseService)
        {
            _view = view;
            _waveEnemyCounter = waveEnemyCounter;
            _stageProviderService = stageProviderService;
            _levelConfig = levelConfig;
            _phaseService = phaseService;
        }

        public void Initialize()
        {
            _stageTotal = ResolveStageEnemyCount();

            _killedSubscription = _waveEnemyCounter.Killed.Subscribe(OnKilledChanged);
            _stageNumberSubscription = _stageProviderService.CurrentStageNumber.Subscribe(OnStageChanged);
            _phaseSubscription = _phaseService.Current.Subscribe(OnPhaseChanged);

            UpdateText();
            UpdateVisibility();
        }

        public void Dispose()
        {
            _killedSubscription.Dispose();
            _stageNumberSubscription.Dispose();
            _phaseSubscription.Dispose();
        }

        private void OnKilledChanged(int oldValue, int newValue)
        {
            // Clear() сбрасывает счётчик волны в 0 — это не убийство, копим только прирост.
            if (newValue > oldValue)
                _stageKilled += newValue - oldValue;

            UpdateText();
        }

        private void OnStageChanged(int oldValue, int newValue)
        {
            _stageKilled = 0;
            _stageTotal = ResolveStageEnemyCount();

            UpdateText();
        }

        private void OnPhaseChanged(TowerDefensePhase oldPhase, TowerDefensePhase newPhase) => UpdateVisibility();

        private void UpdateText()
        {
            int remaining = _stageTotal - _stageKilled;

            _view.SetText(remaining.ToString());
        }

        private void UpdateVisibility()
            => _view.gameObject.SetActive(_phaseService.Current.Value == TowerDefensePhase.Combat);

        private int ResolveStageEnemyCount()
        {
            int stageNumber = _stageProviderService.CurrentStageNumber.Value;

            if (stageNumber < 1)
                return 0;

            return CountEnemies(_levelConfig.StageConfigs[stageNumber - 1]);
        }

        private int CountEnemies(StageConfig stage)
        {
            switch (stage)
            {
                case ClearAllWavesStageConfig waves:
                    int total = 0;

                    foreach (WaveConfig wave in waves.Waves)
                        total += wave.TotalCount;

                    return total;

                case ClearAllEnemiesStageConfig enemies:
                    return enemies.EnemyItems.Count;

                default:
                    return 0;
            }
        }
    }
}
