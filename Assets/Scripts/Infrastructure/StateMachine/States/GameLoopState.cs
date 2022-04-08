using System.Collections;
using Advertisement;

namespace Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IAdvertisementService _advertisementService;
        private readonly ICoroutineRunner _coroutineRunner;

        public GameLoopState(IGameStateMachine gameStateMachine, LoadingCurtain loadingCurtain, IAdvertisementService advertisementService, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _advertisementService = advertisementService;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            StartShowingAdBanner();
        }

        public void Exit()
        {
            StopShowingAdBanner();
            _loadingCurtain.Show();
        }

        private void StopShowingAdBanner() => 
            _advertisementService.Hide();

        private void StartShowingAdBanner() => 
            _coroutineRunner.StartCoroutine(ShowBannerRoutine());

        private IEnumerator ShowBannerRoutine()
        {
            // while (!_advertisementService.IsLoaded())
            // {
            //     yield return null;
            // }
            yield return null;
            _advertisementService.Show();
        }
    }
}