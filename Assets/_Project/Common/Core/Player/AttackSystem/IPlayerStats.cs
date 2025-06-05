namespace Project.Core.Player.AttackSystem
{
    public interface IPlayerStats
    {
        float MovementSpeed { get; }
        float AttackSpeed { get; }
        float Health { get; }
    }
}
