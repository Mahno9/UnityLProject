using _Project.Develop.Runtime.Configs.Gameplay.Stages;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.Enemies;
using _Project.Develop.Runtime.Infrastructure.DI;
using System;

namespace _Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    public class StagesFactory
    {
        private readonly DIContainer _container;

        public StagesFactory(DIContainer container)
        {
            _container = container;
        }

        public IStage Create(StageConfig stageConfig)
        {
            switch (stageConfig)
            {
                case ClearAllEnemiesStageConfig clearAllEnemiesStageConfig:
                    return new ClearAllEnemiesStage(
                        clearAllEnemiesStageConfig,
                        _container.Resolve<EnemiesFactory>(),
                        _container.Resolve<EntitiesLifeContext>());

                case ClearAllWavesStageConfig clearAllWavesStageConfig:
                    return new ClearAllWavesStage(
                        clearAllWavesStageConfig,
                        _container.Resolve<EnemyRandomPointSpawnService>(),
                        _container.Resolve<WaveEnemyCounterService>());

                default:
                    throw new ArgumentException($"Not supported {stageConfig.GetType()} type config");
            }
        }
    }
}
