using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Gameplay;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
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
        private readonly StatisticService         _statisticService;
        private readonly PlayerDataProvider       _playerDataProvider;
        private readonly ICoroutinesPerformer     _coroutinesPerformer;
        private readonly TowerDefensePopupService             _popupService;


        public DefeatState(
            LevelsProgressionService levelsProgressionService,
            TowerDefenseInputArgs inputArgs,
            StatisticService statisticService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            TowerDefensePopupService popupService)
        {
            _levelsProgressionService = levelsProgressionService;
            _inputArgs = inputArgs;
            _statisticService = statisticService;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("ПОРАЖЕНИЕ!");

            _levelsProgressionService.DefeatLevel(_inputArgs.LevelNumber);
            _statisticService.RegisterLose();
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _popupService.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}
