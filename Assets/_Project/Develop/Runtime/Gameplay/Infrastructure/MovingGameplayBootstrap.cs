using System;
using System.Collections;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.AI;
using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.MainHero;
using _Project.Develop.Runtime.Gameplay.Features.PlayerStructures;
using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
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
        private const float PLAYER_EXPLOSION_DAMAGE = 50f;

        private GameplayStatesContext _gameplayStatesContext;

        private DIContainer         _container;
        private EntitiesLifeContext _entitiesLifeContext;
        private AIBrainsContext     _brainsContext;
        private IInputService       _inputService;
        private ExplosionFactory    _explosionFactory;

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
            _explosionFactory = _container.Resolve<ExplosionFactory>();

            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            _container.Resolve<MainHeroFactory>().Create(Vector3.zero);

            // ponytail: test placement of player structures; move/remove once real placement exists
            PlayerStructuresFactory playerStructuresFactory = _container.Resolve<PlayerStructuresFactory>();
            playerStructuresFactory.CreateTower(new Vector3(3, 0, 3));
            playerStructuresFactory.CreateMine(new Vector3(-3, 0, 3));

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

            ProcessPlayerExplosionInput();
        }

        // ponytail: smallest working click->explosion hook; promote to an input service/state if it grows
        private void ProcessPlayerExplosionInput()
        {
            if (_explosionFactory == null)
                return;

            if (Input.GetMouseButtonDown(0) == false)
                return;

            Camera camera = Camera.main;

            if (camera == null)
                return;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance);
                _explosionFactory.Create(point, PLAYER_EXPLOSION_DAMAGE, Teams.Player);
            }
        }
    }
}