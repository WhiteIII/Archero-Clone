using UnityEngine;

namespace Project.Core.Player
{
    public class PlayerCameraPositionHandler : IPlayerCameraPositionHandler
    {
        private readonly Transform _cameraParent;

        public PlayerCameraPositionHandler(Transform cameraParent) =>
            _cameraParent = cameraParent;

        public void SetCameraParent(Transform cameraTransform) =>
            cameraTransform.SetParent(_cameraParent);
    }
}