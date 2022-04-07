namespace Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameLoopState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}