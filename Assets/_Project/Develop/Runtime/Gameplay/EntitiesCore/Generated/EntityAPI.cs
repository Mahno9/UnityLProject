namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.RotationFeature.Rotation RotationC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.RotationFeature.Rotation>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion> Rotation => RotationC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotation()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.Rotation() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotation(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.Rotation() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed RotationSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving IsMovingC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate CanRotateC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() { Value = new System.Collections.Generic.List<UnityEngine.Collider>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCancelAttack(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent AttackCanceledEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackCanceledEvent => AttackCanceledEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

	}
}
