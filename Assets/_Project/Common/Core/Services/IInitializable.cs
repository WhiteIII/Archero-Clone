namespace Project.Core.Services
{
    public interface IInitializable<TData>
    {
        void Initialize(TData data);
    }
}