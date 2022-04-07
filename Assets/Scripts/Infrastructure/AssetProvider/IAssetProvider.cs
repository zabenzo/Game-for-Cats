using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject MainMenuCanvas();
        public GameObject Mouse();
        public GameObject GameUI();
        public GameObject GameEnvironment();
    }
}