using UnityEngine;

namespace Project.Configs
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Project/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; } = 10f;
    }
}
