using UnityEngine;

namespace Project.Core.Player
{
    public class PlayerPositionController : IPlayerPositionController
    {
        private readonly Transform _playerTransform;
        private readonly CharacterController _characterController;

        public PlayerPositionController(
            Transform playerTransform,
            CharacterController characterController)
        {
            _playerTransform = playerTransform;
            _characterController = characterController;
        }

        public void SetOnPosition(Vector3 position) 
        {
            if (_characterController.enabled == true)
            {
                _characterController.enabled = false;
                _playerTransform.position = position;
                _characterController.enabled = true;
            }
            else
                _playerTransform.position = position;
        }
    }
}