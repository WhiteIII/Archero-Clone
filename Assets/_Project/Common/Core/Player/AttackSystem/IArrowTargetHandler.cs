using System;
using Project.Core.Services;

namespace Project.Core.Player.AttackSystem
{
    public interface IArrowTargetHandler
    {
        event Action<ITarget> OnTouchedTarget;
    }
}
