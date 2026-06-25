using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage
{
    public class InstantAreaDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _damage;
        private Buffer<Entity>          _targets;

        public void OnInit(Entity entity)
        {
            _damage = entity.AreaAttackDamage;
            _targets = entity.TargetsEntitiesBuffer;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_targets.Count == 0)
                return;

            for (int i = 0; i < _targets.Count; i++)
            {
                Entity target = _targets.Items[i];
                if (target.HasComponent<TakeDamageRequest>())
                    target.TakeDamageRequest.Invoke(_damage.Value);
            }

            _targets.Count = 0;
        }
    }
}