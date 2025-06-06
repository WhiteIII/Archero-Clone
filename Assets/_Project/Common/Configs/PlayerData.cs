using UnityEngine;

namespace Project.Configs
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Project/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; } = 10f;
        [field: SerializeField] public float AttackSpeed { get; private set; } = 0.8f;
        [field: SerializeField] public float Health { get; private set; } = 100f;
        [field: SerializeField] public Vector3 GameplaySpawnPointPosition { get; private set; }
        [field: SerializeField] public int ArrowPoolMaxSize { get; private set; } = 30;
    }
}
