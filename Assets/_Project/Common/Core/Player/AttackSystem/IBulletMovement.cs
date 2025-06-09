using Project.Core.GameCycle;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public interface IBulletMovement : IUpdateable
    {
        void SetTarget(Vector3 target);
        void SetSpeed(float speed);
    }
}
