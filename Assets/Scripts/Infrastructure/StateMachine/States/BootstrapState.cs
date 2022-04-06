using Infrastructure.AssetProvider;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ServiceLocator.ServiceLocator _serviceLocator;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, ServiceLocator.ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _coroutineRunner = coroutineRunner;

            RegisterServices();
        }

        public void Enter()
        {
            _gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterSingle<ISceneLoader>(new SceneLoader.SceneLoader(_coroutineRunner));
            _serviceLocator.RegisterSingle<IGameStateMachine>(_gameStateMachine);
            _serviceLocator.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider());
            _serviceLocator.RegisterSingle<IMainMenuFactory>(new MainMenuFactory(_serviceLocator.Single<IAssetProvider>()));
        }
    }
}