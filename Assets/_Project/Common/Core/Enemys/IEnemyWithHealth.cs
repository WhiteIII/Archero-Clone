using System;
using UnityEngine;

namespace Project.Core.Enemy
{
    public interface IEnemyWithHealth
    {
        event Action<ICreatedActorData> OnDead;
        Vector3 Position { get; }
        bool IsAlive { get; }
    }
}
