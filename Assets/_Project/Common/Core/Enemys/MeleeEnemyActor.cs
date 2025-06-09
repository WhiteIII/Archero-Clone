using System;
using Cysharp.Threading.Tasks;
using Project.Core.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Core.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MeleeEnemyActor : 
        MonoBehaviour, 
        IEnemyActor, 
        IInitializable<MeleeEnemyActorData>
    {
        public event Action<IEnemyWithHealth> OnDead;

        [SerializeField] private EnemyMovement _enemyMovement;
        
        private IHealth _playerHealth;
        private IMeleeEnemyStats _meleeEnemyStats;
        private Transform _playerTransform;

        public Vector3 Position => transform.position;
        public bool IsAlive { get; private set; } = true;
        public bool AttackCoolDown { get; private set; } = false;
        public bool CanAttack => Vector3.Distance(Position, _playerTransform.position) <= _meleeEnemyStats.AttackDistance;

        public void Initialize(MeleeEnemyActorData data)
        {
            _playerHealth = data.PlayerHealth;
            _meleeEnemyStats = data.EnemyStats;
            _playerTransform = data.PlayerTransform;
            _enemyMovement.Initilialize(data.EnemyStats);
        }

        public async void Attack()
        {
            _playerHealth.TakeDamage(_meleeEnemyStats.Damage);
            AttackCoolDown = true;
            await UniTask.WaitForSeconds(_meleeEnemyStats.AttackCoolDown);
            AttackCoolDown = false;
        }

        public void MoveToPlayer() =>
            _enemyMovement.MoveTo(_playerTransform.position);

        public void StopMoving() =>
            _enemyMovement.Stop();
    }

    public struct MeleeEnemyActorData
    {
        public IHealth PlayerHealth;
        public IMeleeEnemyStats EnemyStats;
        public Transform PlayerTransform;
    }
}
