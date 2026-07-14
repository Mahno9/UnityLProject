using System;

using _Project.Develop.Runtime.UI.Core;

using DG.Tweening;

using TMPro;

using UnityEngine;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class WinPopupView : PopupViewBase
    {
        public event Action MenuButtonClicked;

        [SerializeField] private Transform       _rewardIconTransform;
        [SerializeField] private TextMeshProUGUI _rewardText;

        [SerializeField] private Transform _respectIconTransform;
        [SerializeField] private Transform _respectTextTransform;

        private                  int       _rewardGoldAmount;

        public void OnMenuButtonClicked() => MenuButtonClicked?.Invoke();

        public void SetRewardGoldAmount(int value) => _rewardGoldAmount = value;

        protected override void OnPreShow()
        {
            base.OnPreShow();
            // TODO: hide elements to prepare for animation
        }

        protected override void ModifyShowAnimation(Sequence animation)
        {
            base.ModifyShowAnimation(animation);

            // TODO: show outcubic the reward icon, then text the same and count up to level reward amount
            // TODO: show outcubic the respect icon, then text the same
        }
    }
}