using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage
{
    public class DealDamageOnTeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private IDisposable   _subscription;
        private ReactiveEvent _onTeleportEvent;
        private ReactiveEvent _targetsCollectRequest;

        public void OnInit(Entity entity)
        {
            _onTeleportEvent = entity.OnTeleportEvent;
            _targetsCollectRequest = entity.AreaTargetsCollectRequest;

            _subscription = _onTeleportEvent.Subscribe(() =>
            {
                _targetsCollectRequest?.Invoke();
            });
        }

        public void OnDispose()
        {
            _subscription.Dispose();
        }
    }
}