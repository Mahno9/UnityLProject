using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.States.TowerDefense
{
    // Бой: гоняем стейдж волн, по клику игрок ставит взрывы.
    public class CombatState : State, IUpdatableState
    {
        private readonly StageProviderService _stageProviderService;
        private readonly PlayerExplosionOnClickService _playerExplosionService;

        public CombatState(
            StageProviderService stageProviderService,
            PlayerExplosionOnClickService playerExplosionService)
        {
            _stageProviderService = stageProviderService;
            _playerExplosionService = playerExplosionService;
        }

        public override void Enter()
        {
            base.Enter();

            _stageProviderService.SwitchToNext();
            _stageProviderService.StartCurrent();
            _playerExplosionService.Enable();
        }

        public void Update(float deltaTime)
        {
            _stageProviderService.UpdateCurrent(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _playerExplosionService.Disable();
            _stageProviderService.CleanupCurrent();
        }
    }
}
