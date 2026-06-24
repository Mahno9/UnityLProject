using System;
using System.Collections;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.AI;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.MainHero;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.States;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class MovingGameplayBootstrap : SceneBootstrap
    {
        private GameplayStatesContext _gameplayStatesContext;

        private DIContainer         _container;
        private EntitiesLifeContext _entitiesLifeContext;
        private AIBrainsContext     _brainsContext;
        private IInputService       _inputService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MovingGameplayContextRegistrations.Process(_container, sceneArgs as MovingGameplayInputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация сцены геймплея движения");

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _inputService = _container.Resolve<IInputService>();

            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            _container.Resolve<MainHeroFactory>().Create(Vector3.zero);

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Старт геймплейной сцены");

            _gameplayStatesContext.Run();
        }

        private void Update()
        {
            _entitiesLifeContext?.Update(Time.deltaTime);
            _brainsContext?.Update(Time.deltaTime);
            _inputService?.Update(Time.deltaTime);
            _gameplayStatesContext?.Update(Time.deltaTime);
        }
    }
}