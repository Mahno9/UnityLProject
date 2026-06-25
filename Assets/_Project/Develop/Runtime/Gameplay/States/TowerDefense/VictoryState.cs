using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Meta.Logic.RewardManagement;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.States.TowerDefense
{
    // Победа: все стейджи зачищены. Выход в меню — только по кнопке HUD.
    public class VictoryState : State, IUpdatableState
    {
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly TowerDefenseInputArgs    _inputArgs;
        private readonly PlayerDataProvider       _playerDataProvider;
        private readonly ICoroutinesPerformer     _coroutinesPerformer;
        private readonly RewardService            _rewardService;
        private readonly LevelConfig              _levelConfig;
        private readonly StatisticService         _statisticService;

        public VictoryState(
            LevelsProgressionService levelsProgressionService,
            TowerDefenseInputArgs inputArgs,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            RewardService rewardService,
            LevelConfig levelConfig,
            StatisticService statisticService)
        {
            _levelsProgressionService = levelsProgressionService;
            _inputArgs = inputArgs;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _rewardService = rewardService;
            _levelConfig = levelConfig;
            _statisticService = statisticService;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("ПОБЕДА!");

            _levelsProgressionService.CompleteLevel(_inputArgs.LevelNumber);
            _statisticService.RegisterWin();
            _rewardService.Grant(_levelConfig.WinReward);
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
        }

        public void Update(float deltaTime)
        {
        }
    }
}
