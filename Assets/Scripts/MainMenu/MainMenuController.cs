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
            // TODO:: Enter into new load state and initialize all that scene need.
            _gameStateMachine.Enter<LoadGameState>();
        }
    }
}