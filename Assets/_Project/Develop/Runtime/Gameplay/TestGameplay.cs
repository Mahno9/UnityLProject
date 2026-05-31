using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _rigidbodyEntity;
        private Entity _ccEntity;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            _rigidbodyEntity = _entitiesFactory.CreateRigidbodyTestEntity(new Vector3(3, 0, 0));
            _ccEntity        = _entitiesFactory.CreateCharacterControllerTestEntity(new Vector3(-3, 0, 0));

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            _rigidbodyEntity.MoveDirection.Value = input;
            _ccEntity.MoveDirection.Value        = input;
        }
    }
}
