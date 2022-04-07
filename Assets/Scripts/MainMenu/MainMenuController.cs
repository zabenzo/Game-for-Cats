using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;

namespace MainMenu
{
    public class MainMenuController
    {
        private readonly IGameStateMachine _gameStateMachine;
        
        public MainMenuController(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void OnPlayButtonClick()
        {
            _gameStateMachine.Enter<LoadGameState>();
        }
    }
}