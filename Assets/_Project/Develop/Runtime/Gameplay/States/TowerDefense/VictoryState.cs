using System;

using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.States.TowerDefense
{
    // Победа: все стейджи зачищены. Клик по полю -> переход в меню.
    public class VictoryState : State, IUpdatableState
    {
        private readonly ClickAreaService         _clickAreaService;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly TowerDefenseInputArgs    _inputArgs;
        private readonly PlayerDataProvider       _playerDataProvider;
        private readonly SceneSwitcherService     _sceneSwitcherService;
        private readonly ICoroutinesPerformer     _coroutinesPerformer;
        private          IDisposable              _clickSubscription;

        public VictoryState(
            ClickAreaService clickAreaService,
            LevelsProgressionService levelsProgressionService,
            TowerDefenseInputArgs inputArgs,
            PlayerDataProvider playerDataProvider,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _clickAreaService = clickAreaService;
            _levelsProgressionService = levelsProgressionService;
            _inputArgs = inputArgs;
            _playerDataProvider = playerDataProvider;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("ПОБЕДА!");

            _levelsProgressionService.CompleteLevel(_inputArgs.LevelNumber);
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _clickSubscription = _clickAreaService.Clicked.Subscribe(OnClicked);
        }

        public void Update(float deltaTime)
        {
        }

        public override void Exit()
        {
            base.Exit();

            _clickSubscription.Dispose();
        }

        private void OnClicked(Vector3 point)
        {
            _clickSubscription.Dispose();

            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu));
        }
    }
}
