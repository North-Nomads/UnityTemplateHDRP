using System.Collections.Generic;
using Template._Project.Scripts.Data;
using Template._Project.Scripts.Services.GameFactory;
using Template._Project.Scripts.Services.PersistentProgress;
using UnityEngine;
using ZombieBarrels.Services.Progress;

namespace Template._Project.Scripts.Services.SaveLoad
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactoryService _gameFactoryService;
        private readonly List<IProgressUpdater> _saveWriterServices;
        private readonly IGameFactoryService _gameFactory;

        public PlayerPrefsSaveLoadService(IPersistentProgressService progressService, IGameFactoryService gameFactory, List<IProgressUpdater> savedServices)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
            _saveWriterServices = savedServices;
        }

        public PlayerProgress LoadProgress()
            => PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();

        public void SaveProgress()
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.PlayerProgress);

            foreach (var writerService in _saveWriterServices)
                writerService.UpdateProgress(_progressService.PlayerProgress);

            PlayerPrefs.SetString(ProgressKey, _progressService.PlayerProgress.ToJson());
        }
    }
}