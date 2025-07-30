using System;
using Template._Project.Scripts.Services.AssetProvider;
using Template._Project.Scripts.Services.GameFactory;
using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.UIFactory;

namespace Template._Project.Scripts.States
{
    public class HubLoopState : IState
    {
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IGameFactoryService _gameFactoryService;
        private readonly IAssetProviderService _assetProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly GameStateMachine _stateMachine;

        public HubLoopState(GameStateMachine gameStateMachine, IGameFactoryService gameFactoryService,
            IPersistentProgressService persistentProgress, IAssetProviderService assetProvider, ISceneLoader sceneLoader,
            IUIFactory uiFactory)
        {
            _stateMachine = gameStateMachine;
            _gameFactoryService = gameFactoryService;
            _persistentProgress = persistentProgress;
            _assetProvider = assetProvider;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _sceneLoader.Load(ScenePath.HubSceneName, onLoaded: InitializeScene);
        }

        public void Exit()
        {
            
        }


        private void InitializeScene()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            //_uiFactory.CreateUIRoot();
            // InitializeMenuWindows();
            _uiFactory.InstantiateWindow(HubWindowId.Hub);
        }

        /*private void InformProgressReaders()
        {
            foreach (var saveService in _saveReaderServices)
                saveService.LoadProgress(_progressService.Progress);
        }*/

        private void InitializeMenuWindows()
        {
            SetupStartMenu();
            SetupLevelsSelectMenu();
        }

        private void SetupLevelsSelectMenu()
        {
            /*var levelsMenu = _windowService.GetWindow(WindowId.Levels).GetComponent<LevelsWindow>();
            levelsMenu.gameObject.SetActive(false);
            levelsMenu.LevelLaunched += OnLevelLaunched;

            foreach (OpenWindowButton button in levelsMenu.GetComponentsInChildren<OpenWindowButton>()) 
                button.Construct(_windowService);*/
        }

        private void SetupStartMenu()
        {
            /*var gameMenu = _windowService.GetWindow(WindowId.Hub).GetComponent<HubMenu>();
            gameMenu.gameObject.SetActive(true);
            gameMenu.PlayerLaunchedGame += OnPlayerLaunchedGame;

            foreach (OpenWindowButton button in gameMenu.GetComponentsInChildren<OpenWindowButton>()) 
                button.Construct(_windowService);*/
        }

        private void OnLevelLaunched(object sender, int levelIndex)
        {
            /*if (levelIndex == Constants.TutorialLevelIndex)
                _stateMachine.Enter<LoadTutorialState>();
            else
                _stateMachine.Enter<LoadLevelState, string>($"Level{levelIndex}");*/
        }

        private void OnPlayerLaunchedGame(object sender, EventArgs e)
        {
            /*if (!_progressService.Progress.HasFinishedTutorial)
                _stateMachine.Enter<LoadTutorialState>();
            else
                _stateMachine.Enter<LoadLevelState, string>("Level1");*/
        }
    }
}