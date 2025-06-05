using Project.Core.GameCycle;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowObjectPool : BaseObjectPool<ArrowData>
    {
        private readonly IRepository<IUpdateable> _gameBehavior;
        private readonly IFactory<ArrowData, IObjectPool<ArrowData>> _arrowFactory;
        
        public ArrowObjectPool(
            int poolMaxSize, 
            IRepository<IUpdateable> gameBehavior,
            IFactory<ArrowData, IObjectPool<ArrowData>> arrowFactory) : base(poolMaxSize) 
        { 
            _gameBehavior = gameBehavior;
            _arrowFactory = arrowFactory;
        }

        public override void Destroy(ArrowData poolableObject) =>
            GameObject.Destroy(poolableObject.ArrowGameObject);

        public override ArrowData Get() =>
            GetFromPool();

        public override void Release(ArrowData poolableObject) =>
            ReleaseFromPool(poolableObject);

        protected override ArrowData OnCreate() =>
            _arrowFactory.Create(this);

        protected override void OnDestroy(ArrowData poolableObject) =>
            Destroy(poolableObject);

        protected override void OnGet(ArrowData poolableObject)
        {
            poolableObject.ArrowGameObject.SetActive(true);
            _gameBehavior.Add(poolableObject.ArrowMovement);
        }

        protected override void OnRelease(ArrowData poolableObject)
        {
            _gameBehavior.Remove(poolableObject.ArrowMovement);
            poolableObject.ArrowGameObject.SetActive(false);
        }
    }
}
