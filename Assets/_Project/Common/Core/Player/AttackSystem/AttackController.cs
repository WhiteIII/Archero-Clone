using Project.Core.Enemy;
using Project.Core.Services;
using System;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class AttackController : 
        MonoBehaviour, 
        IAttackController, 
        IInitializable<IRepository<IAttackableEnemy>>
    {
        public event Action OnTriggerEntered;
        public event Action OnTriggerExited;
        
        private IRepository<IAttackableEnemy> _attackModel;

        public void Initialize(IRepository<IAttackableEnemy> model) =>
            _attackModel = model;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IAttackableEnemy enemy))
            {
                _attackModel.Add(enemy);
                enemy.OnDead += RemoveEnemy;

                OnTriggerEntered?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IAttackableEnemy enemy))
            {
                _attackModel.Remove(enemy);
                enemy.OnDead -= RemoveEnemy;

                OnTriggerExited?.Invoke();
            }
        }

        private void RemoveEnemy(IAttackableEnemy enemyHealth)
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
