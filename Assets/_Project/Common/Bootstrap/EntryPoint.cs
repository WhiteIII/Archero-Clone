using Project.Configs;
using Project.Core.InputController;
using Project.Core.Services;
using Zenject;

namespace Project.Bootstrap
{
    public class EntryPoint : IInitializable
    {
        private readonly PlayerData _playerData;
        private readonly PlayerFactory _playerFactory;

        public EntryPoint(
            PlayerFactory playerFactory, 
            PlayerData playerData)
        {
            _playerData = playerData;
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            InputFactory inputFactory;
            
            PlayerFactoryData playerFactoryData = _playerFactory.Create();
            inputFactory = new InputFactory(playerFactoryData.InputController);

            FactoryInputData factoryInputData = inputFactory.Create();
            
            playerFactoryData.InputController.Initialize(
                new InputControllerInitializeData 
                { 
                    InputModelController = factoryInputData.InputModelController,
                    Inputs = factoryInputData.Inputs,
                });
            playerFactoryData.PlayerMovement.Initialize(factoryInputData.InputModel, _playerData.Speed);
            playerFactoryData.PlayerStateController.Initialize();
            playerFactoryData.PlayerPositionController.SetOnPosition(_playerData.GameplaySpawnPointPosition);
        }
    }
}
