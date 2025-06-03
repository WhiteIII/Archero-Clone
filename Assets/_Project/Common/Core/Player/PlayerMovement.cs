using Project.Core.InputController;
using UnityEngine;
using static UnityEngine.Time;

namespace Project.Core.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        private IInputModel _inputModel;
        private float _movementSpeed;

        public void Initialize(
            IInputModel inputModel,
            float movementSpeed)
        {
            _inputModel = inputModel;
            _movementSpeed = movementSpeed;
        }

        private void FixedUpdate() =>
            Move();

        public void SetSpeed(float movementSpeed) =>
            _movementSpeed = movementSpeed;

        private void Move() =>
            _characterController.Move(_inputModel.Axis * _movementSpeed * deltaTime);
    }
}
