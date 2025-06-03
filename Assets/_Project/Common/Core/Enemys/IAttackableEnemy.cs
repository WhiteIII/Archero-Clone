using System;
using UnityEngine;

namespace Project.Core.Enemy
{
    public interface IAttackableEnemy
    {
        event Action<IAttackableEnemy> OnDead;
        Vector3 Position { get; }
        bool IsAlive { get; }
    }
}
