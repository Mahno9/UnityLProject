using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class TargetTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity>           _contacts;
        private ReactiveVariable<bool>   _isTouchTarget;
        private ReactiveVariable<Entity> _currentTarget;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactEntitiesBuffer;
            _isTouchTarget = entity.IsTouchTarget;
            _currentTarget = entity.CurrentTarget;
        }

        public void OnUpdate(float deltaTime)
        {
            Entity target = _currentTarget.Value;

            if (target == null)
            {
                _isTouchTarget.Value = false;
                return;
            }

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == target)
                {
                    _isTouchTarget.Value = true;
                    return;
                }
            }

            _isTouchTarget.Value = false;
        }
    }
}
