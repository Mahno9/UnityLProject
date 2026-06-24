using System;

using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Explosion
{
    // Создаёт взрыв игрока по клику в боевой фазе (перенос хука из MovingGameplayBootstrap).
    public class PlayerExplosionOnClickService
    {
        private const float PLAYER_EXPLOSION_DAMAGE = 50f;

        private readonly ClickAreaService _clickAreaService;
        private readonly ExplosionFactory _explosionFactory;

        private bool        _isEnabled;
        private IDisposable _clickSubscription;

        public PlayerExplosionOnClickService(
            ClickAreaService clickAreaService,
            ExplosionFactory explosionFactory)
        {
            _clickAreaService = clickAreaService;
            _explosionFactory = explosionFactory;
        }

        public void Enable()
        {
            if (_isEnabled)
                return;

            _isEnabled = true;
            _clickSubscription = _clickAreaService.Clicked.Subscribe(OnClicked);
        }

        public void Disable()
        {
            if (_isEnabled == false)
                return;

            _isEnabled = false;
            _clickSubscription.Dispose();
        }

        private void OnClicked(Vector3 point)
        {
            _explosionFactory.Create(point, PLAYER_EXPLOSION_DAMAGE, Teams.Player);
        }
    }
}
