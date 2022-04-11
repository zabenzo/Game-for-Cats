using Infrastructure.StateMachine;
using Services.SoundService;

namespace Infrastructure.Bootstrap
{
    public class Game
    {
        public IGameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain, AudioSourceController audioSourceController) => 
            GameStateMachine = new GameStateMachine(ServiceLocator.ServiceLocator.Container, coroutineRunner, loadingCurtain, audioSourceController);
    }
}