using Project.Core.Player;
using Project.Core.InputController;
using UnityEngine;
using Project.Core.Player.AttackSystem;
using Project.Core.Enemy;

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
                PlayerStateController = new PlayerActiveController(
                    playerGameObject.GetComponentInChildren<BaseInputController>(),
                    playerGameObject,
                    true,
                    true),
                PlayerPositionController = new PlayerPositionController(
                    playerGameObject.transform,
                    playerComponents.CharacterController),
                PlayerCameraPositionHandler = new PlayerCameraPositionHandler(playerComponents.CameraPointTransform),
                AttackController = playerComponents.AttackController,
                ArrowSpawnPoint = playerComponents.ArrowSpawnPoint,
                AttackControllerInitialize = playerComponents.AttackController,
            };
        }
    }

    public struct PlayerFactoryData
    {
        public GameObject PlayerGameObject;
        public PlayerMovement PlayerMovement;
        public BaseInputController InputController;
        public PlayerActiveController PlayerStateController;
        public IAttackController AttackController;
        public IPlayerPositionController PlayerPositionController;
        public IPlayerCameraPositionHandler PlayerCameraPositionHandler;
        public IInitializable<IRepository<IEnemyWithHealth>> AttackControllerInitialize;
        public Transform ArrowSpawnPoint;
    }
}
