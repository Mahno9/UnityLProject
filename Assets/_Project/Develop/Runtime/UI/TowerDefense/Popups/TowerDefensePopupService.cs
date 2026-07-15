using System;

using _Project.Develop.Runtime.Configs.Meta.Rewards;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.TowerDefense;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class TowerDefensePopupService : PopupService
    {
        private readonly TowerDefenseUIRoot            _uiRoot;
        private readonly TowerDefensePresentersFactory _towerDefensePresentersFactory;
        private readonly TimedCountersFactory          _countersFactory;

        public TowerDefensePopupService(
            ViewsFactory                  viewsFactory,
            ProjectPresentersFactory      presentersFactory,
            TowerDefenseUIRoot            uiRoot,
            TowerDefensePresentersFactory towerDefensePresentersFactory,
            TimedCountersFactory timedCountersFactory)
            : base(viewsFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
            _towerDefensePresentersFactory = towerDefensePresentersFactory;
            _countersFactory = timedCountersFactory;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;

        public WinPopupPresenter OpenWinPopup(RewardConfig rewardConfig, Action closeCallback = null)
        {
            WinPopupView view = ViewsFactory.Create<WinPopupView>(ViewIDs.TowerDefenseWinPopup, PopupLayer);

            view.Initialize(((GoldRewardConfig)rewardConfig).Amount, _countersFactory);

            WinPopupPresenter popup = _towerDefensePresentersFactory.CreateWinPopupPresenter(view);

            OnPopupCreated(popup, view, closeCallback);

            return popup;
        }
    }
}