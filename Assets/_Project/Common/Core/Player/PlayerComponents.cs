using Project.Core.Player.AttackSystem;
using UnityEngine;

namespace Project.Core.Player
{
    public class PlayerComponents : MonoBehaviour
    {
        [field: SerializeField] public Transform CameraPointTransform { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public AttackController AttackController { get; private set; }
        [field: SerializeField] public Transform ArrowSpawnPoint { get; private set; }
    }
}