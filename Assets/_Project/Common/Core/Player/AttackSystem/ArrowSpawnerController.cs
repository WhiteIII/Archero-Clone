﻿using Cysharp.Threading.Tasks;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowSpawnerController : IArrowSpawnerController
    {
        private readonly IPlayerStats _playerStats;
        private readonly IArrowSpawner _arrowSpawner;

        public ArrowSpawnerController(
            IPlayerStats playerStats,
            IArrowSpawner arrowSpawner)
        {
            _playerStats = playerStats;
            _arrowSpawner = arrowSpawner;
        }
        
        public async UniTask StartShooting()
        {
            await UniTask.WaitForSeconds(_playerStats.AttackSpeed * 0.3f);
            _arrowSpawner.Shoot();
            await UniTask.WaitForSeconds(_playerStats.AttackSpeed * 0.7f);
        }
    }
}
