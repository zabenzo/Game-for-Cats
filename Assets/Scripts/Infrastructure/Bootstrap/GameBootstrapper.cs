using Infrastructure.StateMachine.States;
using Services.SoundService;
using UnityEngine;

namespace Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;
        public AudioSourceController AudioSourceController;
        
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this, Instantiate(Curtain), Instantiate(AudioSourceController));
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}