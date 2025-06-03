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
            GameObject playerGameObject = GameObject.Instantiate(_playerPrefab);

            return new PlayerFactoryData
            {
                PlayerGameObject = playerGameObject,
                PlayerMovement = playerGameObject.GetComponentInChildren<PlayerMovement>(),
                InputController = playerGameObject.GetComponentInChildren<BaseInputController>(),
            };
        }
    }

    public struct PlayerFactoryData
    {
        public GameObject PlayerGameObject;
        public PlayerMovement PlayerMovement;
        public BaseInputController InputController;
    }
}
