using Project.Core.Services;
using Zenject;
using UnityEngine;
using Project.Core.InputController;
using Project.Core.Player.AttackSystem;

namespace Project.Core.Player
{
    public class PlayerActiveController : IInitializable
    {
        private readonly IActivatedAndDeactivatedObject _playerInput;
        private readonly GameObject _playerGameObject;

        public bool IsActive { get; private set; } = false;
        public bool InputMovementActive { get; private set; } = false;

        public PlayerActiveController(
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

    public class ShootingController : ITickable, IActivatedAndDeactivatedObject
    {
        private readonly IInputModel _inputModel;
        private readonly IArrowSpawnerController _arrowSpawnerController;

        private bool _isActive = false;

        public ShootingController(
            IInputModel inputModel,
            IArrowSpawnerController arrowSpawnerController)
        {
            _inputModel = inputModel;
            _arrowSpawnerController = arrowSpawnerController;
        }

        public void Activate() =>
            _isActive = true;

        public void Deactivate() => 
            _isActive = false;
        
        public void Tick()
        {
            if (_isActive == false)
                return;
            
            if (_inputModel.Axis.x > 0 || _inputModel.Axis.y > 0)
            {
                if (_arrowSpawnerController.IsActive == true)
                    _arrowSpawnerController.StopShooting();
            }
            else
            {
                if (_arrowSpawnerController.IsActive == false)
                    _arrowSpawnerController.StartShooting();
            }
        }
    }
}