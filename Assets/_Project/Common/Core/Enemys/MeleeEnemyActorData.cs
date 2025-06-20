﻿using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class CreatedMeleeEnemyActorData : ICreatedActorData
    {
        public GameObject MeleeEnemyGameObject;
        public IUpdateable AiActor;
        public IEnemyActor EnemyActor;
        public IInitializable<MeleeEnemyActorData> ActorInitilialize;
    }
}
