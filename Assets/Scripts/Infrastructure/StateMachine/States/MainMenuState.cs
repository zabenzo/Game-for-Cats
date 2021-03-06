using Game.MainMenu;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class MainMenuState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IMainMenuFactory _mainMenuFactory;

        public MainMenuState(IGameStateMachine gameStateMachine, LoadingCurtain loadingCurtain, ISceneLoader sceneLoader, IMainMenuFactory mainMenuFactory)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _mainMenuFactory = mainMenuFactory;
        }
        
        public void Enter()
        {
            _sceneLoader.Load("MainMenu", InitializeMainMenu);
        }

        public void Exit()
        {
            _loadingCurtain.Show();
        }

        private void InitializeMainMenu()
        {
            MainMenuController mainMenuController = new MainMenuController(_gameStateMachine);
            GameObject mainMenuCanvas = _mainMenuFactory.CreateMainMenuCanvas();
            mainMenuCanvas.GetComponent<MainMenu>().OnPlayButtonClick += mainMenuController.OnPlayButtonClick;
            _loadingCurtain.Hide();
        }
    }
}