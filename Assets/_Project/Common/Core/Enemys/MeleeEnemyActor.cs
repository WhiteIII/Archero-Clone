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

        private IHealth _playerHealth;
        private IMeleeEnemyStats _meleeEnemyStats;
        private Transform _playerTransform;
        private NavMeshAgent _agent;

        public Vector3 Position => transform.position;
        public bool IsAlive { get; private set; } = true;
        public bool AttackCoolDown { get; private set; } = false;
        public bool CanAttack => Vector3.Distance(Position, _playerTransform.position) <= _meleeEnemyStats.AttackDistance;

        public void Initialize(MeleeEnemyActorData data)
        {
            _playerHealth = data.PlayerHealth;
            _meleeEnemyStats = data.EnemyStats;
            _playerTransform = data.PlayerTransform;
            _agent.speed = _meleeEnemyStats.MovementSpeed;
        }

        private void Awake() =>
            _agent = GetComponent<NavMeshAgent>();

        public async void Attack()
        {
            _playerHealth.TakeDamage(_meleeEnemyStats.Damage);
            AttackCoolDown = true;
            await UniTask.WaitForSeconds(_meleeEnemyStats.AttackCoolDown);
            AttackCoolDown = false;
        }

        public void MoveToPlayer()
        {
            _agent.isStopped = false;
            _agent.SetDestination(_playerTransform.position);
        }

        public void StopMoving() =>
            _agent.isStopped = true;
    }

    public struct MeleeEnemyActorData
    {
        public IHealth PlayerHealth;
        public IMeleeEnemyStats EnemyStats;
        public Transform PlayerTransform;
    }
}
