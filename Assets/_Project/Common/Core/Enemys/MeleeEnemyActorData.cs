using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public struct CreteadMeleeEnemyActorData
    {
        public GameObject MeleeEnemyGameObject;
        public IUpdateable AiActor;
        public IInitializable<MeleeEnemyActorData> ActorInitilialize;
    }
}
