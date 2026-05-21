using System;

using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.Infrastructure.DI
{
    public class Registration : IRegistrationOptions
    {
        private readonly Func<DIContainer, object> _creator;
        private          object                    _cachedInstance;

        public bool IsNonLazy { get; private set; }

        public Registration(Func<DIContainer, object> creator) => _creator = creator;

        public object CreateInstanceFrom(DIContainer container)
        {
            if (_cachedInstance is not null)
                return _cachedInstance;

            if (_creator == null)
                throw new InvalidOperationException("Not has instance or creator");

            _cachedInstance = _creator.Invoke(container);

            return _cachedInstance;
        }

        public void OnInitialize()
        {
            if (_cachedInstance is null)
                return;

            if (_cachedInstance is IInitializable initializable)
                initializable.Initialize();
            else
                throw new InvalidOperationException("Instance expect to be initialized. Consider to register with NonLazy()");
        }

        public void OnDispose()
        {
            if (_cachedInstance is IDisposable disposableInstance)
                disposableInstance.Dispose();
        }

        public void NonLazy() => IsNonLazy = true;
    }
}