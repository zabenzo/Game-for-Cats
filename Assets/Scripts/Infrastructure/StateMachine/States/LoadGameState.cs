using Infrastructure.SceneLoader;

namespace Infrastructure.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadGameState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("Game");
        }

        public void Exit()
        {
            
        }
    }
}