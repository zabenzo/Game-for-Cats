using System;
using System.Collections.Generic;
using Advertisement;
using Infrastructure.AssetProvider;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using Infrastructure.StateMachine.States;
using Services.SoundService;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        
        private IState _currentState;

        public GameStateMachine(ServiceLocator.ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain, AudioSourceController audioSourceController)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, serviceLocator, coroutineRunner, loadingCurtain, audioSourceController),
                [typeof(MainMenuState)] = new MainMenuState(this, loadingCurtain, serviceLocator.Single<ISceneLoader>(), serviceLocator.Single<IMainMenuFactory>()),
                [typeof(LoadGameState)] = new LoadGameState(this, serviceLocator.Single<ISceneLoader>(), serviceLocator.Single<IGameFactory>(), loadingCurtain, serviceLocator.Single<IStaticDataProvider>()),
                [typeof(GameLoopState)] = new GameLoopState(this, loadingCurtain, serviceLocator.Single<IAdvertisementService>(), coroutineRunner)
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}