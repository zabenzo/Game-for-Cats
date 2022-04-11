using Advertisement;
using Infrastructure.AssetProvider;
using Infrastructure.Factory;
using Infrastructure.Input;
using Infrastructure.SceneLoader;
using Services.SoundService;
using Utility;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ServiceLocator.ServiceLocator _serviceLocator;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly AudioSourceController _audioSourceController;

        public BootstrapState(GameStateMachine gameStateMachine, ServiceLocator.ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain, AudioSourceController audioSourceController)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _coroutineRunner = coroutineRunner;
            _loadingCurtain = loadingCurtain;
            _audioSourceController = audioSourceController;

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
            _serviceLocator.RegisterSingle<IStaticDataProvider>(new StaticDataProvider());
            _serviceLocator.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider(_serviceLocator.Single<IStaticDataProvider>()));
            _serviceLocator.RegisterSingle<IGameFactory>(new GameFactory(_serviceLocator.Single<IAssetProvider>()));
            _serviceLocator.RegisterSingle<ISoundService>(new SoundService(_serviceLocator.Single<IAssetProvider>(), _audioSourceController.AudioSource));
            _serviceLocator.RegisterSingle<IMainMenuFactory>(new MainMenuFactory(_serviceLocator.Single<IAssetProvider>()));
        }
    }
}