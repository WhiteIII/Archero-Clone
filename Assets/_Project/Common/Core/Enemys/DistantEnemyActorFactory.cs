using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class DistantEnemyActorFactory : IFactory<CreatedDistantEnemyActorData>
    {
        private readonly IFactory<IAiActor, IEnemyActor> _aiActorFactory;
        private readonly GameObject _enemyPrefab;

        public DistantEnemyActorFactory(
            IFactory<IAiActor, IEnemyActor> aiActorFactory,
            GameObject enemyPrefab)
        {
            _aiActorFactory = aiActorFactory;
            _enemyPrefab = enemyPrefab;
        }

        public CreatedDistantEnemyActorData Create()
        {
            CreatedDistantEnemyActorData data = new();

            data.DistantEnemyGameObject = GameObject.Instantiate(_enemyPrefab);
            data.ActorInitilialize = data.DistantEnemyGameObject.GetComponent<IInitializable<DistantEnemyActorData>>();
            data.AiActor = (IUpdateable)_aiActorFactory.Create(data.DistantEnemyGameObject.GetComponent<IEnemyActor>());
            data.EnemyActor = data.DistantEnemyGameObject.GetComponent<IEnemyActor>();

            return data;
        }
    }
}
