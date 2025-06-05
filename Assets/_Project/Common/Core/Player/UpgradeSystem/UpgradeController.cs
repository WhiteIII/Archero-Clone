using Project.Configs;
using Project.Core.Player.AttackSystem;
using Zenject;

namespace Project.Core.Player.UpgradeSystem
{
    public class UpgradeController : IInitializable, IUpgradeController
    {
        private readonly PlayerStats _playerStats;
        private readonly ArrowStats _arrowStats;
        private readonly DefaultArrowStatsData _arrowData;
        private readonly PlayerData _playerData;

        public UpgradeController(
            PlayerStats playerStats,
            ArrowStats arrowStats,
            DefaultArrowStatsData arrowData,
            PlayerData playerData)
        {
            _playerStats = playerStats;
            _arrowStats = arrowStats;
            _arrowData = arrowData;
            _playerData = playerData;
        }

        public void Initialize()
        {
            _arrowStats.SetDamage(_arrowData.Damage);
            _arrowStats.SetSpeed(_arrowData.Speed);
            _playerStats.SetMovementSpeed(_playerData.Speed);
            _playerStats.SetAttackSpeed(_playerData.AttackSpeed);
            _playerStats.SetHealth(_playerStats.Health);
        }

        public void UpgradeDamage(float damage) =>
            _arrowStats.SetDamage(_arrowStats.Damage + damage);

        public void UpgradeArrowSpeed(float speed) =>
            _arrowStats.SetSpeed(_arrowStats.Speed + speed);

        public void UpgradeMovementSpeed(float speed) =>
            _playerStats.SetMovementSpeed(_playerStats.MovementSpeed + speed);

        public void UpgradeAttackSpeed(float attackSpeed) =>
            _playerStats.SetAttackSpeed(_playerStats.AttackSpeed + attackSpeed);

        public void UpgradeHealth(float health) =>
            _playerStats.SetHealth(_playerStats.Health + health);
    }
}
