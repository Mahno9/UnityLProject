using System;

using _Project.Develop.Runtime.Configs.Meta.Progression;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Logic.KeyInputManagement;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.UI.Level;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic.GameStateManagement
{
    public class LoseGameState : IGameState
    {
        private readonly StatisticService        _statisticService;
        private readonly WaitForKeyService       _waitForKeyService;
        private readonly WalletService           _walletService;
        private readonly ProgressionConfig       _progressionConfig;
        private readonly SceneSwitcherService    _sceneSwitcherService;
        private readonly ICoroutinesPerformer    _coroutinesPerformer;
        private readonly PlayerDataProvider      _playerDataProvider;
        private readonly LevelInterfacePresenter _levelInterfacePresenter;

        public LoseGameState(
            StatisticService        statisticService,
            WaitForKeyService       waitForKeyService,
            WalletService           walletService,
            ProgressionConfig       progressionConfig,
            SceneSwitcherService    sceneSwitcherService,
            ICoroutinesPerformer    coroutinesPerformer,
            PlayerDataProvider      playerDataProvider,
            LevelInterfacePresenter levelInterfacePresenter
        )
        {
            _statisticService = statisticService;
            _waitForKeyService = waitForKeyService;
            _walletService = walletService;
            _progressionConfig = progressionConfig;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _playerDataProvider = playerDataProvider;
            _levelInterfacePresenter = levelInterfacePresenter;
        }

        public void OnEnter()
        {
            _statisticService.RegisterLose();

            int lossFine  = _progressionConfig.GetLoseGoldFine();
            int spendFine = (int)MathF.Min(_walletService.GetGold().Value, lossFine);
            _walletService.SpendGold(spendFine);

            SaveProgress();

            _levelInterfacePresenter.ShowResult(false);
            _waitForKeyService.ListenForKeyCodeOnce(KeyCode.Space, RestartLevel);
        }

        public void OnExit()
        {
        }

        public void Update()
        {
        }

        private void RestartLevel()
            => _sceneSwitcherService.SwitchToScene(S._Project.Scenes.Level);

        private void SaveProgress()
            => _coroutinesPerformer.StartPerform(
                _playerDataProvider.Save()
            );
    }
}