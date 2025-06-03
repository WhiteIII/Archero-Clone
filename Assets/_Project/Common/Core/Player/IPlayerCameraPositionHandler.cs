using UnityEngine;

namespace Project.Core.Player
{
    public interface IPlayerCameraPositionHandler
    {
        void SetCameraParent(Transform cameraTransform);
    }
}