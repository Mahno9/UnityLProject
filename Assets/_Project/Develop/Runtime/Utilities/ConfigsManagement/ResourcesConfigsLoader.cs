using System;
using System.Collections;
using System.Collections.Generic;

using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Configs.Meta.Progression;
using _Project.Develop.Runtime.Configs.Meta.Statistic;
using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Utilities.AssetManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Utilities.ConfigsManagement
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resources;

        private readonly Dictionary<Type, string> _configsResourcesPaths = new()
        {
            {typeof(StartWalletConfig), R.Configs.Meta.Wallet.StartWalletConfig},
            {typeof(StartStatisticConfig), R.Configs.Meta.Statistic.StartStatisticConfig},
            {typeof(ProgressionConfig), R.Configs.Meta.Progression.ProgressionConfig},
            {typeof(MarketConfig), R.Configs.Meta.Market.MarketConfig},
            {typeof(CurrencyIconsConfig), R.Configs.Meta.Wallet.CurrencyIconsConfig},
            {typeof(MetricsIconsConfig), R.Configs.Meta.Statistic.MetricsIconsConfig},
        };

        public ResourcesConfigsLoader(ResourcesAssetsLoader resources)
        {
            _resources = resources;
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (KeyValuePair<Type, string> configResourcesPath in _configsResourcesPaths)
            {
                ScriptableObject config = _resources.Load<ScriptableObject>(configResourcesPath.Value);
                loadedConfigs.Add(configResourcesPath.Key, config);
                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }
    }
}