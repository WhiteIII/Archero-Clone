using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public interface IArrowMovement
    {
        void SetDuration(Vector3 duration);
        void SetSpeed(float speed);
    }
}
