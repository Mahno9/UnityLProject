using System;

using _Project.Develop.Runtime.UI.Core;

using DG.Tweening;

using TMPro;

using UnityEngine;

using Sequence = DG.Tweening.Sequence;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class WinPopupView : PopupViewBase
    {
        public event Action MenuButtonClicked;

        [SerializeField] private Transform       _rewardIconTransform;
        [SerializeField] private TextMeshProUGUI _rewardText;

        [SerializeField] private Transform _respectIconTransform;
        [SerializeField] private Transform _respectTextTransform;

        [SerializeField] private float                _countUpDuration = 1f;
        private                  int                  _rewardGoldAmount;

        private TimedCountersFactory _countersFactory;
        private CounterUp            _counter;
        private IDisposable          _counterSubscription;

        public void Initialize(int rewardGoldAmount, TimedCountersFactory countersFactory)
        {
            _rewardGoldAmount = rewardGoldAmount;
            _countersFactory = countersFactory;
        }

        public void OnDisable()
        {
            _counterSubscription?.Dispose();
            _counter?.Dispose();
        }

        public void OnMenuButtonClicked() => MenuButtonClicked?.Invoke();

        protected override void OnPreShow()
        {
            base.OnPreShow();

            _rewardIconTransform.transform.localScale = Vector3.zero;
            _rewardText.transform.localScale = Vector3.zero;
            _rewardText.text = "0";
            _respectIconTransform.transform.localScale = Vector3.zero;
            _respectTextTransform.transform.localScale = Vector3.zero;
        }

        protected override void ModifyShowAnimation(Sequence animation)
        {
            base.ModifyShowAnimation(animation);

            AddShowingAnimationForObject(animation, _rewardIconTransform);
            AddShowingAnimationForObject(animation, _rewardText.transform);
            animation.AppendCallback(() => CountUpReward(() =>
            {
                _rewardText.transform.DOPunchScale(
                    punch: Vector3.one * 0.15f,
                    duration: 0.15f,
                    vibrato: 5,
                    elasticity: 0.5f
                );
            }));
            AddShowingAnimationForObject(animation, _respectIconTransform);
            AddShowingAnimationForObject(animation, _respectTextTransform);
        }

        private static void AddShowingAnimationForObject(Sequence animation, Transform target)
        {
            animation.Append(target.DOScale(1, 0.3f).SetEase(Ease.OutBack).From(0));
            animation.AppendInterval(0.1f);
        }

        private void CountUpReward(Action animationEndCallback)
        {
            _counter = _countersFactory.CreateCounterUp(_rewardGoldAmount, animationEndCallback, _countUpDuration);
            _counterSubscription = _counter.CurrentValue.Subscribe(OnCurrentValueChanged);
        }

        private void OnCurrentValueChanged(float _, float newValue)
        {
            _rewardText.text = newValue.ToString("F0");
        }
    }
}