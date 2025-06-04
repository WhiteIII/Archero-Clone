using Project.Configs;
using Project.Core.Enemy;
using Project.Core.Services;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Core.Player.AttackSystem
{
    public class AttackModel : IAttackModel, IRepository<IAttackableEnemy>
    {
        private readonly List<IAttackableEnemy> _attackableEnemies = new();

        public IEnumerable<IAttackableEnemy> AttackableEnemies => _attackableEnemies;

        public void Add(IAttackableEnemy attackableEnemy) =>
            _attackableEnemies.Add(attackableEnemy);

        public void Remove(IAttackableEnemy attackableEnemy) =>
            _attackableEnemies.Remove(attackableEnemy);
    }

    public class ArrowSpawner : IInitializable
    {
        private readonly IAttackModel _attackModel;
        private readonly IAttackController _attackController;
        private readonly IObjectPool<ArrowData> _arrowPool;
        private readonly DefaultArrowStatsData _arrowStatsData;
        private readonly ArrowStats _arrowStats = new();

        public void Initialize()
        {
            _arrowStats.Damage = _arrowStatsData.Damage;
            _arrowStats.Speed = _arrowStatsData.Speed;
        }
    }

    public class ArrowFactory
    {

    }

    public class ArrowData
    {
        public GameObject ArrowGameObject;
        public Rigidbody Rigidbody;
    }

    public class ArrowStats
    {
        public float Damage;
        public float Speed;
    }
}
