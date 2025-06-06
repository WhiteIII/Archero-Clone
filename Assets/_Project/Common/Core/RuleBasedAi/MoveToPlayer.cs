using Project.Core.Enemy;
using Project.Core.Player;

namespace Project.Core.RuleBasedAi
{
    public class MoveToPlayer : IRule
    {
        private readonly IEnemyActor _actor;
        private readonly IPlayerStateModel _playerStateModel;

        public MoveToPlayer(IEnemyActor actor, IPlayerStateModel playerStateModel)
        {
            _actor = actor;
            _playerStateModel = playerStateModel;
        }

        public bool CanExecute => 
            _actor.CanAttack == false &&
            _actor.IsAlive &&
            _playerStateModel.IsAlive;

        public void Execute() =>
            _actor.MoveToPlayer();
    }
}
