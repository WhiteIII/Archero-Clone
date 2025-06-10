using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class MeleeEnemyObjectPool : BaseObjectPool<CreatedMeleeEnemyActorData>
    {
        private readonly IFactory<CreatedMeleeEnemyActorData> _meleeEnemyFactory;
        private readonly IRepository<IUpdateable> _gameBehavior;
        private readonly IHealth _playerHealth;
        private readonly IMeleeEnemyStats _meleeEnemyStats;
        private readonly Transform _playerTransform;

        public MeleeEnemyObjectPool(int poolMaxSize, 
            IFactory<CreatedMeleeEnemyActorData> meleeEnemyFactory, 
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

        public override void Destroy(CreatedMeleeEnemyActorData poolableObject) =>
            OnDestroy(poolableObject);

        public override CreatedMeleeEnemyActorData Get() =>
            GetFromPool();

        public override void Release(CreatedMeleeEnemyActorData poolableObject) =>
            ReleaseFromPool(poolableObject);

        protected override CreatedMeleeEnemyActorData OnCreate()
        {
            CreatedMeleeEnemyActorData data = _meleeEnemyFactory.Create();

            data.ActorInitilialize.Initialize(new MeleeEnemyActorData
            {
                EnemyStats = _meleeEnemyStats,
                PlayerHealth = _playerHealth,
                PlayerTransform = _playerTransform,
            });

            return data;
        }

        protected override void OnDestroy(CreatedMeleeEnemyActorData poolableObject)
        {
            _gameBehavior.Remove(poolableObject.AiActor);
            GameObject.Destroy(poolableObject.MeleeEnemyGameObject);
        }

        protected override void OnGet(CreatedMeleeEnemyActorData poolableObject)
        {
            _gameBehavior.Add(poolableObject.AiActor);
            poolableObject.MeleeEnemyGameObject.SetActive(true);
        }

        protected override void OnRelease(CreatedMeleeEnemyActorData poolableObject)
        {
            poolableObject.MeleeEnemyGameObject.SetActive(false);
            _gameBehavior.Remove(poolableObject.AiActor);
        }
    }
}
