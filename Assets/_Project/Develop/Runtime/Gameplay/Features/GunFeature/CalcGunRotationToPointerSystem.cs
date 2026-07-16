using System;

using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.Features.InputFeature;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class CalcGunRotationToPointerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private IDisposable               _cursorMoveSubscription;

        private readonly CursorMoveAreaService _cursorMoveAreaService;
        private          Transform             _gun;

        public CalcGunRotationToPointerSystem(CursorMoveAreaService cursorMoveAreaService)
        {
            _cursorMoveAreaService = cursorMoveAreaService;
        }

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.GunRotationDirection;
            _gun = entity.GunTransform;

            _cursorMoveSubscription = _cursorMoveAreaService.CursorMoveEvent.Subscribe(OnCursorMoved);
        }

        public void OnDispose()
        {
            _cursorMoveSubscription.Dispose();
        }

        private void OnCursorMoved(Vector3 pointer)
        {
            _rotationDirection.Value = (pointer - _gun.position).normalized;
        }
    }
}