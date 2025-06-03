using Project.Core.Services;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Core.Player
{
    public class PlayerStateController : IInitializable
    {
        private readonly IActivatedAndDeactivatedObject _playerInput;
        private readonly GameObject _playerGameObject;

        public bool IsActive { get; private set; } = false;
        public bool InputMovementActive { get; private set; } = false;

        public PlayerStateController(
            IActivatedAndDeactivatedObject playerInput,
            GameObject playerGameObject,
            bool isActive,
            bool inputMovementActive)
        {
            _playerInput = playerInput;
            _playerGameObject = playerGameObject;
            IsActive = isActive;
            InputMovementActive = inputMovementActive;
        }

        public void Initialize()
        {
            if (InputMovementActive)
                _playerInput.Activate();
            else
                _playerInput.Deactivate();

            if (IsActive)
                _playerGameObject.SetActive(true);
            else
                _playerGameObject.SetActive(false);
        }

        public void ActivateMoveInput()
        {
            _playerInput.Activate();
            InputMovementActive = true;
        }

        public void DeactivateMoveInput()
        {
            _playerInput.Deactivate();
            InputMovementActive = false;
        }

        public void ActivateGameObject()
        {
            IsActive = true;
            _playerGameObject.SetActive(true);
        }

        public void DeactivateGameObject()
        {
            IsActive = true;
            _playerGameObject.SetActive(false);
        }
    }
}