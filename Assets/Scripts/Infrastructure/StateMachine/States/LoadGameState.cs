using Game.GameMenu;
using Game.Mouse;
using Game.ScoreCounter;
using Infrastructure.AssetProvider;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using StaticData;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IStaticDataProvider _staticDataProvider;

        public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory, LoadingCurtain loadingCurtain, IStaticDataProvider staticDataProvider)
        {
            _gameFactory = gameFactory;
            _loadingCurtain = loadingCurtain;
            _staticDataProvider = staticDataProvider;
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
            
            _loadingCurtain.Hide();
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
            MouseType currentMouseType = _staticDataProvider.GetCurrentMouseType();
            mouseLogic = mouse.GetComponent<MouseLogic>();
            mouse.GetComponent<MouseMove>().Construct(moveSpeed: currentMouseType.Speed);
            mouse.GetComponent<MouseSoundReproduction>().Construct(delay: currentMouseType.SoundDelay);
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