using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly MovingGameplayInputArgs  _gameplayInputArgs;
        private readonly SceneSwitcherService     _sceneSwitcherService;
        private readonly ICoroutinesPerformer     _coroutinesPerformer;

        public DefeatState(
            IInputService            inputService,
            LevelsProgressionService levelsProgressionService,
            MovingGameplayInputArgs  gameplayInputArgs,
            SceneSwitcherService     sceneSwitcherService,
            ICoroutinesPerformer     coroutinesPerformer) : base(inputService)
        {
            _levelsProgressionService = levelsProgressionService;
            _gameplayInputArgs = gameplayInputArgs;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public override void Enter()
        {
            base.Enter();

            _levelsProgressionService.DefeatLevel(_gameplayInputArgs.LevelNumber);

            Debug.Log("ПОРАЖЕНИЕ!");
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu));
            }
        }
    }
}
