using UnityEngine;

namespace Project.Core.Enemy
{
    public interface IEnemyMovement
    {
        void Enable();
        void MoveTo(Vector3 target);
        void Stop();
    }
}