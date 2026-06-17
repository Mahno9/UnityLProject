using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.AI;
using _Project.Develop.Runtime.Infrastructure.DI;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer     _container;
        private EntitiesFactory _entitiesFactory;
        private BrainsFactory   _brainsFactory;

        private Entity _playerCharacter;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
        }

        public void Run()
        {
            _playerCharacter = _entitiesFactory.CreateHero(Vector3.zero);

            Entity teleporter = _entitiesFactory.CreateTeleportEnemy("TeleportEnemy", Vector3.left * 2, 20);
            _brainsFactory.CreateTeleporterBrain(teleporter);

            const int   n         = 3;
            const float range     = 10;
            const float halfRange = range / 2;

            for (int i = 0; i < n; i++)
                _entitiesFactory.CreateGhost(
                    "Ghost " + (i + 1),
                    new Vector3((i + 1) * (range / n) - halfRange, 0, 4)
                );

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     _playerCharacter.TeleportRequest.Invoke();
            // }
        }
    }
}