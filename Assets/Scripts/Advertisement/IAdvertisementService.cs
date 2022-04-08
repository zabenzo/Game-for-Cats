using Infrastructure.ServiceLocator;

namespace Advertisement
{
    public interface IAdvertisementService : IService
    {
        bool IsLoaded();
        void Show();
        void Hide();
    }
}