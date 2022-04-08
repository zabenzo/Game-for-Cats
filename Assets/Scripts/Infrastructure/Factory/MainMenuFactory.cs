using Infrastructure.AssetProvider;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class MainMenuFactory : IMainMenuFactory
    {
        private readonly IAssetProvider _assetProvider;

        public MainMenuFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public GameObject CreateMainMenuCanvas() => 
            Object.Instantiate(_assetProvider.MainMenuCanvas(), Vector2.zero, Quaternion.identity);
    }
}