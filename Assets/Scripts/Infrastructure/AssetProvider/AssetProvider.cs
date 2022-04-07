using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private const string MainMenuCanvasPrefabPath = "MainMenu/MainMenuCanvas";
        private const string MousePrefab = "Game/Mouse";
        private const string GameUIPrefab = "";
        private const string GameEnvironmentPrefab = "";


        public GameObject MainMenuCanvas() => 
            Resources.Load<GameObject>(MainMenuCanvasPrefabPath);

        public GameObject Mouse() => 
            Resources.Load<GameObject>(MousePrefab);

        public GameObject GameUI() => 
            Resources.Load<GameObject>(GameUIPrefab);

        public GameObject GameEnvironment() => 
            Resources.Load<GameObject>(GameEnvironmentPrefab);
    }
}