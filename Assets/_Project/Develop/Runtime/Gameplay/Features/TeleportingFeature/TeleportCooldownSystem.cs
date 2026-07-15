using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class TeleportCooldownSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _timerLeft;
        private float                   _timerInitial;
        private ReactiveEvent           _cooldownDoneEvent;
        private ReactiveEvent           _teleportHappenedEvent;

        private readonly bool _autoRestart;

        public TeleportCooldownSystem(bool autoRestart)
        {
            _autoRestart = autoRestart;
        }

        public void OnInit(Entity entity)
        {
            _timerLeft = entity.TeleportCooldownTimer;
            _cooldownDoneEvent = entity.TeleportCooldownDoneEvent;

            _timerInitial = entity.InitialTeleportCooldownTimer;
            _teleportHappenedEvent = entity.TeleportDoneEvent;

            _teleportHappenedEvent.Subscribe(OnTeleportHappened);
        }

        public void OnUpdate(float deltaTime)
        {
            if (!(_timerLeft.Value > 0))
                return;

            _timerLeft.Value = Mathf.Max(0, _timerLeft.Value - deltaTime);

            if (_timerLeft.Value <= 0)
                _cooldownDoneEvent?.Invoke();
        }

        private void OnTeleportHappened()
        {
            if (_autoRestart)
                _timerLeft.Value = _timerInitial;
        }
    }
}