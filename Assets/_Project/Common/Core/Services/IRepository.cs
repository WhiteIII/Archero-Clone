namespace Project.Core.Services
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
    }
}
