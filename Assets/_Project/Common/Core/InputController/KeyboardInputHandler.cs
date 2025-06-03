using UnityEngine;

namespace Project.Core.InputController
{
    public class KeyboardInputHandler : IInput
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        public Vector2 GetAxis() =>
            new(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));
    }
}