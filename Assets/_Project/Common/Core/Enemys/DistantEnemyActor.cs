using System;
using Cysharp.Threading.Tasks;
using Project.Core.Player.AttackSystem;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class DistantEnemyActor :
        MonoBehaviour,
        IEnemyActor,
        IInitializable<DistantEnemyActorData>
    {
        public event Action<IEnemyWithHealth> OnDead;

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private Transform _arrowSpawnPoint;

        private IMeleeEnemyStats _meleeEnemyStats;
        private IObjectPool<ArrowData> _arrowPool;
        private IArrowStats _arrowStats;
        private Transform _playerTransform;

        public Vector3 Position => transform.position;
        public bool IsAlive { get; private set; } = true;
        public bool AttackCoolDown { get; private set; } = false;
        public bool CanAttack => Vector3.Distance(Position, _playerTransform.position) <= _meleeEnemyStats.AttackDistance;

        public void Initialize(DistantEnemyActorData data)
        {
            _meleeEnemyStats = data.MeleeEnemyStats;
            _arrowPool = data.ArrowPool;
            _playerTransform = data.PlayerTransform;
            _enemyMovement.Initilialize(_meleeEnemyStats);
        }

        public async void Attack()
        {
            ArrowData data = _arrowPool.Get();

            ArrowData arrowData = _arrowPool.Get();
            arrowData.ArrowGameObject.transform.position = _arrowSpawnPoint.position;
            arrowData.ArrowMovement.SetTarget(
                new Vector3(
                    _playerTransform.position.x,
                    _arrowSpawnPoint.position.y,
                    _playerTransform.position.z) -
                _arrowSpawnPoint.position);
            arrowData.ArrowMovement.SetSpeed(_arrowStats.Speed);

            AttackCoolDown = true;
            await UniTask.WaitForSeconds(_meleeEnemyStats.AttackCoolDown);
            AttackCoolDown = false;
        }

        public void MoveToPlayer() =>
            _enemyMovement.MoveTo(_playerTransform.position);

        public void StopMoving() =>
            _enemyMovement.Stop();
    }

    //public class EnemyStateController : IInitializable, IDisposable
    //{
    //    private readonly IEnemyActor _enemyActor;
  
    //    //public void Initialize() =>
    //      //  _enemyActor.OnDead

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
