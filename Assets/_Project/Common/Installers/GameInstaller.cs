using Zenject;
using UnityEngine;
using Project.Configs;
using Project.Bootstrap;
using Project.Core.Services;
using Project.Core.Player.AttackSystem;
using Project.Core.Player.UpgradeSystem;
using Project.Core.GameCycle;
using Project.Core.Player;

namespace Project.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Player:")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private DefaultArrowStatsData _arrowStatsData;
        [SerializeField] private GameObject _arrowDefualPrefab;

        [Header("Enemy:")]
        [SerializeField] private GameObject _meleeEnemyPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameBehavior>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerStats>().AsSingle();
            Container.BindInterfacesAndSelfTo<ArrowStats>().AsSingle();
            Container.BindInterfacesTo<ArrowFactory>().AsSingle().WithArguments(_arrowDefualPrefab);
            Container.BindInterfacesTo<BulletObjectPool<ArrowData>>().AsSingle().WithArguments(_playerData.ArrowPoolMaxSize);
            Container.BindInterfacesTo<UpgradeController>().AsSingle().WithArguments(_arrowStatsData);
            Container.BindInterfacesTo<ShootingController>().AsSingle();
            Container.Bind<PlayerFactory>().AsSingle().WithArguments(_playerPrefab);
            Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();
            Container.BindInterfacesTo<EnemyTest>().AsSingle();

            Container.BindInterfacesTo<EntryPoint>().AsSingle().WithArguments(new EntryPointData { MeleeEnemyPrefab = _meleeEnemyPrefab});
        }
    }
}