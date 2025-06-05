namespace Project.Core.Player.AttackSystem
{
    public class PlayerStats : IPlayerStats
    {
        public float MovementSpeed { get; private set; }
        public float AttackSpeed { get; private set; }
        public float Health { get; private set; }

        public void SetMovementSpeed(float speed) =>
            MovementSpeed = speed;

        public void SetAttackSpeed(float speed) => 
            AttackSpeed = speed;

        public void SetHealth(float health) => 
            Health = health;
    }
}
