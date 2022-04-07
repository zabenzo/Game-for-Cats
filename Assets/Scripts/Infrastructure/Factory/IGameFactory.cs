using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateMouse();
        GameObject CreateGameUI();
        GameObject CreateGameEnvironment();
    }
}