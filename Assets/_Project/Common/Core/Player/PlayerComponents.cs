using UnityEngine;

namespace Project.Core.Player
{
    public class PlayerComponents : MonoBehaviour
    {
        [field: SerializeField] public Transform CameraPointTransform { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
    }
}