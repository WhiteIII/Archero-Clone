namespace Project.Core.Services
{
    public abstract class BaseObjectPool<TObject, TData> : IObjectPool<TObject, TData>
        where TObject : class
    {
        private readonly int _poolMaxSize;

        private UnityEngine.Pool.ObjectPool<TObject> Pool => new(OnCreate, OnGet, OnRelease, OnDestroy, false, _poolMaxSize);

        protected BaseObjectPool(int poolMaxSize) =>
            _poolMaxSize = poolMaxSize;

        protected abstract TObject OnCreate();
        protected abstract void OnGet(TObject poolableObject);
        protected abstract void OnRelease(TObject poolableObject);
        protected abstract void OnDestroy(TObject poolableObject);

        public abstract TObject Get(TData data);
        public abstract void Release(TObject poolableObject);
        public abstract void Destroy(TObject poolableObject);

        protected TObject GetFromPool() =>
            Pool.Get();

        protected void ReleaseFromPool(TObject poolableObject) =>
            Pool.Release(poolableObject);
    }
}
