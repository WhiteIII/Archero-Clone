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

        private Vector3 _cuttentTargetPosition;

        public ArrowSpawner(
            IAttackModel attackModel, 
            IAttackController attackController, 
            IObjectPool<ArrowData> arrowPool, 
            IArrowStats arrowStats,
            Transform playerTransform)
        {
            _attackModel = attackModel;
            _attackController = attackController;
            _arrowPool = arrowPool;
            _arrowStats = arrowStats;
            _playerTransform = playerTransform;
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
            ArrowData arrowData = _arrowPool.Get();
            arrowData.ArrowMovement.SetDuration(_playerTransform.position - _cuttentTargetPosition);
            arrowData.ArrowMovement.SetSpeed(_arrowStats.Speed);
        }

        private void SetClosestEnemy()
        {
            _cuttentTargetPosition = _attackModel.AttackableEnemies[0].Position;
            foreach (IAttackableEnemy attackableEnemy in _attackModel.AttackableEnemies)
            {
                if (Vector3.Distance(_cuttentTargetPosition, _playerTransform.position) 
                    > Vector3.Distance(attackableEnemy.Position, _playerTransform.position))
                {
                    _cuttentTargetPosition = attackableEnemy.Position;
                }
            }
        }
    }
}
