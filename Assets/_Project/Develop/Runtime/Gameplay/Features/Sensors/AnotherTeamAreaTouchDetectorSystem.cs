using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class AnotherTeamAreaTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _targets;
        private ReactiveVariable<bool> _isTouchAnotherTeam;
        private ReactiveVariable<Teams> _sourceTeam;

        public void OnInit(Entity entity)
        {
            _targets = entity.TargetsEntitiesBuffer;
            _isTouchAnotherTeam = entity.IsTouchAnotherTeam;
            _sourceTeam = entity.Team;
        }

        public void OnUpdate(float deltaTime)
        {
            bool touchAnotherTeam = false;

            for (int i = 0; i < _targets.Count; i++)
            {
                Entity target = _targets.Items[i];

                if (target.TryGetTeam(out ReactiveVariable<Teams> anotherTeam)
                    && _sourceTeam.Value != anotherTeam.Value)
                {
                    touchAnotherTeam = true;
                    break;
                }
            }

            _isTouchAnotherTeam.Value = touchAnotherTeam;

            // The area filter early-returns on an empty collider buffer, so consume the
            // targets here to avoid reading stale entities next frame.
            _targets.Count = 0;
        }
    }
}
