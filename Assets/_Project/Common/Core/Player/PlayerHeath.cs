using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player
{
    public class PlayerHeath : IHealth
    {
        public void TakeDamage(float damage)
        {
            Debug.Log($"Player take {damage} damage!");
        }
    }
}