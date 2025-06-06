namespace Project.Core.Enemy
{
    public interface IAttackableEnemy
    {
        public bool AttackCoolDown { get; }
        public bool CanAttack { get; }
    }
}
