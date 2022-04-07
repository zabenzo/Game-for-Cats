using Game.Mouse;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadGameState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("Game", InitializeGameWorld);
        }

        private void InitializeGameWorld()
        {
            CreateMouse(out MouseLogic mouseLogic);
            
            GameObject gameUI = _gameFactory.CreateGameUI();
        }

        public void Exit()
        {
            
        }

        private void CreateMouse(out MouseLogic mouseLogic)
        {
            GameObject mouse = _gameFactory.CreateMouse();
            mouse.GetComponent<MouseMove>().Construct(moveSpeed: 3.0f);
            mouseLogic = mouse.GetComponent<MouseLogic>();
        }
    }
}