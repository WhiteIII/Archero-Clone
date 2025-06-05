namespace Project.Core.Player.UpgradeSystem
{
    public interface IUpgradeController
    {
        void UpgradeArrowSpeed(float speed);
        void UpgradeAttackSpeed(float attackSpeed);
        void UpgradeDamage(float damage);
        void UpgradeHealth(float health);
        void UpgradeMovementSpeed(float speed);
    }
}