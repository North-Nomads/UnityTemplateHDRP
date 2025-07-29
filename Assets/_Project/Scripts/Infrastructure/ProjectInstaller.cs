using Template._Project.Scripts.Services.AssetProvider;
using Template._Project.Scripts.Services.GameFactory;
using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.SaveLoad;
using Template._Project.Scripts.Services.StaticData;
using Template._Project.Scripts.States;
using Template._Project.Scripts.TimeManagement;
using Reflex.Core;
using UnityEngine;

namespace Template._Project.Scripts.Infrastructure
{
    /// <summary>
    /// Defines the bindings to the root global container
    /// </summary>
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public GameStateMachine StateMachine;
        
        private readonly IGameFactoryService _gameFactory;
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IAssetProviderService _assetProvider;
        private readonly IStaticDataService _staticData;
        private readonly ISaveLoadService _saveLoad;
        private readonly IInGameTimeService _inGameTime;

        private void Awake()
        {
            StateMachine = new GameStateMachine(_gameFactory, _persistentProgress, _assetProvider, _staticData, _saveLoad, _inGameTime); 
            StateMachine.Enter<BootstrapState>();
        }

        /// <summary>
        /// Reflex looks for & uses IInstaller instance to build a DI container
        /// </summary>
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(AssetProviderService), typeof(IAssetProviderService));
            builder.AddSingleton(typeof(GameFactoryService), typeof(IGameFactoryService));
            builder.AddSingleton(typeof(PersistentProgressService), typeof(IPersistentProgressService));
            builder.AddSingleton(typeof(PlayerPrefsSaveLoadService), typeof(ISaveLoadService));
            builder.AddSingleton(typeof(StaticDataService), typeof(IStaticDataService));
            builder.AddSingleton(typeof(InGameTimeService), typeof(IInGameTimeService));

            builder.AddSingleton(typeof(GameStateMachine));
        }
    }
}