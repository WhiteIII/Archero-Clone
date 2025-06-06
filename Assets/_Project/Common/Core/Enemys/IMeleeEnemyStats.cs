namespace Project.Core.Enemy
{
    public interface IMeleeEnemyStats
    {
        float AttackCoolDown { get; }
        float AttackDistance { get; }
        float Damage { get; }
        float Health { get; }
        float MovementSpeed { get; }
    }
}