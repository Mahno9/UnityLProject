using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class CursorMoveAreaService : IInitializable
    {
        public IReadOnlyEvent<Vector3> CursorMoveEvent => _cursorMoveEvent;

        private readonly ReactiveEvent<Vector3> _cursorMoveEvent = new();
        private          Camera                 _camera;

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Update(float _)
        {
            if (_camera is null)
                return;

            Ray   ray         = _camera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float distance))
                _cursorMoveEvent?.Invoke(ray.GetPoint(distance));
        }
    }
}