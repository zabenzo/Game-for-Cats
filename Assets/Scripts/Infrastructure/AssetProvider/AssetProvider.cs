using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private const string MainMenuCanvasPrefabPath = "MainMenu/MainMenuCanvas";

        public GameObject MainMenuCanvas() => 
            Resources.Load<GameObject>(MainMenuCanvasPrefabPath);
    }
}