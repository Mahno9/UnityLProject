using System;

using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    // Определяет клик по игровому полю: ЛКМ -> точка пересечения луча с землёй (Y=0).
    // Вынесено из MovingGameplayBootstrap. Гоняется из бутстрапа каждый кадр.
    public class ClickAreaService : IInitializable
    {
        public IReadOnlyEvent<Vector3> Clicked => _clickedEvent;

        private readonly ReactiveEvent<Vector3> _clickedEvent = new();
        private          Camera                 _camera;

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Update(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0) == false)
                return;

            if (EventSystem.current is not null && EventSystem.current.IsPointerOverGameObject())
                return;

            if (_camera is null)
                return;

            Ray   ray         = _camera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float distance))
                _clickedEvent?.Invoke(ray.GetPoint(distance));
        }
    }
}