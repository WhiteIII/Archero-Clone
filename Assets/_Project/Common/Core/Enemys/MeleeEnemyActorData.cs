using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class CreteadMeleeEnemyActorData
    {
        public GameObject MeleeEnemyGameObject;
        public IUpdateable AiActor;
        public IInitializable<MeleeEnemyActorData> ActorInitilialize;
    }
}
