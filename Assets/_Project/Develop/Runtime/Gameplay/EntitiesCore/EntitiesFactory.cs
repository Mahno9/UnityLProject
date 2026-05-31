using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Reactive;

using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer         _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
        }

        public Entity CreateTestEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            MonoEntity newEntity = _monoEntitiesFactory.Create(entity, position, R.Prefabs.MovementCharacter);
            Debug.Log($"New entity {newEntity.name} created.");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddRotation(new ReactiveVariable<Quaternion>(Quaternion.identity))
                .AddRotationSpeed(new ReactiveVariable<float>(700))
                ;

            entity.AddSystem(new RigidbodyMovementSystem());
            entity.AddSystem(new AlongMovementRotationSystem());
            entity.AddSystem(new RigidbodyRotationApplierSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}