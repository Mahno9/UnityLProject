using System;
using System.Collections;

using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.LevelStartManagement;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MenuGameplayCycle : IDisposable
    {
        private readonly DIContainer _container;
        private          Coroutine   _gameplayCycleCoroutine;

        public MenuGameplayCycle(DIContainer container)
        {
            _container = container;
        }

        public void Start()
        {
            _gameplayCycleCoroutine = _container.Resolve<ICoroutinesPerformer>().StartPerform(Update());
        }

        public void Dispose()
        {
            _container.Resolve<ICoroutinesPerformer>().StopPerform(_gameplayCycleCoroutine);
        }

        public IEnumerator Update()
        {
            PrintStatistic();

            int resetPrice = GetResetPrice();
            Debug.Log($"Меню: [1] - Пин из чисел | [2] - Пин из букв | [R] - Сбросить прогресс ({resetPrice} деняк)");

            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    StartLevel(StringGeneratorType.RandomNumbers);

                if (Input.GetKeyDown(KeyCode.Alpha2))
                    StartLevel(StringGeneratorType.RandomLetters);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    MarketService market = _container.Resolve<MarketService>();

                    if (market.TryBuy(ProductName.StatisticReset) == false)
                        Debug.Log($"Недостаточно средств для оплаты сброса. Стоимость: {resetPrice}");
                }

                yield return null;
            }
        }

        private int GetResetPrice()
            => _container.Resolve<MarketService>().GetPrice(ProductName.StatisticReset);

        private void StartLevel(StringGeneratorType stringStringGeneratorType)
            => _container.Resolve<LevelStarterService>().StartLevel(stringStringGeneratorType);

        private void PrintStatistic()
        {
            StatisticService statisticService = _container.Resolve<StatisticService>();
            WalletService    walletService    = _container.Resolve<WalletService>();
            Debug.Log($"Статистика. Побед: {statisticService.GetMetric(StatisticMetricType.Win).Value} | Поражений: {statisticService.GetMetric(StatisticMetricType.Lose).Value} | Деняк: {walletService.GetGold().Value}");
        }
    }
}