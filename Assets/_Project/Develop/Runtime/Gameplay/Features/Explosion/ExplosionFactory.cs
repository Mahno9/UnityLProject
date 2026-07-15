using _Project.Develop.Runtime.Configs.Gameplay.Entities;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Explosion
{
    public class ExplosionFactory
    {
        private readonly EntitiesFactory        _entitiesFactory;
        private readonly EntitiesLifeContext    _entitiesLifeContext;
        private readonly ConfigsProviderService _configsProviderService;

        public ExplosionFactory(DIContainer container)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
            _configsProviderService = container.Resolve<ConfigsProviderService>();
        }

        public Entity Create(Vector3 position, float damage, Teams team)
        {
            ExplosionConfig config = _configsProviderService.GetConfig<ExplosionConfig>();

            Entity entity = _entitiesFactory.CreateExplosion(position, damage, config);

            entity.AddTeam(new ReactiveVariable<Teams>(team));

            _entitiesLifeContext.Add(entity);

            entity.AreaTargetsCollectRequest.Invoke();

            return entity;
        }
    }
}
