namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public bool TryGetContactCollidersBuffer(out _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer(out _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaAttackCollider AreaAttackColliderC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.AreaAttackCollider>();

		public UnityEngine.Collider AreaAttackCollider => AreaAttackColliderC.Value;

		public bool TryGetAreaAttackCollider(out UnityEngine.Collider value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaAttackCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Collider);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaAttackCollider(UnityEngine.Collider value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaAttackCollider() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsDetectingMask TargetsDetectingMaskC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsDetectingMask>();

		public UnityEngine.LayerMask TargetsDetectingMask => TargetsDetectingMaskC.Value;

		public bool TryGetTargetsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTargetsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsDetectingMask() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsCollidersBuffer TargetsCollidersBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsCollidersBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> TargetsCollidersBuffer => TargetsCollidersBufferC.Value;

		public bool TryGetTargetsCollidersBuffer(out _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTargetsCollidersBuffer(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsCollidersBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsEntitiesBuffer TargetsEntitiesBufferC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsEntitiesBuffer>();

		public _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> TargetsEntitiesBuffer => TargetsEntitiesBufferC.Value;

		public bool TryGetTargetsEntitiesBuffer(out _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTargetsEntitiesBuffer(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.TargetsEntitiesBuffer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaTargetsCollectRequest AreaTargetsCollectRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.AreaTargetsCollectRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AreaTargetsCollectRequest => AreaTargetsCollectRequestC.Value;

		public bool TryGetAreaTargetsCollectRequest(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaTargetsCollectRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaTargetsCollectRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaTargetsCollectRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaTargetsCollectRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.AreaTargetsCollectRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.RotationFeature.Rotation RotationC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.RotationFeature.Rotation>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion> Rotation => RotationC.Value;

		public bool TryGetRotation(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.RotationFeature.Rotation component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion>);
			return result;
		}

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

		public bool TryGetRotationSpeed(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Naming.Name NameC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Naming.Name>();

		public System.String Name => NameC.Value;

		public bool TryGetName(out System.String value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Naming.Name component);
			if(result)
				value = component.Value;
			else
				value = default(System.String);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddName(System.String value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Naming.Name() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

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

		public bool TryGetMoveSpeed(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetIsMoving(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetCanMove(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate CanRotateC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportRadius TeleportRadiusC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportRadius>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleportRadius => TeleportRadiusC.Value;

		public bool TryGetTeleportRadius(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportRadius component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportRadius()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportRadius() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportRadius(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportRadius() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RandomTeleportRequest RandomTeleportRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.RandomTeleportRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent RandomTeleportRequest => RandomTeleportRequestC.Value;

		public bool TryGetRandomTeleportRequest(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RandomTeleportRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRandomTeleportRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RandomTeleportRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRandomTeleportRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RandomTeleportRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportToTargetRequest TeleportToTargetRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportToTargetRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportToTargetRequest => TeleportToTargetRequestC.Value;

		public bool TryGetTeleportToTargetRequest(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportToTargetRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportToTargetRequest()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportToTargetRequest() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportToTargetRequest(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportToTargetRequest() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportPlannedEvent TeleportPlannedEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportPlannedEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportPlannedEvent => TeleportPlannedEventC.Value;

		public bool TryGetTeleportPlannedEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportPlannedEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportPlannedEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportPlannedEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportPlannedEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportPlannedEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportDoneEvent TeleportDoneEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportDoneEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportDoneEvent => TeleportDoneEventC.Value;

		public bool TryGetTeleportDoneEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportDoneEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportDoneEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportDoneEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportDoneEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportDoneEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.PreviousBodyPosition PreviousBodyPositionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.PreviousBodyPosition>();

		public UnityEngine.Vector3 PreviousBodyPosition => PreviousBodyPositionC.Value;

		public bool TryGetPreviousBodyPosition(out UnityEngine.Vector3 value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.PreviousBodyPosition component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Vector3);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddPreviousBodyPosition(UnityEngine.Vector3 value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.PreviousBodyPosition() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportEnergyCost TeleportEnergyCostC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportEnergyCost>();

		public System.Int32 TeleportEnergyCost => TeleportEnergyCostC.Value;

		public bool TryGetTeleportEnergyCost(out System.Int32 value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportEnergyCost component);
			if(result)
				value = component.Value;
			else
				value = default(System.Int32);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportEnergyCost(System.Int32 value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportEnergyCost() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.InitialTeleportCooldownTimer InitialTeleportCooldownTimerC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.InitialTeleportCooldownTimer>();

		public System.Single InitialTeleportCooldownTimer => InitialTeleportCooldownTimerC.Value;

		public bool TryGetInitialTeleportCooldownTimer(out System.Single value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.InitialTeleportCooldownTimer component);
			if(result)
				value = component.Value;
			else
				value = default(System.Single);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInitialTeleportCooldownTimer(System.Single value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.InitialTeleportCooldownTimer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownTimer TeleportCooldownTimerC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownTimer>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleportCooldownTimer => TeleportCooldownTimerC.Value;

		public bool TryGetTeleportCooldownTimer(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownTimer component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownTimer()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownTimer() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownTimer(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownTimer() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownDoneEvent TeleportCooldownDoneEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownDoneEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportCooldownDoneEvent => TeleportCooldownDoneEventC.Value;

		public bool TryGetTeleportCooldownDoneEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownDoneEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownDoneEvent()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownDoneEvent() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCooldownDoneEvent(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.TeleportCooldownDoneEvent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanTeleportToTarget CanTeleportToTargetC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanTeleportToTarget>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanTeleportToTarget => CanTeleportToTargetC.Value;

		public bool TryGetCanTeleportToTarget(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanTeleportToTarget component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanTeleportToTarget(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanTeleportToTarget() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetMaxHealth(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetIsDead(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetMustDie(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetDeathProcessCurrentTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetInDeathProcess(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() { Value = new System.Collections.Generic.List<UnityEngine.Collider>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.Energy EnergyC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.Energy>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> Energy => EnergyC.Value;

		public bool TryGetEnergy(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Energy.Energy component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergy()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.Energy() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergy(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.Energy() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.InitialEnergy InitialEnergyC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.InitialEnergy>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> InitialEnergy => InitialEnergyC.Value;

		public bool TryGetInitialEnergy(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Energy.InitialEnergy component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInitialEnergy()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.InitialEnergy() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInitialEnergy(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.InitialEnergy() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenerateCooldown EnergyRegenerateCooldownC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenerateCooldown>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyRegenerateCooldown => EnergyRegenerateCooldownC.Value;

		public bool TryGetEnergyRegenerateCooldown(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenerateCooldown component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenerateCooldown()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenerateCooldown() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRegenerateCooldown(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.EnergyRegenerateCooldown() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Energy.RestTimeToEnergyRegenerate RestTimeToEnergyRegenerateC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Energy.RestTimeToEnergyRegenerate>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RestTimeToEnergyRegenerate => RestTimeToEnergyRegenerateC.Value;

		public bool TryGetRestTimeToEnergyRegenerate(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Energy.RestTimeToEnergyRegenerate component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRestTimeToEnergyRegenerate()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.RestTimeToEnergyRegenerate() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRestTimeToEnergyRegenerate(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Energy.RestTimeToEnergyRegenerate() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetStartAttackRequest(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetStartAttackEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetCanStartAttack(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetAttackProcessInitialTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetAttackProcessCurrentTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetInAttackProcess(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetAttackDelayTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetAttackDelayEndEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetInstantAttackDamage(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack>();

		public _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public bool TryGetMustCancelAttack(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCancelAttack(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent AttackCanceledEventC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackCanceledEvent => AttackCanceledEventC.Value;

		public bool TryGetAttackCanceledEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

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

		public bool TryGetAttackCooldownInitialTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetAttackCooldownCurrentTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetInAttackCooldown(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage.AreaAttackDamage AreaAttackDamageC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage.AreaAttackDamage>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AreaAttackDamage => AreaAttackDamageC.Value;

		public bool TryGetAreaAttackDamage(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage.AreaAttackDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaAttackDamage()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage.AreaAttackDamage() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaAttackDamage(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Attack.AreaDamage.AreaAttackDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

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

		public bool TryGetTakeDamageEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

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

		public bool TryGetCanApplyDamage(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget CurrentTargetC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariant TeleporterBehaviourVariantC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariant>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariants> TeleporterBehaviourVariant => TeleporterBehaviourVariantC.Value;

		public bool TryGetTeleporterBehaviourVariant(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariants> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariant component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariants>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleporterBehaviourVariant()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariant() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariants>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleporterBehaviourVariant(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariants> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AI.TeleporterBehaviourVariant() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public bool TryGetCharacterController(out UnityEngine.CharacterController value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CharacterController);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<_Project.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Common.TransformComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Common.TransformComponent() {Value = value}); 
		}

	}
}
