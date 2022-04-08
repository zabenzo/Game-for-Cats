using Game.GameMenu;
using Game.Mouse;
using Game.ScoreCounter;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("Game", InitializeGameWorld);
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitializeGameWorld()
        {
            CreateMouse(out MouseLogic mouseLogic);
            CreateScoreCounter(mouseLogic, out ScoreCounter scoreCounter);
            CreateGameUI(scoreCounter, mouseLogic);
        }

        public void Exit()
        {
            
        }

        private void CreateScoreCounter(MouseLogic mouseLogic, out ScoreCounter scoreCounter)
        {
            scoreCounter = new ScoreCounter();
            mouseLogic.OnMouseClicked += scoreCounter.AddScore;
        }

        private void CreateMouse(out MouseLogic mouseLogic)
        {
            GameObject mouse = _gameFactory.CreateMouse();
            mouse.GetComponent<MouseMove>().Construct(moveSpeed: 3.0f);
            mouseLogic = mouse.GetComponent<MouseLogic>();
        }

        private void CreateGameUI(ScoreCounter scoreCounter, MouseLogic mouseLogic)
        {
            GameObject gameUI = _gameFactory.CreateGameUI();
            GameUIController gameUIController = new GameUIController(_gameStateMachine, scoreCounter);
            GameUI gameUIComponent = gameUI.GetComponent<GameUI>();
            gameUIComponent.OnBackToMainMenuClicked += gameUIController.BackToMainMenu;
            gameUIComponent.UpdateScoreText += gameUIController.UpdateScore;
        }
    }
}