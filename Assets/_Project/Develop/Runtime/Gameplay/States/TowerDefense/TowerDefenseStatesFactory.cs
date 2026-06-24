using System;
using System.Collections.Generic;

using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.Mine;
using _Project.Develop.Runtime.Gameplay.Features.PlayerStructures;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.States;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;

namespace _Project.Develop.Runtime.Gameplay.States.TowerDefense
{
    public class TowerDefenseStatesFactory
    {
        private readonly DIContainer _container;

        public TowerDefenseStatesFactory(DIContainer container)
        {
            _container = container;
        }

        public PreparationState CreatePreparationState()
        {
            return new PreparationState(
                _container.Resolve<MineSpawnService>(),
                _container.Resolve<StartBattleService>());
        }

        public CombatState CreateCombatState()
        {
            return new CombatState(
                _container.Resolve<StageProviderService>(),
                _container.Resolve<PlayerExplosionOnClickService>());
        }

        public VictoryState CreateVictoryState(TowerDefenseInputArgs inputArgs)
        {
            return new VictoryState(
                _container.Resolve<LevelsProgressionService>(),
                inputArgs,
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<LevelConfig>());
        }

        public DefeatState CreateDefeatState(TowerDefenseInputArgs inputArgs)
        {
            return new DefeatState(
                _container.Resolve<LevelsProgressionService>(),
                inputArgs);
        }

        public GameplayStateMachine CreateGameplayStateMachine(TowerDefenseInputArgs inputArgs)
        {
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            EntityTrackingService entityTrackingService = _container.Resolve<EntityTrackingService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopState();

            VictoryState victoryState = CreateVictoryState(inputArgs);
            DefeatState defeatState = CreateDefeatState(inputArgs);

            ICompositeCondition coreLoopToDefeatCondition = new CompositeCondition()
                .Add(new FuncCondition(() => entityTrackingService.IsDead));

            ICompositeCondition coreLoopToVictoryCondition = new CompositeCondition()
                .Add(new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage() == false));

            TowerDefensePhaseService phaseService = _container.Resolve<TowerDefensePhaseService>();

            List<IDisposable> phaseSubscriptions = new()
            {
                victoryState.Entered.Subscribe(() => phaseService.Set(TowerDefensePhase.Victory)),
                defeatState.Entered.Subscribe(() => phaseService.Set(TowerDefensePhase.Defeat)),
            };

            GameplayStateMachine gameplayCycle = new GameplayStateMachine(phaseSubscriptions);

            gameplayCycle.AddState(coreLoopState);
            gameplayCycle.AddState(defeatState);
            gameplayCycle.AddState(victoryState);

            gameplayCycle.AddTransition(coreLoopState, defeatState, coreLoopToDefeatCondition);
            gameplayCycle.AddTransition(coreLoopState, victoryState, coreLoopToVictoryCondition);

            return gameplayCycle;
        }

        public GameplayStateMachine CreateCoreLoopState()
        {
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            StartBattleService startBattleService = _container.Resolve<StartBattleService>();

            PreparationState preparationState = CreatePreparationState();
            CombatState combatState = CreateCombatState();

            ICompositeCondition preparationToCombatCondition = new CompositeCondition()
                .Add(new FuncCondition(() => startBattleService.IsStartRequested.Value))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage()));

            FuncCondition combatToPreparationCondition =
                new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed);

            TowerDefensePhaseService phaseService = _container.Resolve<TowerDefensePhaseService>();

            List<IDisposable> phaseSubscriptions = new()
            {
                preparationState.Entered.Subscribe(() => phaseService.Set(TowerDefensePhase.Preparation)),
                combatState.Entered.Subscribe(() => phaseService.Set(TowerDefensePhase.Combat)),
            };

            GameplayStateMachine coreLoopState = new GameplayStateMachine(phaseSubscriptions);

            coreLoopState.AddState(preparationState);
            coreLoopState.AddState(combatState);

            coreLoopState.AddTransition(preparationState, combatState, preparationToCombatCondition);
            coreLoopState.AddTransition(combatState, preparationState, combatToPreparationCondition);

            return coreLoopState;
        }
    }
}
