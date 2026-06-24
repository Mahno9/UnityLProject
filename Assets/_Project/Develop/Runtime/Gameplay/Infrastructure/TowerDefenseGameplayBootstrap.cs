using System.Collections;

using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.AI;
using _Project.Develop.Runtime.Gameplay.Features.Enemies;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.PlayerStructures;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.States;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.UI.TowerDefense;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class TowerDefenseGameplayBootstrap : SceneBootstrap
    {
        [SerializeField] private Transform        _towerPoint;
        [SerializeField] private LevelsListConfig _levelsList;

        private DIContainer           _container;
        private EntitiesLifeContext   _entitiesLifeContext;
        private AIBrainsContext       _brainsContext;
        private ClickAreaService      _clickAreaService;
        private GameplayStatesContext _gameplayStatesContext;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            TowerDefenseContextRegistrations.Process(_container, sceneArgs as TowerDefenseInputArgs, _levelsList);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация сцены tower-defense");

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _clickAreaService = _container.Resolve<ClickAreaService>();
            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            LevelConfig levelConfig = _container.Resolve<LevelConfig>();

            _container.Resolve<EnemyRandomPointSpawnService>()
                .SetSpawnArea(_towerPoint.position, levelConfig.EnemySpawnRadius);

            Entity tower = _container.Resolve<PlayerStructuresFactory>().CreateTower(_towerPoint.position);
            _container.Resolve<EntityTrackingService>().Track(tower);

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Старт сцены tower-defense");

            _gameplayStatesContext.Run();
        }

        private void Update()
        {
            _entitiesLifeContext?.Update(Time.deltaTime);
            _brainsContext?.Update(Time.deltaTime);
            _clickAreaService?.Update(Time.deltaTime);
            _gameplayStatesContext?.Update(Time.deltaTime);
        }
    }
}
