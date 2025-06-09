using Project.Core.Player.AttackSystem;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Time;
using static UnityEngine.Mathf;

namespace Project.Core.Enemy
{
    public class EnemyMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _updatePathCooldown;

        private IMeleeEnemyStats _playerStats;
        private float _currentCooldown;

        private bool InCooldown => _currentCooldown > .1f;

        public void Initilialize(IMeleeEnemyStats playerStats) =>
            _playerStats = playerStats;

        private void Update() =>
            _currentCooldown = Max(_currentCooldown - deltaTime, 0f);

        public void MoveTo(Vector3 target)
        {
            if (_agent.destination == target || InCooldown)
                return;

            Enable();
            _agent.SetDestination(target);
            _currentCooldown = _updatePathCooldown;
        }

        public void Stop() =>
            _agent.speed = 0f;

        public void Enable() =>
            _agent.speed = _playerStats.MovementSpeed;

    }
}
