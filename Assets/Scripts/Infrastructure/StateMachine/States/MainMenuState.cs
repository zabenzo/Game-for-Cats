using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using MainMenu;
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
            
        }

        private void InitializeMainMenu()
        {
            MainMenuController mainMenuController = new MainMenuController(_sceneLoader);
            GameObject mainMenuCanvas = _mainMenuFactory.CreateMainMenuCanvas();
            mainMenuCanvas.GetComponent<MainMenu.MainMenu>().OnPlayButtonClick += mainMenuController.OnPlayButtonClick;
        }
    }
}