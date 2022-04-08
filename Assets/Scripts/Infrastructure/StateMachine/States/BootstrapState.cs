using Advertisement;
using Infrastructure.AssetProvider;
using Infrastructure.Factory;
using Infrastructure.Input;
using Infrastructure.SceneLoader;
using Utility;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ServiceLocator.ServiceLocator _serviceLocator;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly LoadingCurtain _loadingCurtain;

        public BootstrapState(GameStateMachine gameStateMachine, ServiceLocator.ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _coroutineRunner = coroutineRunner;
            _loadingCurtain = loadingCurtain;

            RegisterServices();
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterSingle<IAdvertisementService>(new AdvertisementService(testModeEnable: true));
            _serviceLocator.RegisterSingle<IInputService>(new InputService());
            _serviceLocator.RegisterSingle<IScreenUtility>(new ScreenUtility());
            _serviceLocator.RegisterSingle<ISceneLoader>(new SceneLoader.SceneLoader(_coroutineRunner));
            _serviceLocator.RegisterSingle<IGameStateMachine>(_gameStateMachine);
            _serviceLocator.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider());
            _serviceLocator.RegisterSingle<IGameFactory>(new GameFactory(_serviceLocator.Single<IAssetProvider>()));
            _serviceLocator.RegisterSingle<IMainMenuFactory>(new MainMenuFactory(_serviceLocator.Single<IAssetProvider>()));
        }
    }
}