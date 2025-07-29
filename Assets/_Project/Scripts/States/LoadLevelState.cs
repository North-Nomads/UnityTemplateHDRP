using Template._Project.Scripts.Services.GameFactory;
using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace Template._Project.Scripts.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IPersistentProgressService _progressService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticData;
        private readonly IGameFactoryService _gameFactoryService;
        private readonly Canvas _loadingCurtain;

        public LoadLevelState(GameStateMachine gameStateMachine, IGameFactoryService gameFactoryService, IStaticDataService staticData)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactoryService = gameFactoryService;
            _staticData = staticData;
        }

        public void Enter(string sceneName)
        {
            // _gameFactory.CleanUp();
            _loadingCurtain.gameObject.SetActive(true);
        }

        public void Exit() 
            => _loadingCurtain.gameObject.SetActive(false);

        private void OnLoaded()
        {
            /*LevelConfig config = _staticData.ForLevel(_progressService.Progress.CurrentLevel);
            PlayerCore playerCore = InitializeGameWorld(config);
            _levelProgress.LoadLevelConfig(config, playerCore);
            _buildingStore.ResetMoney();
            InitializeMobSpawners();
            _buildingService.MapTilemap = Object.FindObjectOfType<Tilemap>(); //if it works
            _buildingService.OnSceneLoaded();
            InitializeBuilder();
            InitializeInGameHUD();
            InitializeCamera();
            _buildingStore.AddMoney(config.InitialMoney);
            _gameStateMachine.Enter<GameLoopState>();*/
        }

        private void InitializeCamera()
        {
            /*GameObject cameraSpawnPoint = GameObject.FindGameObjectWithTag(Constants.CameraSpawnPoint);
            _cameraService.InitializeCamera(cameraSpawnPoint.transform.position);*/
        }

        private void InitializeBuilder()
        {
            /*PlayerBuildBehaviour playerBuildBehaviour = _gameFactory.CreateBuilder();
            playerBuildBehaviour.Initialize(_staticData, _buildingService, _gameWindowService);*/
        }

        /*private PlayerCore InitializeGameWorld(LevelConfig config)
        {
            /*PlayerCore playerCore = InitializePlayerBase(config);
            return playerCore;#1#
        }*/

        private void InitializeInGameHUD()
        {
            /*_uiFactory.CreateUIRoot();
            _gameWindowService.GetWindow(GameWindowId.InGameHUD)
                .GetComponent<InGameHUD>()
                .ProvideSceneData(_buildingService, _buildingStore);
            _gameWindowService.GetWindow(GameWindowId.EndGame);
            _gameWindowService.GetWindow(GameWindowId.BeforeGameHUD);
            InitializePauseMenu();
            _gameWindowService.Open(GameWindowId.BeforeGameHUD);*/
        }

        private void InitializePauseMenu()
        {
            /*InGamePauseMenu pauseMenu = _gameWindowService.GetWindow(GameWindowId.InGamePauseMenu)
                .GetComponent<InGamePauseMenu>();
            pauseMenu.RestartButtonPressed += (_, _) =>
                _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
            pauseMenu.ReturnToMenuButtonPressed += (_, _) => _gameStateMachine.Enter<HubState>();*/
        }

        /*private PlayerCore InitializePlayerBase(LevelConfig config)
        {
            /*PlayerCore playerCore = _gameFactory.CreatePlayerCore(GameObject.FindGameObjectWithTag(Constants.CoreSpawnPoint));
            
            playerCore.Initialize(_mobSpawnerService, config);
            return playerCore;#1#
        }*/


        private void InitializeMobSpawners()
        {
            /*WaypointHolder[] spawnerSpots = Object.FindObjectsByType<WaypointHolder>(FindObjectsSortMode.None);
            
            _mobSpawnerService.LoadConfigToSpawners(_levelProgress.LoadedWave, spawnerSpots,
                _levelProgress.LoadedLevelConfig.DeltaBetweenSpawns);*/
        }
    }
}