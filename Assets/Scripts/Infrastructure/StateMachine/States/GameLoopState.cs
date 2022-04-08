namespace Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly LoadingCurtain _loadingCurtain;

        public GameLoopState(IGameStateMachine gameStateMachine, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            _loadingCurtain.Show();
        }
    }
}