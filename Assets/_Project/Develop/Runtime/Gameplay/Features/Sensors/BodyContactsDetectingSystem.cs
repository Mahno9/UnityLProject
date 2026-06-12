using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class BodyContactsDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly bool             _excludeSelf;
        private          Buffer<Collider> _contacts;
        private          LayerMask        _mask;
        private          Collider         _body;

        public BodyContactsDetectingSystem(bool excludeSelf = true) => _excludeSelf = excludeSelf;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;
            _body = entity.BodyCollider;
        }

        public void OnUpdate(float deltaTime)
        {
            _contacts.Count = PhysicsUtils.OverlapCollider(_body, _contacts.Items, _mask);

            if (_excludeSelf)
                RemoveSelfFromContacts();

#if UNITY_EDITOR
            DebugDrawUtils.DrawWireCollider(_body, _contacts.Count > 0 ? Color.red : Color.green);
#endif
        }

        private void RemoveSelfFromContacts()
        {
            int idx = -1;
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] != _body)
                    continue;

                idx = i;
                break;
            }

            if (idx < 0)
                return;

            for (int i = idx; i < _contacts.Count - 1; i++)
                _contacts.Items[i] = _contacts.Items[i + 1];

            _contacts.Count--;
        }
    }
}