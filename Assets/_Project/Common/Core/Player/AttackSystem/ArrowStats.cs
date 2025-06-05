namespace Project.Core.Player.AttackSystem
{
    public class ArrowStats : IArrowStats
    {
        public float Damage { get; private set; }
        public float Speed { get; private set; }

        public void SetDamage(float damage) =>
            Damage = damage;

        public void SetSpeed(float speed) => 
            Speed = speed;
    }
}
