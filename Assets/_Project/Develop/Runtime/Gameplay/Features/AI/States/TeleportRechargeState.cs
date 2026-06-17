using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class TeleportRechargeState : UpdatableState
    {
        private readonly Entity _entity;

        public TeleportRechargeState(Entity entity)
        {
            _entity = entity;
        }

        public override void Enter()
        {
            base.Enter();
            _entity.TeleportCooldownTimer.Value = _entity.InitialTeleportCooldownTimer;
        }
    }
}