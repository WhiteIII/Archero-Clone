﻿using Cysharp.Threading.Tasks;

namespace Project.Core.Player.AttackSystem
{
    public interface IArrowSpawnerController
    {
        UniTask StartShooting();
    }
}
