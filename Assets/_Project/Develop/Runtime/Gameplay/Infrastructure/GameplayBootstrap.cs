using System;
using System.Collections;

using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagment;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            GameplayContextRegistrations.Process(_container, gameplayInputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log($"Вы попали на уровень {_container.Resolve<GameplayInputArgsService>().Get().StringGeneratorType}");
            Debug.Log("Инициализация геймплейной сцены");

            yield break;
        }

        public override void Run()
        {
            _container.Resolve<GameplayCycle>().Start();
        }
    }
}