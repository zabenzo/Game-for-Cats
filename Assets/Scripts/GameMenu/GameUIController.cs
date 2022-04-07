using Infrastructure.StateMachine;
using TMPro;

namespace GameMenu
{
    public class GameUIController
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameUIController(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void UpdateScore(TextMeshProUGUI text, int score)
        {
            text.text = score.ToString();
        }

        public void BackToMainMenu()
        {
            
        }
    }
}