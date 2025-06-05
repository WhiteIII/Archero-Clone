using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public void TakeDamage(float damage)
        {
            Debug.Log(damage);
        }
    }
}
