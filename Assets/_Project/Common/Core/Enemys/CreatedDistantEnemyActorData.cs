using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class CreatedDistantEnemyActorData : ICreatedActorData
    {
        public GameObject DistantEnemyGameObject;
        public IUpdateable AiActor;
        public IEnemyActor EnemyActor;
        public IInitializable<DistantEnemyActorData> ActorInitilialize;
    }
}
