using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowData : IBulletCreateData
    {
        public GameObject ArrowGameObject { get; set; }
        public Rigidbody Rigidbody { get; set; }
        public IBulletMovement ArrowMovement { get; set; }
        public IBulletActor ArrowActor { get; set; }
    }
}
