using _Project.Develop.Runtime.Configs.Gameplay.Entities;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.PlayerStructures
{
    public class PlayerStructuresFactory
    {
        private readonly DIContainer            _container;
        private readonly EntitiesFactory        _entitiesFactory;
        private readonly EntitiesLifeContext    _entitiesLifeContext;
        private readonly ExplosionFactory       _explosionFactory;
        private readonly ConfigsProviderService _configsProviderService;

        public PlayerStructuresFactory(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _explosionFactory = _container.Resolve<ExplosionFactory>();
            _configsProviderService = _container.Resolve<ConfigsProviderService>();
        }

        public Entity CreateTower(Vector3 position)
        {
            TowerConfig config = _configsProviderService.GetConfig<TowerConfig>();

            Entity entity = _entitiesFactory.CreateTower(position, config);

            entity.AddTeam(new ReactiveVariable<Teams>(Teams.Player));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateMine(Vector3 position)
        {
            MineConfig config = _configsProviderService.GetConfig<MineConfig>();

            Entity entity = _entitiesFactory.CreateMine(position, config);

            entity.AddTeam(new ReactiveVariable<Teams>(Teams.Player));

            entity.AddSystem(new SpawnExplosionOnDeathSystem(
                _explosionFactory,
                config.ExplosionDamage,
                () => true));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}
