using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public struct MeleeEnemyActorData
    {
        public GameObject MeleeEnemyGameObject;
        public IAiActor AiActor;
        public IInitializable<MeleeEnemyActorData> ActorInitilialize;
    }
}
