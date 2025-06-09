using Project.Core.Player.AttackSystem;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class CanopyBulletData : IBulletCreateData
    {
        public GameObject ArrowGameObject { get; set; }
        public Rigidbody Rigidbody { get; set; }
        public IBulletMovement ArrowMovement { get; set; }
        public IBulletActor ArrowActor { get; set; }
    }

    public class CanopyBalletActor : IBulletActor
    {
        //private readonly IBulletTargetHandler _targetHandler;
        
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
