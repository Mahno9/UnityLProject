using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class TeleportCooldownState : UpdatableState
    {
        private readonly Entity _entity;

        public TeleportCooldownState(Entity entity)
        {
            _entity = entity;
        }

        public override void Enter()
        {
            base.Enter();
            _entity.TeleportCooldownTimer.Value = _entity.InitialTeleportCooldownTimer;
        }
    }

    // public class RestoreEnergyState : UpdatableState
    // {
    //     private readonly Entity _entity;
    //     private readonly int    _energyRequireQuantity;
    //
    //     public RestoreEnergyState(Entity entity, int energyRequireQuantity)
    //     {
    //         _entity = entity;
    //         _energyRequireQuantity = energyRequireQuantity;
    //     }
    //
    //     public override void Update(float deltaTime)
    //     {
    //         base.Update(deltaTime);
    //         if (_entity.Energy < _energyRequireQuantity)
    //         {
    //
    //         }
    //     }
    // }
}