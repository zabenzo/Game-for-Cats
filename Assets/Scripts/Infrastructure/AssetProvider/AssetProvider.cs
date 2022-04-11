using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private const string MainMenuCanvasPrefabPath = "MainMenu/MainMenuCanvas";
        private const string GameUIPrefabPath = "GameUI/GameUI";
        private const string GameEnvironmentPrefabPath = "";

        private readonly IStaticDataProvider _staticDataProvider;

        public AssetProvider(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
        }

        public GameObject MainMenuCanvas() => 
            Resources.Load<GameObject>(MainMenuCanvasPrefabPath);

        public GameObject GameUI() => 
            Resources.Load<GameObject>(GameUIPrefabPath);

        public GameObject GameEnvironment() => 
            Resources.Load<GameObject>(GameEnvironmentPrefabPath);

        public GameObject Mouse() =>
            _staticDataProvider.GetCurrentMouseType().MousePrefab;

        public AudioClip MouseSound() =>
            _staticDataProvider.GetCurrentMouseType().MouseSound;
    }
}