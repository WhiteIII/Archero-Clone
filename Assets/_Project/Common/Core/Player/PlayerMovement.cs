using Project.Core.InputController;
using Project.Core.Player.AttackSystem;
using UnityEngine;
using static UnityEngine.Time;

namespace Project.Core.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _playerTransform;

        private IInputModel _inputModel;
        private IPlayerStats _playerStats;

        public void Initialize(
            IInputModel inputModel,
            IPlayerStats playerStats)
        {
            _inputModel = inputModel;
            _playerStats = playerStats;
        }

        private void FixedUpdate() =>
            Move();

        private void Move() =>
            _characterController.Move(
                (_playerTransform.right * _inputModel.Axis.x
                + _playerTransform.forward * _inputModel.Axis.y)
                * _playerStats.MovementSpeed
                * deltaTime);
    }
}