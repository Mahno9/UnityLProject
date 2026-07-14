using System;

using _Project.Develop.Runtime.Configs.Meta.Rewards;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.TowerDefense;

using UnityEngine;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class TowerDefensePopupService : PopupService
    {
        private readonly TowerDefenseUIRoot            _uiRoot;
        private readonly TowerDefensePresentersFactory _towerDefensePresentersFactory;

        public TowerDefensePopupService(
            ViewsFactory                  viewsFactory,
            ProjectPresentersFactory      presentersFactory,
            TowerDefenseUIRoot            uiRoot,
            TowerDefensePresentersFactory towerDefensePresentersFactory)
            : base(viewsFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
            _towerDefensePresentersFactory = towerDefensePresentersFactory;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;

        public WinPopupPresenter OpenWinPopup(RewardConfig rewardConfig, Action closeCallback = null)
        {
            WinPopupView view = ViewsFactory.Create<WinPopupView>(ViewIDs.TowerDefenseWinPopup, PopupLayer);

            if (rewardConfig is GoldRewardConfig goldRewardConfig)
                view.SetRewardGoldAmount(goldRewardConfig.Amount);

            WinPopupPresenter popup = _towerDefensePresentersFactory.CreateWinPopupPresenter(view);

            OnPopupCreated(popup, view, closeCallback);

            return popup;
        }
    }
}