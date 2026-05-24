using System;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Utilities.Reactive
{
    public class ReactiveVariable<T> : IReadOnlyVariable<T> where T : IEquatable<T>
    {
        private readonly List<Subscription<T, T>> _subscribers = new();
        private readonly List<Subscription<T, T>> _toAdd = new();
        private readonly List<Subscription<T, T>> _toRemove = new();

        private T _value;

        public ReactiveVariable() => _value = default;

        public ReactiveVariable(T value) => _value = value;

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                _value = value;

                if (_value.Equals(oldValue) == false)
                    Invoke(oldValue, value);
            }
        }

        public IDisposable Subscribe(Action<T, T> action)
        {
            Subscription<T, T> subscription = new Subscription<T, T>(action, Remove);
            _toAdd.Add(subscription);
            return subscription;
        }

        private void Remove(Subscription<T, T> subscription) => _toRemove.Add(subscription);

        private void Invoke(T oldValue, T newValue)
        {
            if(_toAdd.Count > 0)
            {
                _subscribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if(_toRemove.Count > 0)
            {
                foreach (Subscription<T, T> subscription in _toRemove)
                    _subscribers.Remove(subscription);

                _toRemove.Clear();
            }

            foreach (Subscription<T, T> subscription in _subscribers)
                subscription.Invoke(oldValue, newValue);
        }
    }
}