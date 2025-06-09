using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class BulletObjectPool<T> : BaseObjectPool<T>
        where T : class, IBulletCreateData
    {
        private readonly IRepository<IUpdateable> _gameBehavior;
        private readonly IFactory<T, IObjectPool<T>> _arrowFactory;
        
        public BulletObjectPool(
            int poolMaxSize, 
            IRepository<IUpdateable> gameBehavior,
            IFactory<T, IObjectPool<T>> arrowFactory) : base(poolMaxSize) 
        { 
            _gameBehavior = gameBehavior;
            _arrowFactory = arrowFactory;
        }

        public override void Destroy(T poolableObject)
        {
            poolableObject.ArrowActor.Dispose();
            Destroy(poolableObject);
            GameObject.Destroy(poolableObject.ArrowGameObject);
        }

        public override T Get() =>
            GetFromPool();

        public override void Release(T poolableObject) =>
            ReleaseFromPool(poolableObject);

        protected override T OnCreate()
        {
            T arrowData = _arrowFactory.Create(this);
            arrowData.ArrowActor.Initialize();
            return arrowData;
        }

        protected override void OnDestroy(T poolableObject) =>
            Destroy(poolableObject);

        protected override void OnGet(T poolableObject)
        {
            poolableObject.ArrowGameObject.SetActive(true);
            _gameBehavior.Add(poolableObject.ArrowMovement);
        }

        protected override void OnRelease(T poolableObject)
        {
            _gameBehavior.Remove(poolableObject.ArrowMovement);
            poolableObject.ArrowGameObject.SetActive(false);
        }
    }
}
