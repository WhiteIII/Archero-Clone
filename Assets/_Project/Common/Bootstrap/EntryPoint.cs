using Project.Configs;
using Project.Core.InputController;
using Project.Core.Services;
using UnityEngine;
using Zenject;

namespace Project.Bootstrap
{
    public class EntryPoint : IInitializable
    {
        private readonly GameObject _playerPrefab;
        private readonly PlayerData _playerData;

        public EntryPoint(
            PlayerEntryPointData playerEntryPointData)
        {
            _playerPrefab = playerEntryPointData.PlayerPrefab;
            _playerData = playerEntryPointData.PlayerData;
        }

        public void Initialize()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            PlayerFactory playerFactory = new(_playerPrefab);
            InputFactory inputFactory;
            
            PlayerFactoryData playerFactoryData = playerFactory.Create();
            inputFactory = new InputFactory(playerFactoryData.InputController);

            FactoryInputData factoryInputData = inputFactory.Create();
            
            playerFactoryData.InputController.Initialize(
                new InputControllerInitializeData 
                { 
                    InputModelController = factoryInputData.InputModelController,
                    Inputs = factoryInputData.Inputs,
                });
            playerFactoryData.PlayerMovement.Initialize(factoryInputData.InputModel, _playerData.Speed);
        }
    }

    public struct PlayerEntryPointData
    {
        public GameObject PlayerPrefab;
        public PlayerData PlayerData;
    }
}
