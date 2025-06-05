using Project.Core.Enemy;
using Project.Core.Services;

namespace Project.Core.Player.AttackSystem
{
    public struct AttackSystemFactoryData
    {
        public IAttackModel Model;
        public IArrowSpawner ArrowSpawner;
        public IArrowSpawnerController ArrowSpawnerController;
        public IRepository<IAttackableEnemy> ModelRepository;
    }
}
