using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowObjectPool : BaseObjectPool<ArrowData>
    {
        private GameObject _currentArrowPrefab;
        
        public ArrowObjectPool(int poolMaxSize) : base(poolMaxSize) { }

        public override void Destroy(ArrowData poolableObject) =>
            GameObject.Destroy(poolableObject.ArrowGameObject);

        public void SetCurrentPrefab(GameObject prefab) =>
            _currentArrowPrefab = prefab;

        public override ArrowData Get() =>
            GetFromPool();

        public override void Release(ArrowData poolableObject) =>
            ReleaseFromPool(poolableObject);

        protected override ArrowData OnCreate()
        {
            GameObject arrowGameObject = GameObject.Instantiate(_currentArrowPrefab);

            return new ArrowData 
            { 
                ArrowGameObject = arrowGameObject,
                Rigidbody = arrowGameObject.GetComponent<Rigidbody>()
            };
        }

        protected override void OnDestroy(ArrowData poolableObject) =>
            Destroy(poolableObject);

        protected override void OnGet(ArrowData poolableObject) =>
            poolableObject.ArrowGameObject.SetActive(true);

        protected override void OnRelease(ArrowData poolableObject) =>
            poolableObject.ArrowGameObject.SetActive(false);
    }
}
