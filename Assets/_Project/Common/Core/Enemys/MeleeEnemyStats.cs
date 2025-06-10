namespace Project.Core.Enemy
{
    public class MeleeEnemyStats : IMeleeEnemyStats
    {
        public float Health { get; private set; }
        public float Damage { get; private set; }
        public float MovementSpeed { get; private set; }
        public float AttackCoolDown { get; private set; }
        public float AttackDistance { get; private set; }

        public void SetHealth(float health) =>
            Health = health;

        public void SetDamage(float damage) =>
            Damage = damage;

        public void SetMovementSpeed(float movementSpeed) =>
            MovementSpeed = movementSpeed;

        public void SetAttackCoolDown(float attackCoolDown) =>
            AttackCoolDown = attackCoolDown;

        public void SetAttackDistance(float attackDistance) =>
            AttackDistance = attackDistance;
    }
}
