using Project.Core.Enemy;
using Project.Core.Services;
using System.Collections.Generic;

namespace Project.Core.Player.AttackSystem
{
    public class AttackModel : IAttackModel, IRepository<IAttackableEnemy>
    {
        private readonly List<IAttackableEnemy> _attackableEnemies = new();

        public IEnumerable<IAttackableEnemy> AttackableEnemies => _attackableEnemies;

        public void Add(IAttackableEnemy attackableEnemy) =>
            _attackableEnemies.Add(attackableEnemy);

        public void Remove(IAttackableEnemy attackableEnemy) =>
            _attackableEnemies.Remove(attackableEnemy);
    }

    public class ArrowSpawner
    {

    }

    public class ArrowFactory
    {

    }

    public class ArrowObjectPool
    {

    }
}
