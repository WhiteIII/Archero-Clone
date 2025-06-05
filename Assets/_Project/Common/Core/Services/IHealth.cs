namespace Project.Core.Services
{
    public interface IHealth : ITarget
    {
        void TakeDamage(float damage);
    }
}
