namespace Project.Core.Services
{
    public interface IObjectPool<TObject, TData>
    {
        TObject Get(TData data);
        void Release(TObject poolableObject);
        void Destroy(TObject poolableObject);
    }
}
