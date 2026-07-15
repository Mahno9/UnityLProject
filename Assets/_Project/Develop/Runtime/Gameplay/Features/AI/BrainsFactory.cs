using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.AI.States;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.Timer;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer         _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext     _brainsContext;
        private readonly IInputService       _inputService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _inputService = _container.Resolve<IInputService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public StateMachineBrain CreateTeleporterBrain(Entity entity)
        {
            AIStateMachine defaultBehaviour     = CreateDefaultTeleporterBehaviour(entity);
            AIStateMachine intelligentBehaviour = CreateIntelligentTeleporterBehaviour(entity);

            // Root
            AIStateMachine rootStateMachine = new();
            rootStateMachine.AddState(defaultBehaviour);
            rootStateMachine.AddState(intelligentBehaviour);

            rootStateMachine.AddTransition(defaultBehaviour, intelligentBehaviour, new FuncCondition(()
                => entity.TeleporterBehaviourVariant.Value == TeleporterBehaviourVariants.LowestHpOn40PlusEnergyTeleportation));
            rootStateMachine.AddTransition(intelligentBehaviour, defaultBehaviour, new FuncCondition(()
                => entity.TeleporterBehaviourVariant.Value == TeleporterBehaviourVariants.RandomTeleportation));

            StateMachineBrain brain = new(rootStateMachine);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateMainHeroManualCombatBrain(Entity entity)
        {
            PlayerInputMovementState movementState = new(entity, _inputService);
            PlayerManualAimingState  aimingState   = new(entity, _inputService);
            EmptyState               attackState   = new();

            AIStateMachine behaviour = new();
            behaviour.AddStates(movementState, aimingState, attackState);

            behaviour.AddTransition(movementState, aimingState, new FuncCondition(() => _inputService.Direction == Vector3.zero));
            behaviour.AddTransition(aimingState, movementState, new FuncCondition(() => _inputService.Direction != Vector3.zero));
            behaviour.AddTransition(aimingState, attackState, new FuncCondition(() => entity.InAttackProcess.Value));
            behaviour.AddTransition(attackState, aimingState, new FuncCondition(() => entity.InAttackProcess.Value == false));
            behaviour.AddTransition(attackState, movementState, new FuncCondition(() => _inputService.Direction != Vector3.zero));

            StateMachineBrain brain = new(behaviour);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine combatState = CreateAutoAttackStateMachine(entity);

            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromMovementToCombatStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => currentTarget.Value != null))
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));

            ICompositeCondition fromCombatToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => currentTarget.Value == null))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState, combatState, fromMovementToCombatStateCondition);
            behaviour.AddTransition(combatState, movementState, fromCombatToMovementStateCondition);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIParallelState parallelState   = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateGhostBrain(Entity entity)
        {
            AIStateMachine    stateMachine = CreateRandomMovementStateMachine(entity);
            StateMachineBrain brain        = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateZombieBrain(Entity entity)
        {
            FindTargetState findTargetState = new FindTargetState(
                new NearestDamageableTargetSelector(entity), _entitiesLifeContext, entity);

            MoveToTargetState moveToTargetState = new MoveToTargetState(entity);

            AIParallelState parallelState = new AIParallelState(findTargetState, moveToTargetState);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        // To the lowest HP on 40+ energy
        private AIStateMachine CreateIntelligentTeleporterBehaviour(Entity entity)
        {
            AIStateMachine behaviour = new();

            TeleportToTargetState teleportState      = new(entity);
            TeleportCooldownState cooldownState      = new(entity);
            EmptyState            restoreEnergyState = new();
            FindTargetState       findTargetState    = new(new LowestHPDamageableTargetSelector(entity), _entitiesLifeContext, entity);
            behaviour.AddStates(findTargetState, teleportState, cooldownState, restoreEnergyState);

            behaviour.AddTransition(teleportState, cooldownState, entity.TeleportDoneEvent);
            behaviour.AddTransition(cooldownState, restoreEnergyState, entity.TeleportCooldownDoneEvent);
            behaviour.AddTransition(restoreEnergyState, findTargetState, new FuncCondition(() => entity.Energy.Value >= 40));
            behaviour.AddTransition(findTargetState, restoreEnergyState, new FuncCondition(() => entity.Energy.Value < 40));
            behaviour.AddTransition(findTargetState, teleportState, new FuncCondition(() => entity.CurrentTarget.Value != null));

            return behaviour;
        }

        private static AIStateMachine CreateDefaultTeleporterBehaviour(Entity entity)
        {
            AIStateMachine behaviour = new();

            TeleportCooldownState cooldownState   = new(entity);
            RandomTeleportState   teleporterState = new(entity);
            behaviour.AddState(cooldownState);
            behaviour.AddState(teleporterState);

            behaviour.AddTransition(cooldownState, teleporterState, entity.TeleportCooldownDoneEvent);
            behaviour.AddTransition(teleporterState, cooldownState, entity.TeleportDoneEvent);

            return behaviour;
        }

        private AIStateMachine CreateRandomMovementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            RandomMovementState randomMovementState = new RandomMovementState(entity, 0.5f);

            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subscribe(movementTimer.Restart));

            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            FuncCondition movementTimerEndedCondition = new FuncCondition(() => movementTimer.IsOver);
            FuncCondition idleTimerEndedCondition     = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(randomMovementState);
            stateMachine.AddState(emptyState);

            stateMachine.AddTransition(randomMovementState, emptyState, movementTimerEndedCondition);
            stateMachine.AddTransition(emptyState, randomMovementState, idleTimerEndedCondition);

            return stateMachine;
        }

        private AIStateMachine CreateAutoAttackStateMachine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);

            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition               canAttack     = entity.CanStartAttack;
            Transform                transform     = entity.Transform;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angleToTarget = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.Transform.position - transform.position));
                    return angleToTarget < 1f;
                }));

            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(rotateToTargetState);
            stateMachine.AddState(attackTriggerState);

            stateMachine.AddTransition(rotateToTargetState, attackTriggerState, fromRotateToAttackCondition);
            stateMachine.AddTransition(attackTriggerState, rotateToTargetState, fromAttackToRotateStateCondition);

            return stateMachine;
        }
    }
}