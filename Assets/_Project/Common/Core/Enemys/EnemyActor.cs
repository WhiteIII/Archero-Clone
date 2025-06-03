using System;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class EnemyActor : MonoBehaviour, IAttackableEnemy
    {
        public event Action<IAttackableEnemy> OnDead;
        
        public Vector3 Position => transform.position;
        public bool IsAlive { get; private set; } = true;
    }
}
