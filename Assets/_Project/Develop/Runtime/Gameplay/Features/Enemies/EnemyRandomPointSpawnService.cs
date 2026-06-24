using _Project.Develop.Runtime.Configs.Gameplay.Entities;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Enemies
{
    // Спавнит врага в случайной точке на окружности заданного радиуса вокруг центра (башни).
    public class EnemyRandomPointSpawnService
    {
        private readonly EnemiesFactory _enemiesFactory;

        private Vector3 _center;
        private float   _radius;

        public EnemyRandomPointSpawnService(EnemiesFactory enemiesFactory)
        {
            _enemiesFactory = enemiesFactory;
        }

        public void SetSpawnArea(Vector3 center, float radius)
        {
            _center = center;
            _radius = radius;
        }

        public Entity Spawn(EntityConfig enemyConfig)
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);

            Vector3 point = _center + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * _radius;

            return _enemiesFactory.Create(point, enemyConfig);
        }
    }
}
