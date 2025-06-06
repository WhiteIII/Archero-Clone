using System;
using Project.Core.Enemy;
using Project.Core.Services;
using Zenject;

namespace Project.Core.Player.AttackSystem
{
    public struct AttackSystemFactoryData
    {
        public IAttackModel Model;
        public IArrowSpawner ArrowSpawner;
        public IArrowSpawnerController ArrowSpawnerController;
        public IRepository<IEnemyWithHealth> ModelRepository;
        public IInitializable ArrowSpawnerInitialize;
        public IDisposable ArrowSpawnerDispose;
    }
}
