using Project.Core.Enemy;
using Project.Core.Player;

namespace Project.Core.RuleBasedAi
{
    public class Attack : IRule
    {
        private readonly IEnemyActor _enemyActor;
        private readonly IPlayerStateModel _playerStateModel;

        public Attack(
            IEnemyActor enemyActor,
            IPlayerStateModel playerStateModel)
        {
            _playerStateModel = playerStateModel;
            _enemyActor = enemyActor;
        }

        public bool CanExecute => 
            _enemyActor.AttackCoolDown == false && 
            _enemyActor.CanAttack &&
            _enemyActor.IsAlive &&
            _playerStateModel.IsAlive;

        public void Execute() =>
            _enemyActor.Attack();
    }
}
