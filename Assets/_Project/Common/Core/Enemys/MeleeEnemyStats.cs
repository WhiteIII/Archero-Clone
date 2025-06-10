using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class MeleeEnemyStats : IMeleeEnemyStats
    {
        public float Health { get; private set; }
        public float Damage { get; private set; }
        public float MovementSpeed { get; private set; }
        public float AttackCoolDown { get; private set; }
        public float AttackDistance { get; private set; }

        public void SetHealth(float health) =>
            Health = health;

        public void SetDamage(float damage) =>
            Damage = damage;

        public void SetMovementSpeed(float movementSpeed) =>
            MovementSpeed = movementSpeed;

        public void SetAttackCoolDown(float attackCoolDown) =>
            AttackCoolDown = attackCoolDown;

        public void SetAttackDistance(float attackDistance) =>
            AttackDistance = attackDistance;
    }

    public class EnemyObjectPool : BaseObjectPool<CreteadMeleeEnemyActorData>
    {
        private readonly IFactory<CreteadMeleeEnemyActorData> _meleeEnemyFactory;
        private readonly IRepository<IUpdateable> _gameBehavior;
        private readonly IHealth _playerHealth;
        private readonly IMeleeEnemyStats _meleeEnemyStats;
        private readonly Transform _playerTransform;

        public EnemyObjectPool(int poolMaxSize, 
            IFactory<CreteadMeleeEnemyActorData> meleeEnemyFactory, 
            IRepository<IUpdateable> gameBehavior, 
            IHealth playerHealth, 
            IMeleeEnemyStats meleeEnemyStats, 
            Transform playerTransform) : base(poolMaxSize)
        {
            _meleeEnemyFactory = meleeEnemyFactory;
            _gameBehavior = gameBehavior;
            _playerHealth = playerHealth;
            _meleeEnemyStats = meleeEnemyStats;
            _playerTransform = playerTransform;
        }

        public override void Destroy(CreteadMeleeEnemyActorData poolableObject) =>
            OnDestroy(poolableObject);

        public override CreteadMeleeEnemyActorData Get() =>
            GetFromPool();

        public override void Release(CreteadMeleeEnemyActorData poolableObject) =>
            ReleaseFromPool(poolableObject);

        protected override CreteadMeleeEnemyActorData OnCreate()
        {
            CreteadMeleeEnemyActorData data = _meleeEnemyFactory.Create();

            data.ActorInitilialize.Initialize(new MeleeEnemyActorData
            {
                EnemyStats = _meleeEnemyStats,
                PlayerHealth = _playerHealth,
                PlayerTransform = _playerTransform,
            });

            return data;
        }

        protected override void OnDestroy(CreteadMeleeEnemyActorData poolableObject)
        {
            _gameBehavior.Remove(poolableObject.AiActor);
            GameObject.Destroy(poolableObject.MeleeEnemyGameObject);
        }

        protected override void OnGet(CreteadMeleeEnemyActorData poolableObject)
        {
            _gameBehavior.Add(poolableObject.AiActor);
            poolableObject.MeleeEnemyGameObject.SetActive(true);
        }

        protected override void OnRelease(CreteadMeleeEnemyActorData poolableObject)
        {
            poolableObject.MeleeEnemyGameObject.SetActive(false);
            _gameBehavior.Remove(poolableObject.AiActor);
        }
    }
}
