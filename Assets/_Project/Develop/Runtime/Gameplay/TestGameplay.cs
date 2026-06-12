using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Infrastructure.DI;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer     _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _playerCharacter;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            _playerCharacter = _entitiesFactory.CreateTeleportEnemy("TeleportEnemy", Vector3.zero, 20);

            for (int i = 0; i < 1; i++)
                _entitiesFactory.CreateGhost(
                    "Ghost " + (i + 1),
                    new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5))
                );

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerCharacter.TeleportRequest.Invoke();
            }
        }
    }
}