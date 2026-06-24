using _Project.Develop.Runtime.Configs.Gameplay.Entities;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Enemies
{
    // Спавнит врага в СЛУЧАЙНОЙ точке из списка. Точки отдаёт бутстрап (из эдитора).
    public class EnemyRandomPointSpawnService
    {
        private readonly EnemiesFactory _enemiesFactory;

        private IReadOnlyList<Vector3> _spawnPoints;

        public EnemyRandomPointSpawnService(EnemiesFactory enemiesFactory)
        {
            _enemiesFactory = enemiesFactory;
        }

        public void SetSpawnPoints(IReadOnlyList<Vector3> spawnPoints)
        {
            _spawnPoints = spawnPoints;
        }

        public Entity Spawn(EntityConfig enemyConfig)
        {
            if (_spawnPoints == null || _spawnPoints.Count == 0)
                throw new InvalidOperationException("Spawn points are not set");

            Vector3 point = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)];

            return _enemiesFactory.Create(point, enemyConfig);
        }
    }
}
