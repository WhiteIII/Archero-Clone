namespace Project.Core.Services
{
    public interface IFactory<T>
    {
        T Create();
    }

    public interface IFactory<TObject, TData>
    {
        TObject Create(TData data);
    }
}