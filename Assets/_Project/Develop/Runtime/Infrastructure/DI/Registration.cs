using System;

using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.Infrastructure.DI
{
    public class Registration : IRegistrationOptions
    {
        private readonly Func<DIContainer, object> _creator;
        private          object                    _cachedInstance;
        private          bool                      _isInitializeCalled;

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
            if (_cachedInstance is null || _isInitializeCalled)
                return;

            _isInitializeCalled = true;

            if (_cachedInstance is IInitializable initializable)
                initializable.Initialize();
        }

        public void OnDispose()
        {
            if (_cachedInstance is IDisposable disposableInstance)
                disposableInstance.Dispose();
        }

        public void NonLazy() => IsNonLazy = true;
    }
}