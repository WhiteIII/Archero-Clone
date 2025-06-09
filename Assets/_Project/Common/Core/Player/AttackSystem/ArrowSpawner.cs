using Project.Core.Enemy;
using Project.Core.Services;
using System;
using UnityEngine;
using Zenject;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowSpawner : IArrowSpawner, IInitializable, IDisposable
    {
        private readonly IAttackModel _attackModel;
        private readonly IAttackController _attackController;
        private readonly IObjectPool<ArrowData> _arrowPool;
        private readonly IArrowStats _arrowStats;
        private readonly Transform _playerTransform;
        private readonly Transform _spawnPoint;

        private IEnemyWithHealth _cuttentEnemy;

        public ArrowSpawner(
            IAttackModel attackModel, 
            IAttackController attackController, 
            IObjectPool<ArrowData> arrowPool, 
            IArrowStats arrowStats,
            Transform playerTransform,
            Transform arrowSpawnPoint)
        {
            _attackModel = attackModel;
            _attackController = attackController;
            _arrowPool = arrowPool;
            _arrowStats = arrowStats;
            _playerTransform = playerTransform;
            _spawnPoint = arrowSpawnPoint;
        }
        
        public void Initialize()
        {
            _attackController.OnTriggerEntered += SetClosestEnemy;
            _attackController.OnTriggerExited += SetClosestEnemy;
        }

        public void Dispose()
        {
            _attackController.OnTriggerEntered -= SetClosestEnemy;
            _attackController.OnTriggerExited -= SetClosestEnemy;
        }

        public void Shoot()
        {
            if (_cuttentEnemy == null) 
                return;

            ArrowData arrowData = _arrowPool.Get();
            arrowData.ArrowGameObject.transform.position = _spawnPoint.position;
            arrowData.ArrowMovement.SetTarget(
                new Vector3(
                    _cuttentEnemy.Position.x, 
                    _spawnPoint.position.y,
                    _cuttentEnemy.Position.z) - 
                _spawnPoint.position);
            arrowData.ArrowMovement.SetSpeed(_arrowStats.Speed);
        }

        private void SetClosestEnemy()
        {
            if (_attackModel.AttackableEnemies.Count == 0)
            {
                _cuttentEnemy = null;
                return;
            }
            
            _cuttentEnemy = _attackModel.AttackableEnemies[0];
            foreach (IEnemyWithHealth attackableEnemy in _attackModel.AttackableEnemies)
            {
                if (Vector3.Distance(_cuttentEnemy.Position, _playerTransform.position) 
                    > Vector3.Distance(attackableEnemy.Position, _playerTransform.position))
                {
                    _cuttentEnemy = attackableEnemy;
                }
            }
        }
    }
}
