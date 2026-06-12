using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class AreaTargetsEntitiesFilterSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _targets;
        private Buffer<Entity>   _targetsEntities;

        private readonly CollidersRegistryService _collidersRegistryService;

        public AreaTargetsEntitiesFilterSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _targets = entity.TargetsCollidersBuffer;
            _targetsEntities = entity.TargetsEntitiesBuffer;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_targets.Count == 0)
                return;

            _targetsEntities.Count = 0;

            for (int i = 0; i < _targets.Count; i++)
            {
                Collider collider = _targets.Items[i];

                Entity targetEntity = _collidersRegistryService.GetBy(collider);

                if (targetEntity != null)
                {
                    _targetsEntities.Items[_targetsEntities.Count] = targetEntity;
                    _targetsEntities.Count++;
                }
            }

            _targets.Count = 0;
        }
    }
}
