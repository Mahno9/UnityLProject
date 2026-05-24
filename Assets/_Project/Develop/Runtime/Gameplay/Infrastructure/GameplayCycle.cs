using System;

using _Project.Develop.Runtime.Gameplay.Logic.GameStateManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle : IDisposable
    {
        private readonly GameStateService     _gameStateService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private Coroutine _gameplayCycleCoroutine;

        public GameplayCycle(GameStateService gameStateService, ICoroutinesPerformer coroutinesPerformer)
        {
            _gameStateService = gameStateService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Start()
        {
            _gameplayCycleCoroutine = _coroutinesPerformer.StartPerform(_gameStateService.Update());
        }

        public void Dispose()
        {
            _coroutinesPerformer.StopPerform(_gameplayCycleCoroutine);
        }
    }
}