using Project.Core.Enemy;
using Project.Core.Services;
using System;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class AttackController : 
        MonoBehaviour, 
        IAttackController, 
        IInitializable<IRepository<IEnemyWithHealth>>
    {
        public event Action OnTriggerEntered;
        public event Action OnTriggerExited;
        
        private IRepository<IEnemyWithHealth> _attackModel;

        public void Initialize(IRepository<IEnemyWithHealth> model) =>
            _attackModel = model;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEnemyWithHealth enemy))
            {
                _attackModel.Add(enemy);
                enemy.OnDead += RemoveEnemy;

                OnTriggerEntered?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEnemyWithHealth enemy))
            {
                _attackModel.Remove(enemy);
                enemy.OnDead -= RemoveEnemy;

                OnTriggerExited?.Invoke();
            }
        }

        private void RemoveEnemy(IEnemyWithHealth enemyHealth)
        {
            enemyHealth.OnDead -= RemoveEnemy;
            _attackModel.Remove(enemyHealth);

            OnTriggerExited?.Invoke();
        }
    }

    public interface IAttackController
    {
        event Action OnTriggerEntered;
        event Action OnTriggerExited;
    }
}
