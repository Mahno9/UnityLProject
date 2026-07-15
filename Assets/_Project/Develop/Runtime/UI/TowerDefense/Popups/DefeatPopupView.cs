using System;

using _Project.Develop.Runtime.UI.Core;

using DG.Tweening;

using TMPro;

using UnityEngine;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class DefeatPopupView : PopupViewBase
    {
        public event Action MenuButtonClicked;

        [SerializeField] private Transform       _rewardIconTransform;
        [SerializeField] private TextMeshProUGUI _rewardText;

        [SerializeField] private Transform _respectIconTransform;
        [SerializeField] private Transform _respectTextTransform;

        private                  int   _rewardGoldAmount;

        public void OnMenuButtonClicked() => MenuButtonClicked?.Invoke();

        protected override void OnPreShow()
        {
            base.OnPreShow();

            _rewardIconTransform.transform.localScale = Vector3.zero;
            _rewardText.transform.localScale = Vector3.zero;
            _respectIconTransform.transform.localScale = Vector3.zero;
            _respectTextTransform.transform.localScale = Vector3.zero;
        }

        protected override void ModifyShowAnimation(Sequence animation)
        {
            base.ModifyShowAnimation(animation);

            AddShowingAnimationForObject(animation, _rewardIconTransform);
            AddShowingAnimationForObject(animation, _rewardText.transform);
            AddShowingAnimationForObject(animation, _respectIconTransform);
            AddShowingAnimationForObject(animation, _respectTextTransform);
        }

        private static void AddShowingAnimationForObject(Sequence animation, Transform target)
        {
            animation.Append(target.DOScale(1, 0.3f).SetEase(Ease.OutBack).From(0));
            animation.AppendInterval(0.1f);
        }
    }
}