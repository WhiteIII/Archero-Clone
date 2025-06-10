using Project.Core.GameCycle;
using Project.Core.Player.AttackSystem;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class DistantEnemyObjectPool : BaseObjectPool<CreatedDistantEnemyActorData>
    {
        private readonly IFactory<CreatedDistantEnemyActorData> _distantEnemyFactory;
        private readonly IRepository<IUpdateable> _gameBehavior;
        private readonly IMeleeEnemyStats _meleeEnemyStats;
        private readonly Transform _playerTransform;
        private readonly IObjectPool<ArrowData> _arrowObjectPool;

        public DistantEnemyObjectPool(int poolMaxSize,
            IFactory<CreatedDistantEnemyActorData> distantEnemyFactory,
            IRepository<IUpdateable> gameBehavior,
            IMeleeEnemyStats meleeEnemyStats,
            Transform playerTransform,
            IObjectPool<ArrowData> arrowObjectPool) : base(poolMaxSize)
        {
            _distantEnemyFactory = distantEnemyFactory;
            _gameBehavior = gameBehavior;
            _meleeEnemyStats = meleeEnemyStats;
            _playerTransform = playerTransform;
            _arrowObjectPool = arrowObjectPool;
        }

        public override void Destroy(CreatedDistantEnemyActorData poolableObject) =>
            OnDestroy(poolableObject);

        public override CreatedDistantEnemyActorData Get() =>
            GetFromPool();

        public override void Release(CreatedDistantEnemyActorData poolableObject) =>
            ReleaseFromPool(poolableObject);

        protected override CreatedDistantEnemyActorData OnCreate()
        {
            CreatedDistantEnemyActorData data = _distantEnemyFactory.Create();

            data.ActorInitilialize.Initialize(new DistantEnemyActorData
            {
                MeleeEnemyStats = _meleeEnemyStats,
                ArrowPool = _arrowObjectPool,
                PlayerTransform = _playerTransform,
            });

            return data;
        }

        protected override void OnDestroy(CreatedDistantEnemyActorData poolableObject)
        {
            _gameBehavior.Remove(poolableObject.AiActor);
            GameObject.Destroy(poolableObject.DistantEnemyGameObject);
        }

        protected override void OnGet(CreatedDistantEnemyActorData poolableObject)
        {
            _gameBehavior.Add(poolableObject.AiActor);
            poolableObject.DistantEnemyGameObject.SetActive(true);
        }

        protected override void OnRelease(CreatedDistantEnemyActorData poolableObject)
        {
            poolableObject.DistantEnemyGameObject.SetActive(false);
            _gameBehavior.Remove(poolableObject.AiActor);
        }
    }
}
