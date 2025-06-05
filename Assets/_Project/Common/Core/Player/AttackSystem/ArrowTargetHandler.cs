using System;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowTargetHandler : MonoBehaviour, IArrowTargetHandler
    {
        public event Action<ITarget> OnTouchedTarget;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITarget target))
                OnTouchedTarget?.Invoke(target);
        }
    }
}
