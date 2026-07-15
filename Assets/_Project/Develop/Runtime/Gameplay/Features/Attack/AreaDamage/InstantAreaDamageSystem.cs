using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage
{
    public class InstantAreaDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _damage;
        private Buffer<Entity>          _targets;
        private Entity                  _source;

        public void OnInit(Entity entity)
        {
            _damage = entity.AreaAttackDamage;
            _targets = entity.TargetsEntitiesBuffer;
            _source = entity;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_targets.Count == 0)
                return;

            for (int i = 0; i < _targets.Count; i++)
            {
                Entity target = _targets.Items[i];
                EntitiesHelper.TryTakeDamageFrom(_source, target, _damage.Value);
            }

            _targets.Count = 0;
        }
    }
}