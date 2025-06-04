namespace Project.Core.Services
{
    public abstract class BaseObjectPool<T> : IObjectPool<T>
        where T : class
    {
        private readonly int _poolMaxSize;

        private UnityEngine.Pool.ObjectPool<T> Pool => new(OnCreate, OnGet, OnRelease, OnDestroy, false, _poolMaxSize);

        protected BaseObjectPool(int poolMaxSize) =>
            _poolMaxSize = poolMaxSize;

        protected abstract T OnCreate();
        protected abstract void OnGet(T poolableObject);
        protected abstract void OnRelease(T poolableObject);
        protected abstract void OnDestroy(T poolableObject);

        public abstract T Get();
        public abstract void Release(T poolableObject);
        public abstract void Destroy(T poolableObject);

        protected T GetFromPool() =>
            Pool.Get();

        protected void ReleaseFromPool(T poolableObject) =>
            Pool.Release(poolableObject);
    }
}
