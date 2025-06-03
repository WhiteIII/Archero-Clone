namespace Project.Core.Services
{
    public interface IFactory<T>
    {
        T Create();
    }
}