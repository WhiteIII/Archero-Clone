using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class AttackSystemFactory : IFactory<AttackSystemFactoryData>
    {
        private readonly IAttackController _attackController;
        private readonly IObjectPool<ArrowData> _arrowObjectPool;
        private readonly Transform _playerTransform;
        private readonly Transform _arrowSpawnPoint;
        private readonly IArrowStats _arrowStats;
        private readonly IPlayerStats _playerStats;

        public AttackSystemFactory(
            IAttackController attackController,
            IObjectPool<ArrowData> arrowObjectPool,
            Transform playerTransform,
            IArrowStats arrowStats,
            IPlayerStats playerStats,
            Transform arrowSpawnPoint)
        {
            _attackController = attackController;
            _arrowObjectPool = arrowObjectPool;
            _playerTransform = playerTransform;
            _arrowStats = arrowStats;
            _playerStats = playerStats;
            _arrowSpawnPoint = arrowSpawnPoint;
        }

        public AttackSystemFactoryData Create()
        {
            AttackSystemFactoryData data = new();
            AttackModel attackModel = new();

            data.Model = attackModel;
            data.ArrowSpawner = new ArrowSpawner(
                data.Model, 
                _attackController, 
                _arrowObjectPool,
                _arrowStats,
                _playerTransform,
                _arrowSpawnPoint);
            data.ArrowSpawnerController = new ArrowSpawnerController(
                _playerStats,
                data.ArrowSpawner);
            data.ModelRepository = attackModel;

            return data;
        }
    }
}
