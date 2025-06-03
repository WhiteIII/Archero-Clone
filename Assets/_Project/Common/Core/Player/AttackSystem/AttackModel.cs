using Project.Core.Enemy;
using Project.Core.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

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

    public class ArrowSpawner
    {

    }

    public class ArrowFactory
    {

    }

    public class ArrowObjectPool : BaseObjectPool<GameObject, ArrowData>
    {
        public ArrowObjectPool(int poolMaxSize) : base(poolMaxSize) { }

        public override void Destroy(GameObject poolableObject)
        {
            throw new NotImplementedException();
        }

        public override GameObject Get(ArrowData data)
        {
            throw new NotImplementedException();
        }

        public override void Release(GameObject poolableObject)
        {
            throw new NotImplementedException();
        }

        protected override GameObject OnCreate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy(GameObject poolableObject)
        {
            throw new NotImplementedException();
        }

        protected override void OnGet(GameObject poolableObject)
        {
            throw new NotImplementedException();
        }

        protected override void OnRelease(GameObject poolableObject)
        {
            throw new NotImplementedException();
        }
    }

    public struct ArrowData
    {

    }
}
