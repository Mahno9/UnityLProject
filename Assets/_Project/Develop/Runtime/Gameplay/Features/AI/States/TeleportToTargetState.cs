using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.StateMachineCore;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class TeleportToTargetState : UpdatableState
    {
        private readonly Entity _entity;

        public TeleportToTargetState(Entity entity)
        {
            _entity = entity;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            _entity.TeleportToTargetRequest.Invoke();
        }
    }
}