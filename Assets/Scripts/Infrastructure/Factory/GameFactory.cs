using Infrastructure.AssetProvider;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public GameObject CreateMouse() => 
            Object.Instantiate(_assetProvider.Mouse());

        public GameObject CreateGameUI()
        {
            return Object.Instantiate(_assetProvider.GameUI());
        }

        public GameObject CreateGameEnvironment()
        {
            return Object.Instantiate(_assetProvider.GameEnvironment());
        }
    }
}