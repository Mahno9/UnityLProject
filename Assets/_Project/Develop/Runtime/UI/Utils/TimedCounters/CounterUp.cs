using System;
using System.Collections;

using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class CounterUp : IDisposable
    {
        private readonly ICoroutinesPerformer    _coroutinesPerformer;
        private readonly Action                  _animationEndCallback;
        private readonly float                   _targetValue;
        private readonly float                   _duration;
        private readonly float                   _minimalUpdateInterval;
        private readonly ReactiveVariable<float> _currentValue;

        private Coroutine _coroutine;

        public CounterUp(
            ICoroutinesPerformer coroutinesPerformer,
            Action               animationEndCallback,
            float                targetValue,
            float                duration,
            float                startValue            = 0f,
            float                minimalUpdateInterval = 0.01f
        )
        {
            _coroutinesPerformer = coroutinesPerformer;
            _animationEndCallback = animationEndCallback;
            _targetValue = targetValue;
            _duration = duration;
            _minimalUpdateInterval = minimalUpdateInterval;
            _currentValue = new ReactiveVariable<float>(startValue);
        }

        public IReadOnlyVariable<float> CurrentValue => _currentValue;

        public void Start()
        {
            _coroutine = _coroutinesPerformer.StartPerform(Routine(_animationEndCallback));
        }

        public void Dispose()
        {
            if (_coroutine is not null)
                _coroutinesPerformer.StopPerform(_coroutine);
        }

        private IEnumerator Routine(Action animationEndCallback)
        {
            float prevTickTime   = Time.time;
            float deltaPerSecond = (_targetValue - _currentValue.Value) / _duration;

            while (_currentValue.Value < _targetValue)
            {
                float currentTickTime = Time.time;
                float timePassed      = currentTickTime - prevTickTime;

                float currentDelta = deltaPerSecond * timePassed;
                prevTickTime = currentTickTime;
                _currentValue.Value = Mathf.Min(currentDelta + _currentValue.Value, _targetValue);

                if (_currentValue.Value >= _targetValue)
                {
                    animationEndCallback();
                    yield break;
                }

                yield return new WaitForSeconds(_minimalUpdateInterval);
            }
        }
    }
}