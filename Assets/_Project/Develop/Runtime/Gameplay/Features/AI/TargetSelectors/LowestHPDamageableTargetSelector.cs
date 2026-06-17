using System.Collections.Generic;
using System.Linq;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Utilities.Conditions;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class LowestHPDamageableTargetSelector : ITargetSelector
    {
        private readonly Entity    _source;

        public LowestHPDamageableTargetSelector(Entity entity)
        {
            _source = entity;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<TakeDamageRequest>();

                if(target.TryGetCanApplyDamage(out ICompositeCondition canApplyDamage))
                    result = result && canApplyDamage.Evaluate();

                result = result && (target != _source);

                return result;
            });

            IEnumerable<Entity> enumerable = selectedTargets as Entity[] ?? selectedTargets.ToArray();
            if (enumerable.Any() == false)
                return null;

            Entity resultTarget = enumerable.First();
            float  minHealth    = resultTarget.CurrentHealth.Value;

            foreach (Entity target in enumerable)
            {
                float currentHealth = resultTarget.CurrentHealth.Value;

                if(currentHealth < minHealth)
                {
                    minHealth = currentHealth;
                    resultTarget = target;
                }
            }

            return resultTarget;
        }
    }
}