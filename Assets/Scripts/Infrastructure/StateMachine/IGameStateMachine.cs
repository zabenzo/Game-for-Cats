using Infrastructure.ServiceLocator;

namespace Infrastructure.StateMachine
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>() where TState : IState;
    }
}