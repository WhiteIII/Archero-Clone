using UnityEngine;

namespace Project.Configs
{
    [CreateAssetMenu(fileName = "DefaultArrowData", menuName = "Project/DefaultArrowData")]
    public class DefaultArrowStatsData : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; } = 15f;
        [field: SerializeField] public float Speed { get; private set; } = 15f;
    }
}
