namespace Project.Core.Services
{
    public abstract class BaseObjectPool<T> : IObjectPool<T>
        where T : class
    {
        private readonly UnityEngine.Pool.ObjectPool<T> _pool;

        protected BaseObjectPool(int poolMaxSize) =>
            _pool = new(OnCreate, OnGet, OnRelease, OnDestroy, true, poolMaxSize);

        protected abstract T OnCreate();
        protected abstract void OnGet(T poolableObject);
        protected abstract void OnRelease(T poolableObject);
        protected abstract void OnDestroy(T poolableObject);

        public abstract T Get();
        public abstract void Release(T poolableObject);
        public abstract void Destroy(T poolableObject);

        protected T GetFromPool() =>
            _pool.Get();

        protected void ReleaseFromPool(T poolableObject) =>
            _pool.Release(poolableObject);
    }
}
