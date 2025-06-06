using Project.Core.Enemy;
using Project.Core.Services;
using System.Collections.Generic;

namespace Project.Core.Player.AttackSystem
{
    public class AttackModel : IAttackModel, IRepository<IEnemyWithHealth>
    {
        private readonly List<IEnemyWithHealth> _attackableEnemies = new();

        public IReadOnlyList<IEnemyWithHealth> AttackableEnemies => _attackableEnemies;

        public void Add(IEnemyWithHealth attackableEnemy) =>
            _attackableEnemies.Add(attackableEnemy);

        public void Remove(IEnemyWithHealth attackableEnemy) =>
            _attackableEnemies.Remove(attackableEnemy);
    }
}
