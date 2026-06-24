using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class ContinuousAreaTargetsCollectSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _collectRequest;

        public void OnInit(Entity entity)
        {
            _collectRequest = entity.AreaTargetsCollectRequest;
        }

        public void OnUpdate(float deltaTime)
        {
            _collectRequest.Invoke();
        }
    }
}
