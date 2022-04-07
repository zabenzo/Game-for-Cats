using Infrastructure.ServiceLocator;

namespace Utility
{
    public interface IScreenUtility : IService
    {
        float LeftLimit();
        float RightLimit();
        float TopLimit();
        float BottomLimit();
    }
}