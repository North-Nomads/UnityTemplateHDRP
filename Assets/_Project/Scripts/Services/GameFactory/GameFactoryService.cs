using System.Collections.Generic;
using Template._Project.Scripts.Services.AssetProvider;
using Template._Project.Scripts.Services.PersistentProgress;

namespace Template._Project.Scripts.Services.GameFactory
{
    public class GameFactoryService : IGameFactoryService
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgressReadWriter> ProgressWriters { get; } = new();
        
        private readonly IAssetProviderService _assetProvider;

        public GameFactoryService(IAssetProviderService assetProvider)
        {
            _assetProvider = assetProvider;
        }
    }
}