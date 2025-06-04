namespace Project.Core.Services
{
    public interface IObjectPool<T>
    {
        T Get();
        void Release(T poolableObject);
        void Destroy(T poolableObject);
    }
}
