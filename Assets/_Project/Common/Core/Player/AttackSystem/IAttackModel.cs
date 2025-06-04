using Project.Core.Enemy;
using System.Collections.Generic;

namespace Project.Core.Player.AttackSystem
{
    public interface IAttackModel
    {
        public IReadOnlyList<IAttackableEnemy> AttackableEnemies { get; }
    }
}
