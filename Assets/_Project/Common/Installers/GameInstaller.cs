using Zenject;
using UnityEngine;
using Project.Configs;
using Project.Bootstrap;
using Project.Core.Services;

namespace Project.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Player:")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private PlayerData _playerData;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerFactory>().AsSingle().WithArguments(_playerPrefab);
            Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();

            Container.BindInterfacesTo<EntryPoint>().AsSingle();
        }
    }
}