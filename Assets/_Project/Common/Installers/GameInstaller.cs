using Zenject;
using UnityEngine;
using Project.Configs;
using Project.Bootstrap;

namespace Project.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Player:")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private PlayerData _playerData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EntryPoint>().WithArguments(
                new PlayerEntryPointData 
                { 
                    PlayerData = _playerData,
                    PlayerPrefab = _playerPrefab
                });
        }
    }
}