using System;
using Infrastructure.ServiceLocator;

namespace Infrastructure.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}