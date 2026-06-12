using System;

using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MenuGameplayCycle : IDisposable
    {
        private readonly DIContainer _container;

        public MenuGameplayCycle(DIContainer container)
        {
            _container = container;
        }

        public void Start()
        {
        }

        public void Dispose()
        {
        }
    }
}