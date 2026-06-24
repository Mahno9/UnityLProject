using System;

using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.PlayerStructures;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Mine
{
    // Покупает мину по клику в фазе подготовки через Market (ProductName.Mine).
    // Нехватка золота -> TryBuy вернёт false, мина не ставится.
    //
    // ponytail: расстановка без UI. TODO отдельной системой: валидация точки
    // (зона застройки, без пересечения с минами/башней), лимит, превью-«призрак».
    public class MineSpawnService
    {
        private readonly ClickAreaService        _clickAreaService;
        private readonly PlayerStructuresFactory _playerStructuresFactory;
        private readonly MarketService           _marketService;

        private bool        _isEnabled;
        private IDisposable _clickSubscription;

        public MineSpawnService(
            ClickAreaService clickAreaService,
            PlayerStructuresFactory playerStructuresFactory,
            MarketService marketService)
        {
            _clickAreaService = clickAreaService;
            _playerStructuresFactory = playerStructuresFactory;
            _marketService = marketService;
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
            _marketService.TryBuy(ProductName.Mine, _playerStructuresFactory.CreateMineProductItem(point));
        }
    }
}
