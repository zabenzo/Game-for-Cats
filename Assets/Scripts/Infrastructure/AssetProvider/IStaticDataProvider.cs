using Infrastructure.ServiceLocator;
using StaticData;

namespace Infrastructure.AssetProvider
{
    public interface IStaticDataProvider : IService
    {
        MouseType GetCurrentMouseType();
        void SetIndex(int index);
    }
}