using UnityEngine;

namespace Project.Configs
{
    [CreateAssetMenu(fileName = "DefaultEnemyStatsData", menuName = "Project/DefaultEnemyStatsData")]
    public class DefaultEnemyStatsData : ScriptableObject
    {
        [field: SerializeField] public float Health { get; private set; } = 60f;
        [field: SerializeField] public float Damage { get; private set; } = 10f;
        [field: SerializeField] public float MovementSpeed { get; private set; } = 5f;
        [field: SerializeField] public float AttackCoolDown { get; private set; } = 0.8f;
        [field: SerializeField] public float AttackDistance { get; private set; } = 0.3f;
    }
}
