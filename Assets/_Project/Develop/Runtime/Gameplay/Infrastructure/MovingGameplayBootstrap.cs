using System.Collections;

using _Project.Develop.Runtime.Gameplay.Infrastructure.MovingGameplayInputArgsManagement;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class MovingGameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MovingGameplayContextRegistrations.Process(_container, sceneArgs as MovingGameplayInputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация сцены геймплея движения");

            yield break;
        }

        public override void Run()
        {
            _container.Resolve<MovingGameplayCycle>().Start();
        }
    }
}
