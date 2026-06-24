using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    // Счётчик врагов ТЕКУЩЕЙ волны: общее число по плану, убитые, живые.
    // Living-count (Alive) использует ClearAllWavesStage и для лимита одновременных
    // врагов на экране, и для детекта зачистки волны.
    public class WaveEnemyCounterService
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly ReactiveVariable<int> _total = new();
        private readonly ReactiveVariable<int> _killed = new();
        private readonly ReactiveVariable<int> _alive = new();

        private readonly Dictionary<Entity, IDisposable> _aliveEnemies = new();

        public WaveEnemyCounterService(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyVariable<int> Total => _total;
        public IReadOnlyVariable<int> Killed => _killed;
        public IReadOnlyVariable<int> Alive => _alive;

        public int Spawned => _killed.Value + _alive.Value;

        public void StartWave(int total)
        {
            Clear();

            _total.Value = total;
        }

        public void Add(Entity enemy)
        {
            IDisposable subscription = enemy.IsDead.Subscribe((oldValue, isDead) =>
            {
                if (isDead == false)
                    return;

                OnEnemyDied(enemy);
            });

            _aliveEnemies.Add(enemy, subscription);
            _alive.Value++;
        }

        public void Clear()
        {
            ReleaseAlive();

            _total.Value = 0;
            _killed.Value = 0;
            _alive.Value = 0;
        }

        private void OnEnemyDied(Entity enemy)
        {
            if (_aliveEnemies.TryGetValue(enemy, out IDisposable subscription) == false)
                return;

            subscription.Dispose();
            _aliveEnemies.Remove(enemy);

            _alive.Value--;
            _killed.Value++;
        }

        private void ReleaseAlive()
        {
            foreach (KeyValuePair<Entity, IDisposable> aliveEnemy in _aliveEnemies)
            {
                aliveEnemy.Value.Dispose();
                _entitiesLifeContext.Release(aliveEnemy.Key);
            }

            _aliveEnemies.Clear();
        }
    }
}
