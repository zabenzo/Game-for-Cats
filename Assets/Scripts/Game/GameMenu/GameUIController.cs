using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using TMPro;

namespace Game.GameMenu
{
    public class GameUIController
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ScoreCounter.ScoreCounter _scoreCounter;

        public GameUIController(IGameStateMachine gameStateMachine, ScoreCounter.ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
            _gameStateMachine = gameStateMachine;
        }

        public void UpdateScore(TextMeshProUGUI text) => 
            text.text = $"SCORE: {_scoreCounter.GetCurrentScore().ToString()}";

        public void BackToMainMenu() => 
            _gameStateMachine.Enter<MainMenuState>();
    }
}