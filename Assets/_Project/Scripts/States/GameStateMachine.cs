using System;
using System.Collections.Generic;
using Template._Project.Scripts.Services.AssetProvider;
using Template._Project.Scripts.Services.GameFactory;
using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.SaveLoad;
using Template._Project.Scripts.Services.StaticData;
using Template._Project.Scripts.TimeManagement;

namespace Template._Project.Scripts.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(IGameFactoryService gameFactoryService, IPersistentProgressService persistentProgress,
            IAssetProviderService assetProvider, IStaticDataService staticData, ISaveLoadService saveLoad,
            IInGameTimeService inGameTime)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(LoadProgressState)] = new LoadProgressState(this),
                [typeof(LoadHubState)] = new LoadHubState(this),
                [typeof(HubLoopState)] = new HubLoopState(this, gameFactoryService, persistentProgress, assetProvider),
                [typeof(LoadLevelState)] = new LoadLevelState(this, gameFactoryService, staticData),
                [typeof(GameLoopState)] = new GameLoopState(this, saveLoad, persistentProgress, inGameTime),
                [typeof(GameFinishedState)] = new GameFinishedState(this, persistentProgress, inGameTime),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            // The first state could be null on programm start 
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
            => _states[typeof(TState)] as TState;
    }
}