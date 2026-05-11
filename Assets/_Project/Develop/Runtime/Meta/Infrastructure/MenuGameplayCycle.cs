using System;
using System.Collections;

using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
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
                    WalletService walletService = _container.Resolve<WalletService>();
                    if (walletService.EnoughGold(resetPrice))
                    {
                        walletService.SpendGold(resetPrice);
                        ResetStatistic();

                        SaveProgress();

                        RestartMenu();
                    }
                    else
                    {
                        Debug.Log($"Недостаточно средств для оплаты сброса. Стоимость: {resetPrice}");
                    }
                }

                yield return null;
            }
        }

        private void SaveProgress() =>
            _container.Resolve<ICoroutinesPerformer>().StartPerform(
                _container.Resolve<PlayerDataProvider>().Save()
            );

        private int GetResetPrice()
        {
            MarketConfig marketConfig = _container.Resolve<ConfigsProviderService>().GetConfig<MarketConfig>();
            return marketConfig.GetPrice(ProductName.StatisticReset);
        }

        private void StartLevel(StringGeneratorType stringStringGeneratorType)
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer  = _container.Resolve<ICoroutinesPerformer>();

            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.Level, new GameplayInputArgs(stringStringGeneratorType)));
        }

        private void RestartMenu()
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer  = _container.Resolve<ICoroutinesPerformer>();

            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu));
        }

        private void PrintStatistic()
        {
            StatisticService statisticService = _container.Resolve<StatisticService>();
            WalletService    walletService    = _container.Resolve<WalletService>();
            Debug.Log($"Статистика. Побед: {statisticService.GetWins().Value} | Поражений: {statisticService.GetLoses().Value} | Деняк: {walletService.GetGold().Value}");
        }

        public void ResetStatistic()
        {
            StatisticService statisticService = _container.Resolve<StatisticService>();
            statisticService.ResetStatistic();
        }
    }
}