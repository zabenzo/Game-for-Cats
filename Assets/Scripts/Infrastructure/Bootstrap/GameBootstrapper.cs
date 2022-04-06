using Infrastructure.StateMachine.States;
using UnityEngine;

namespace Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;
        
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this, Instantiate(Curtain));
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}