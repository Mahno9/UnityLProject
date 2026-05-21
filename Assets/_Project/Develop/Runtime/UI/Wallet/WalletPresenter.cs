using System;

using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

using System.Collections.Generic;

using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.UI.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly IReadOnlyVariable<int> _currency;
        private readonly CurrencyIconsConfig    _currencyIconsConfig;

        private readonly IconTextView _view;
        private          IDisposable  _currencySubscription;

        public WalletPresenter(
            IReadOnlyVariable<int>   currency,
            CurrencyIconsConfig currencyIconsConfig,
            IconTextView view)
        {
            _currency = currency;
            _currencyIconsConfig = currencyIconsConfig;
            _view = view;
        }

        public IconTextView View => _view;

        public void Initialize()
        {
            UpdateValue(_currency.Value);
            _view.SetIcon(_currencyIconsConfig.GetGoldSprite);

            _currencySubscription = _currency.Subscribe(OnCurrencyChanged);
        }

        public void Dispose()
        {
            _currencySubscription.Dispose();
        }

        private void OnCurrencyChanged(int arg1, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetText(value.ToString());
    }
}