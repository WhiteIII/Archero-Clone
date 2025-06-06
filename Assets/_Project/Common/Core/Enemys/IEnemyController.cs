namespace Project.Core.Enemy
{
    public interface IEnemyController
    {
        void Attack();
        void MoveToPlayer();
        void StopMoving();
    }
}
