using Project.Core.Player.AttackSystem;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class CanopyBulletData : IBulletCreateData
    {
        public GameObject ArrowGameObject;
        public Rigidbody Rigidbody;
        public ArrowMovement ArrowMovement;
        public BaseArrowActor ArrowActor;
    }
}
