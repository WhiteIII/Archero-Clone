using Project.Core.Player.AttackSystem;
using UnityEngine;

namespace Project.Core.Services
{
    public interface IBulletCreateData
    {
        GameObject ArrowGameObject { get; set; }
        Rigidbody Rigidbody { get; set; }
        IBulletMovement ArrowMovement { get; set; }
        IBulletActor ArrowActor { get; set; }
    }
}
