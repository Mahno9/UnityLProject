using _Project.Develop.Runtime.Gameplay.Features.Mine;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.States.TowerDefense
{
    // Подготовка: игрок расставляет мины кликами (бесплатно), ждём нажатия Start.
    public class PreparationState : State, IUpdatableState
    {
        private readonly MineSpawnService _mineSpawnService;
        private readonly StartBattleService _startBattleService;

        public PreparationState(
            MineSpawnService mineSpawnService,
            StartBattleService startBattleService)
        {
            _mineSpawnService = mineSpawnService;
            _startBattleService = startBattleService;
        }

        public override void Enter()
        {
            base.Enter();

            _startBattleService.Reset();
            _mineSpawnService.Enable();
        }

        public void Update(float deltaTime)
        {
        }

        public override void Exit()
        {
            base.Exit();

            _mineSpawnService.Disable();
        }
    }
}
