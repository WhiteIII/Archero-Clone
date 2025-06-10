using Project.Core.Player.AttackSystem;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public struct DistantEnemyActorData
    {
        public IMeleeEnemyStats MeleeEnemyStats;
        public IObjectPool<ArrowData> ArrowPool;
        public Transform PlayerTransform;
    }
}
