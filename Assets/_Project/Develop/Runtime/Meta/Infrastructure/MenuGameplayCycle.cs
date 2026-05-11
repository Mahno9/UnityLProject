using System.Collections;

using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.LevelsManagment;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagment;

using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MenuGameplayCycle
    {
        private readonly DIContainer _container;

        public MenuGameplayCycle(DIContainer container)
        {
            _container = container;
        }

        public IEnumerator Update()
        {
            PrintStatistic();

            Debug.Log("Старт сцены меню [1] - Пин из чисел [2] - Пин из букв");

            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    _container.Resolve<LevelLoaderService>().StartLevel(StringGeneratorType.RandomNumbers);
                if (Input.GetKeyDown(KeyCode.Alpha2))
                    _container.Resolve<LevelLoaderService>().StartLevel(StringGeneratorType.RandomLetters);

                yield return null;
            }
        }

        private void PrintStatistic()
        {
            StatisticService statisticService = _container.Resolve<StatisticService>();
            Debug.Log($"Статистика. Побед: {statisticService.GetWins()} Поражений: {statisticService.GetLoses()}");
        }
    }
}