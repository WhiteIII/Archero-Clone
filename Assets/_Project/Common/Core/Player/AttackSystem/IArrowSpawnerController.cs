using Cysharp.Threading.Tasks;

namespace Project.Core.Player.AttackSystem
{
    public interface IArrowSpawnerController
    {
        bool IsActive { get; }
        
        UniTask StartShooting();
        void StopShooting();
    }
}
