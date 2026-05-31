using System;
using System.Collections;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Infrastructure.MovingGameplayInputArgsManagement;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class MovingGameplayBootstrap : SceneBootstrap
    {
        [SerializeField] private TestGameplay _testGameplay;

        private DIContainer         _container;
        private EntitiesLifeContext _entitiesLifeContext;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MovingGameplayContextRegistrations.Process(_container, sceneArgs as MovingGameplayInputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация сцены геймплея движения");

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();

            _testGameplay.Initialize(_container);

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Старт геймплейной сцены");

            _testGameplay.Run();
        }

        private void Update()
        {
            _entitiesLifeContext?.Update(Time.deltaTime);
        }
    }
}
