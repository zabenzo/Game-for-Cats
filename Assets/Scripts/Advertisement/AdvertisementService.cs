using UnityEngine.Advertisements;

namespace Advertisement
{
    public class AdvertisementService : IAdvertisementService
    {
        private const string AndroidGameID = "4699011";
        private const string PlacementIdBannerAndroid = "Banner_Android";

        public AdvertisementService(bool testModeEnable)
        {
            UnityEngine.Advertisements.Advertisement.Initialize(AndroidGameID, testModeEnable);
            UnityEngine.Advertisements.Advertisement.Banner.Load(PlacementIdBannerAndroid);
            UnityEngine.Advertisements.Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }

        public bool IsLoaded() => 
            UnityEngine.Advertisements.Advertisement.Banner.isLoaded;

        public void Show() => 
            UnityEngine.Advertisements.Advertisement.Banner.Show(PlacementIdBannerAndroid);

        public void Hide() => 
            UnityEngine.Advertisements.Advertisement.Banner.Hide();
    }
}