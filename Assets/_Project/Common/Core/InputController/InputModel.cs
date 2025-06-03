using UnityEngine;

namespace Project.Core.InputController
{
    public class InputModel : IInputModel, IInputModelController
    {
        public Vector2 Axis { get; private set; }

        public void SetAxis(Vector2 axis) =>
            Axis = axis;
    }
}