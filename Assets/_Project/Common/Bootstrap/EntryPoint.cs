using System;
using Project.Configs;
using Project.Core.Enemy;
using Project.Core.GameCycle;
using Project.Core.InputController;
using Project.Core.Player;
using Project.Core.Player.AttackSystem;
using Project.Core.RuleBasedAi;
using Project.Core.Services;
using UnityEngine;
using Zenject;

namespace Project.Bootstrap
{
    public class EntryPoint : IInitializable, IDisposable
    {
        private readonly PlayerData _playerData;
        private readonly PlayerFactory _playerFactory;
        private readonly IPlayerStats _playerStats;
        private readonly IArrowStats _arrowStats;
        private readonly IObjectPool<ArrowData> _arrowObjectPool;
        private readonly IInitializable<(IInputModel, IArrowSpawnerController, IAttackModel)> _shootingControllerInitilize;
        private readonly IShootingController _shootingController;
        private readonly GameBehavior _gameBehavior;
        IInitializable<(Core.Services.IFactory<CreteadMeleeEnemyActorData>, 
            IRepository<IUpdateable>,
            IHealth,
            IMeleeEnemyStats,
            Transform)> _enemyTest;
        private readonly EntryPointData _entryPointData;

        private IDisposable _arrowSpawnerDispose;

        public EntryPoint(
            PlayerFactory playerFactory, 
            PlayerData playerData,
            IPlayerStats playerStats,
            IArrowStats arrowStats,
            IObjectPool<ArrowData> arrowObjectPool,
            IInitializable<(IInputModel, IArrowSpawnerController, IAttackModel)> shootingControllerInitilize,
            IShootingController shootingController,
            GameBehavior gameBehavior,
            IInitializable<(Core.Services.IFactory<CreteadMeleeEnemyActorData>, 
                IRepository<IUpdateable>, 
                IHealth, 
                IMeleeEnemyStats, 
                Transform)> enemyTestInitialize,
            EntryPointData entryPointData)
        {
            _playerData = playerData;
            _playerFactory = playerFactory;
            _playerStats = playerStats;
            _arrowStats = arrowStats;
            _arrowObjectPool = arrowObjectPool;
            _shootingControllerInitilize = shootingControllerInitilize;
            _shootingController = shootingController;
            _gameBehavior = gameBehavior;
            _enemyTest = enemyTestInitialize;
            _entryPointData = entryPointData;
        }
        
        public void Initialize()
        {
            CreatePlayer();
            _gameBehavior.EnableUpdating();
        }

        public void Dispose()
        {
            _arrowSpawnerDispose.Dispose();
        }

        private void CreatePlayer()
        {
            InputFactory inputFactory;
            AttackSystemFactory attackSystemFactory;
            PlayerStateController playerStateController;
            PlayerHeath playerHeath = new();
            
            //
            MeleeEnemyStats meleeEnemyStats = new();
            meleeEnemyStats.SetMovementSpeed(10f);
            meleeEnemyStats.SetHealth(60f);
            meleeEnemyStats.SetAttackDistance(0.9f);
            meleeEnemyStats.SetAttackCoolDown(2f);
            meleeEnemyStats.SetDamage(10f);
            //

            PlayerFactoryData playerFactoryData = _playerFactory.Create();
            inputFactory = new InputFactory(playerFactoryData.InputController);
            attackSystemFactory = new AttackSystemFactory(
                playerFactoryData.AttackController,
                _arrowObjectPool,
                playerFactoryData.PlayerGameObject.transform,
                _arrowStats,
                _playerStats,
                playerFactoryData.ArrowSpawnPoint);

            FactoryInputData factoryInputData = inputFactory.Create();
            AttackSystemFactoryData attackSystemFactoryData = attackSystemFactory.Create();
            
            playerFactoryData.InputController.Initialize(
                new InputControllerInitializeData 
                { 
                    InputModelController = factoryInputData.InputModelController,
                    Inputs = factoryInputData.Inputs,
                });

            playerStateController = new PlayerStateController(
                (IActivatedAndDeactivatedObject)_shootingController,
                playerFactoryData.InputController);

            _arrowSpawnerDispose = attackSystemFactoryData.ArrowSpawnerDispose;
            playerFactoryData.PlayerMovement.Initialize(factoryInputData.InputModel, _playerStats);
            playerFactoryData.PlayerStateController.Initialize();
            playerFactoryData.PlayerPositionController.SetOnPosition(_playerData.GameplaySpawnPointPosition);
            _shootingControllerInitilize.Initialize(new (
                factoryInputData.InputModel, 
                attackSystemFactoryData.ArrowSpawnerController,
                attackSystemFactoryData.Model));
            _shootingController.Activate();
            playerFactoryData.AttackControllerInitialize.Initialize(attackSystemFactoryData.ModelRepository);
            attackSystemFactoryData.ArrowSpawnerInitialize.Initialize();

            _enemyTest.Initialize(new(
                new MeleeEnemyActorFactory(
                    new RuleBasedAiMeleeActorFactory(playerStateController),
                    _entryPointData.MeleeEnemyPrefab),
                _gameBehavior,
                playerHeath,
                meleeEnemyStats,
                playerFactoryData.PlayerGameObject.transform));
        }
    }

    public struct EntryPointData
    {
        public GameObject MeleeEnemyPrefab;
    }
}
