using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Gameplay.Features.Explosion;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.Mine;
using _Project.Develop.Runtime.Gameplay.Features.PlayerStructures;
using _Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.States;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

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
                _container.Resolve<ClickAreaService>(),
                _container.Resolve<LevelsProgressionService>(),
                inputArgs,
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<LevelConfig>());
        }

        public DefeatState CreateDefeatState(TowerDefenseInputArgs inputArgs)
        {
            return new DefeatState(
                _container.Resolve<ClickAreaService>(),
                _container.Resolve<LevelsProgressionService>(),
                inputArgs,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
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

            GameplayStateMachine gameplayCycle = new GameplayStateMachine();

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

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(preparationState);
            coreLoopState.AddState(combatState);

            coreLoopState.AddTransition(preparationState, combatState, preparationToCombatCondition);
            coreLoopState.AddTransition(combatState, preparationState, combatToPreparationCondition);

            return coreLoopState;
        }
    }
}
