using System;

using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class MovingGameplayCycle : IDisposable
    {
        private readonly DIContainer _container;

        public MovingGameplayCycle(DIContainer container)
        {
            _container = container;
        }

        public void Start()
        {
            // start your gameplay mechanic here
        }

        public void Dispose()
        {
        }
    }
}
