using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject MainMenuCanvas();
    }
}