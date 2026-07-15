using _Project.Develop.Runtime.Configs.Gameplay.Stages;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.Enemies;
using _Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    // Стейдж обороны: гоняет волны последовательно, без таймеров.
    // Внутри волны спавн ограничен только MaxAliveAtOnce и TotalCount: волна
    // появляется сразу вся (до лимита) и пополняется по мере убийства. Следующая
    // волна стартует только после полной зачистки текущей.
    public class ClearAllWavesStage : IStage
    {
        private readonly ClearAllWavesStageConfig _config;
        private readonly EnemyRandomPointSpawnService _enemyRandomPointSpawnService;
        private readonly WaveEnemyCounterService _counter;

        private readonly ReactiveEvent _completed = new();

        private IEnumerator<WaveConfig> _waves;
        private bool _inProcess;

        public ClearAllWavesStage(
            ClearAllWavesStageConfig config,
            EnemyRandomPointSpawnService enemyRandomPointSpawnService,
            WaveEnemyCounterService counter)
        {
            _config = config;
            _enemyRandomPointSpawnService = enemyRandomPointSpawnService;
            _counter = counter;
        }

        public IReadOnlyEvent Completed => _completed;

        public void Start()
        {
            if (_inProcess)
                throw new InvalidOperationException("Stage already started");

            _waves = _config.Waves.GetEnumerator();
            _inProcess = true;

            _waves.MoveNext();
            StartWave(_waves.Current);
        }

        public void Update(float deltaTime)
        {
            if (_inProcess == false)
                return;

            Spawn(_waves.Current);

            if (IsWaveCleared(_waves.Current) == false)
                return;

            if (_waves.MoveNext())
                StartWave(_waves.Current);
            else
                ProcessEnd();
        }

        public void Cleanup()
        {
            _counter.Clear();
            _waves?.Dispose();
            _inProcess = false;
        }

        public void Dispose()
        {
            _counter.Clear();
            _waves?.Dispose();
            _inProcess = false;
        }

        private void StartWave(WaveConfig wave)
        {
            _counter.StartWave(wave.TotalCount);
        }

        private void Spawn(WaveConfig wave)
        {
            while (_counter.Alive.Value < wave.MaxAliveAtOnce && _counter.Spawned < wave.TotalCount)
            {
                Entity enemy = _enemyRandomPointSpawnService.Spawn(wave.EnemyConfig);

                _counter.Add(enemy);
            }
        }

        private bool IsWaveCleared(WaveConfig wave)
            => _counter.Spawned >= wave.TotalCount && _counter.Alive.Value == 0;

        private void ProcessEnd()
        {
            _inProcess = false;
            _completed.Invoke();
        }
    }
}
