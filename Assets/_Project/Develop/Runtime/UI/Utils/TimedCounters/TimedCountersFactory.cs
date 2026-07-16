using System;

using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class TimedCountersFactory
    {
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public TimedCountersFactory(ICoroutinesPerformer coroutinesPerformer)
        {
            _coroutinesPerformer = coroutinesPerformer;
        }

        public CounterUp CreateCounterUp(
            float  targetValue,
            Action animationEndCallback,
            float  duration,
            float  startValue            = 0f,
            float  minimalUpdateInterval = 0.01f,
            bool   autostart             = true)
        {
            CounterUp counter = new CounterUp(
                _coroutinesPerformer,
                animationEndCallback,
                targetValue,
                duration,
                startValue,
                minimalUpdateInterval
            );

            if (autostart)
                counter.Start();

            return counter;
        }
    }
}