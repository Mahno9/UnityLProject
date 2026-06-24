using System;

using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.States.TowerDefense
{
    // Поражение: башня взорвана. Клик по полю -> переход в меню.
    public class DefeatState : State, IUpdatableState
    {
        private readonly ClickAreaService         _clickAreaService;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly TowerDefenseInputArgs    _inputArgs;
        private readonly SceneSwitcherService     _sceneSwitcherService;
        private readonly ICoroutinesPerformer     _coroutinesPerformer;
        private          IDisposable              _clickSubscription;

        public DefeatState(
            ClickAreaService clickAreaService,
            LevelsProgressionService levelsProgressionService,
            TowerDefenseInputArgs inputArgs,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _clickAreaService = clickAreaService;
            _levelsProgressionService = levelsProgressionService;
            _inputArgs = inputArgs;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("ПОРАЖЕНИЕ!");

            _levelsProgressionService.DefeatLevel(_inputArgs.LevelNumber);

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
