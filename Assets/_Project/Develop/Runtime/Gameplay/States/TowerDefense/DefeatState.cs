using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.States.TowerDefense
{
    // Поражение: башня взорвана. Выход в меню — только по кнопке HUD.
    public class DefeatState : State, IUpdatableState
    {
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly TowerDefenseInputArgs    _inputArgs;

        public DefeatState(
            LevelsProgressionService levelsProgressionService,
            TowerDefenseInputArgs inputArgs)
        {
            _levelsProgressionService = levelsProgressionService;
            _inputArgs = inputArgs;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("ПОРАЖЕНИЕ!");

            _levelsProgressionService.DefeatLevel(_inputArgs.LevelNumber);
        }

        public void Update(float deltaTime)
        {
        }
    }
}
