using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using Infrastructure.StateMachine.States;
using Utility;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        
        private IState _currentState;

        public GameStateMachine(ServiceLocator.ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, serviceLocator, coroutineRunner),
                [typeof(MainMenuState)] = new MainMenuState(this, loadingCurtain, serviceLocator.Single<ISceneLoader>(), serviceLocator.Single<IMainMenuFactory>()),
                [typeof(LoadGameState)] = new LoadGameState(this, serviceLocator.Single<ISceneLoader>(), serviceLocator.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
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