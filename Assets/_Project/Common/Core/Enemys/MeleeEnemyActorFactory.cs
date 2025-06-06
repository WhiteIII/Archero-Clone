using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class MeleeEnemyActorFactory : IFactory<MeleeEnemyActorData>
    {
        private readonly IFactory<IAiActor, IEnemyActor> _aiActorFactory;
        private readonly GameObject _enemyPrefab;

        public MeleeEnemyActorFactory(
            IFactory<IAiActor, IEnemyActor> aiActorFactory, 
            GameObject enemyPrefab)
        {
            _aiActorFactory = aiActorFactory;
            _enemyPrefab = enemyPrefab;
        }

        public MeleeEnemyActorData Create()
        {
            MeleeEnemyActorData data = new();

            data.MeleeEnemyGameObject = GameObject.Instantiate(_enemyPrefab);
            data.ActorInitilialize = data.MeleeEnemyGameObject.GetComponent<IInitializable<MeleeEnemyActorData>>();
            data.AiActor = _aiActorFactory.Create(data.MeleeEnemyGameObject.GetComponent<IEnemyActor>());

            return data;
        }
    }
}
