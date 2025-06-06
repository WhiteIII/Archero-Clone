using Project.Core.Enemy;
using Project.Core.Services;
using Project.Core.Player;

namespace Project.Core.RuleBasedAi
{
    public class RuleBasedAiMeleeActorFactory : IFactory<IAiActor, IEnemyActor>
    {
        private readonly IPlayerStateModel _playerStateModel;

        public RuleBasedAiMeleeActorFactory(IPlayerStateModel playerStateModel) =>
            _playerStateModel = playerStateModel;

        public IAiActor Create(IEnemyActor enemyActor) =>
            new RuleBasedAiActor( 
                new Attack(enemyActor, _playerStateModel),
                new MoveToPlayer(enemyActor, _playerStateModel));
    }
}
