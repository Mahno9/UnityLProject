using System;

using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using TMPro;

using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.TowerDefense
{
    // Кнопка HUD: подготовка — "Начать волну", бой — скрыта, победа/поражение — "Перейти в меню".
    // Режим выводим строго из текущей фазы боя (TowerDefensePhaseService), без дублирования
    // условий переходов стейт-машины.
    public class StartButtonPresenter : IPresenter
    {
        private const string START_WAVE_TEXT   = "Начать волну";
        private const string EXIT_TO_MENU_TEXT = "Перейти в меню";

        private readonly Button                   _button;
        private readonly TMP_Text                 _label;
        private readonly TowerDefensePhaseService _phaseService;
        private readonly StartBattleService       _startBattleService;
        private readonly SceneSwitcherService     _sceneSwitcherService;
        private readonly ICoroutinesPerformer     _coroutinesPerformer;

        private IDisposable _phaseSubscription;

        private ButtonMode _mode;

        public StartButtonPresenter(
            Button button,
            TMP_Text label,
            TowerDefensePhaseService phaseService,
            StartBattleService startBattleService,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _button = button;
            _label = label;
            _phaseService = phaseService;
            _startBattleService = startBattleService;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(OnClicked);

            _phaseSubscription = _phaseService.Current.Subscribe(OnPhaseChanged);

            UpdateButton();
        }

        public void Dispose()
        {
            _button.onClick.RemoveListener(OnClicked);

            _phaseSubscription.Dispose();
        }

        private void OnPhaseChanged(TowerDefensePhase oldPhase, TowerDefensePhase newPhase) => UpdateButton();

        private void UpdateButton()
        {
            _mode = ResolveMode(_phaseService.Current.Value);

            if (_mode == ButtonMode.Hidden)
            {
                _button.gameObject.SetActive(false);

                return;
            }

            _button.gameObject.SetActive(true);
            _label.SetText(_mode == ButtonMode.ExitToMenu ? EXIT_TO_MENU_TEXT : START_WAVE_TEXT);
        }

        private ButtonMode ResolveMode(TowerDefensePhase phase)
        {
            switch (phase)
            {
                case TowerDefensePhase.Combat:
                    return ButtonMode.Hidden;

                case TowerDefensePhase.Victory:
                case TowerDefensePhase.Defeat:
                    return ButtonMode.ExitToMenu;

                default:
                    return ButtonMode.StartWave;
            }
        }

        private void OnClicked()
        {
            if (_mode == ButtonMode.StartWave)
                _startBattleService.Request();
            else if (_mode == ButtonMode.ExitToMenu)
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu));
        }
    }
}
