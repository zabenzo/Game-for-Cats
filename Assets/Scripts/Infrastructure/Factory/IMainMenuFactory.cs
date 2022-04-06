using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IMainMenuFactory : IService
    {
        public GameObject CreateMainMenuCanvas();
    }
}