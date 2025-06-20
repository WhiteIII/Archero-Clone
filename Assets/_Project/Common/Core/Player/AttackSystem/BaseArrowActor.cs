﻿using Project.Core.Enemy;
using Project.Core.Services;

namespace Project.Core.Player.AttackSystem
{
    public class BaseArrowActor : IBulletActor
    {
        private readonly IObjectPool<ArrowData> _pool;
        private readonly IArrowStats _stats;
        private readonly ArrowData _currentArrowData;
        
        protected readonly IArrowTargetHandler _targetHandler;

        public BaseArrowActor(
            IObjectPool<ArrowData> pool, 
            IArrowStats stats, 
            ArrowData currentArrowData, 
            IArrowTargetHandler targetHandler)
        {
            _pool = pool;
            _stats = stats;
            _currentArrowData = currentArrowData;
            _targetHandler = targetHandler;
        }

        public void Initialize() =>
            _targetHandler.OnTouchedTarget += OnTouchedTarget;

        public void Dispose() =>
            _targetHandler.OnTouchedTarget -= OnTouchedTarget;

        protected virtual void OnTouchedTarget(ITarget target)
        {
            if (target is Wall _ || target is Obstacle _)
                ReleaseArrow();
            else if (target is EnemyHealth health)
            {
                DealDamage(health);
                ReleaseArrow();
            }
        }

        protected void DealDamage(IHealth health) =>
            health.TakeDamage(_stats.Damage);

        protected void ReleaseArrow() =>
            _pool.Release(_currentArrowData);
    }
}
