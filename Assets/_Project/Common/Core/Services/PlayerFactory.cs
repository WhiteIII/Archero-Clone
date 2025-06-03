using Project.Core.Player;
using Project.Core.InputController;
using UnityEngine;

namespace Project.Core.Services
{
    public class PlayerFactory : IFactory<PlayerFactoryData>
    {
        private readonly GameObject _playerPrefab;

        public PlayerFactory(GameObject playerPrefab) =>
            _playerPrefab = playerPrefab;

        public PlayerFactoryData Create()
        {
            PlayerComponents playerComponents;
            GameObject playerGameObject = GameObject.Instantiate(_playerPrefab);
            GameObject.DontDestroyOnLoad(playerGameObject);
            playerGameObject.transform.SetParent(null);
            playerComponents = playerGameObject.GetComponentInChildren<PlayerComponents>();

            return new PlayerFactoryData
            {
                PlayerGameObject = playerGameObject,
                PlayerMovement = playerGameObject.GetComponentInChildren<PlayerMovement>(),
                InputController = playerGameObject.GetComponentInChildren<BaseInputController>(),
                PlayerStateController = new PlayerStateController(
                    playerGameObject.GetComponentInChildren<BaseInputController>(),
                    playerGameObject,
                    true,
                    true),
                PlayerPositionController = new PlayerPositionController(
                    playerGameObject.transform,
                    playerComponents.CharacterController),
                PlayerCameraPositionHandler = new PlayerCameraPositionHandler(playerComponents.CameraPointTransform)
            };
        }
    }

    public struct PlayerFactoryData
    {
        public GameObject PlayerGameObject;
        public PlayerMovement PlayerMovement;
        public BaseInputController InputController;
        public PlayerStateController PlayerStateController;
        public IPlayerPositionController PlayerPositionController;
        public IPlayerCameraPositionHandler PlayerCameraPositionHandler;
    }
}
