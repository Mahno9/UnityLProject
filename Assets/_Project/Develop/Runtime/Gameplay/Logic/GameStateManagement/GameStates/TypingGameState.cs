using System;

using _Project.Develop.Runtime.Configs.Meta.Progression;
using _Project.Develop.Runtime.Gameplay.Logic.KeyInputManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringMatchingManagement;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;

namespace _Project.Develop.Runtime.Gameplay.Logic.GameStateManagement
{
    public class TypingGameState : IGameState
    {
        private readonly GameStateService     _gameStateService;
        private readonly TypingInputService   _inputService;
        private readonly StringMatcherService _matcherService;

        private readonly StatisticService  _statisticService;
        private readonly WaitForKeyService _waitForKeyService;
        private readonly WalletService     _walletService;
        private readonly ProgressionConfig _progressionConfig;

        private IDisposable _typeSubscription;

        public TypingGameState(
            GameStateService gameStateService,
            TypingInputService inputService,
            StringMatcherService matcherService)
        {
            _gameStateService = gameStateService;
            _inputService = inputService;
            _matcherService = matcherService;
        }

        public void OnEnter()
        {
            _typeSubscription = _inputService.TypeString.Subscribe(OnPlayerInput);
        }

        public void OnExit()
        {
            _typeSubscription.Dispose();
        }

        public void Update()
        {
            _inputService.Update();
        }

        private void OnPlayerInput(string _, string typedString)
        {
            CompareResultType result = _matcherService.MatchString(typedString);

            Type stateToChange = null;

            switch (result)
            {
                case CompareResultType.FullMatch:
                    stateToChange = typeof(WinGameState);
                    break;

                case CompareResultType.PartMatch:
                    break;

                case CompareResultType.MissMatch:
                    stateToChange = typeof(LoseGameState);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (stateToChange is not null)
                _gameStateService.SetState(stateToChange);
        }
    }
}