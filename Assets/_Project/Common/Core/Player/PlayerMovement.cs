using Project.Core.InputController;
using UnityEngine;
using static UnityEngine.Time;

namespace Project.Core.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _playerTransform;

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
            _characterController.Move(
                (_playerTransform.right * _inputModel.Axis.x
                + _playerTransform.forward * _inputModel.Axis.y)
                * _movementSpeed
                * deltaTime);
    }
}