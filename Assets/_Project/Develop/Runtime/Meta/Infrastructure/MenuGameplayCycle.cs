using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.LevelPickerService;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace LProject.Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MenuGameplayCycle
    {
        private readonly DIContainer          _container;

		public MenuGameplayCycle(DIContainer container)
		{
			_container = container;
		}

		public IEnumerator Update()
        {
            Debug.Log("Старт сцены меню" + "\n" +
                      "1 - Пин из чисел" + "\n" +
                      "2 - Пин из букв");

            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    _container.Resolve<LevelLoaderService>().StartLevel(StringGeneratorType.RandomNumbers);
                if (Input.GetKeyDown(KeyCode.Alpha2))
                    _container.Resolve<LevelLoaderService>().StartLevel(StringGeneratorType.RandomLetters);

                yield return null;
            }
        }
    }
}