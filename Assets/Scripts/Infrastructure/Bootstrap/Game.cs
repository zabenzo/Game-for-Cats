using Infrastructure.StateMachine;

namespace Infrastructure.Bootstrap
{
    public class Game
    {
        public IGameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            GameStateMachine = new GameStateMachine(ServiceLocator.ServiceLocator.Container, coroutineRunner, loadingCurtain);
        }
    }
}