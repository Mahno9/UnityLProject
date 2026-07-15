using _Project.Develop.Runtime.Utilities.Reactive;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class DesktopInput : IInputService
    {
        public Vector3 RotationDelta { get; private set; }
        public ReactiveEvent FireEvent     { get; } = new();

        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName   = "Vertical";

        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                return new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
            }
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                FireEvent?.Invoke();

            RotationDelta = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        }
    }
}