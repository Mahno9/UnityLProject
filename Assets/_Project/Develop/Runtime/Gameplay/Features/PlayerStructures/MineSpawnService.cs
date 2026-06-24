using System;

using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.PlayerStructures;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.PlayerStructures
{
    // Спавнит мину по клику в фазе подготовки. Пока БЕСПЛАТНО и без лимита.
    //
    // ponytail: минимальная заглушка под расстановку мин. TODO отдельными системами:
    // - Система расстановки: валидация точки (зона застройки, без пересечения с
    //   минами/башней), лимит количества, превью-«призрак», подтверждение, отмена.
    // - Система покупки за валюту: стоимость из конфига, списание через Wallet/Market,
    //   блок при нехватке средств, возврат при отмене.
    public class MineSpawnService
    {
        private readonly ClickAreaService _clickAreaService;
        private readonly PlayerStructuresFactory _playerStructuresFactory;

        private bool        _isEnabled;
        private IDisposable _clickSubscription;

        public MineSpawnService(
            ClickAreaService clickAreaService,
            PlayerStructuresFactory playerStructuresFactory)
        {
            _clickAreaService = clickAreaService;
            _playerStructuresFactory = playerStructuresFactory;
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
            _playerStructuresFactory.CreateMine(point);
        }
    }
}
