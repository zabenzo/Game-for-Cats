using Infrastructure.AssetProvider;

namespace Infrastructure.Factory
{
    public class MainMenuFactory : IMainMenuFactory
    {
        private readonly IAssetProvider _assetProvider;

        public MainMenuFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
    }
}