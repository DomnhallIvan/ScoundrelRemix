using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MobileAds.Initialize((InitializationStatus initstatus) =>
        {
            if (initstatus == null)
            {
                Debug.LogError("Google Mobile Ads initialization failed.");
                return;
            }

            Debug.Log("Google Mobile Ads initialization complete.");

            // Google Mobile Ads events are raised off the Unity Main thread. If you need to
            // access UnityEngine objects after initialization,
            // use MobileAdsEventExecutor.ExecuteInUpdate(). For more information, see:
            // https://developers.google.com/admob/unity/global-settings#raise_ad_events_on_the_unity_main_thread
        });
    }

    #region banner ad
#if UNITY_ANDROID
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/2934735716";
#else
        private const string AD_UNIT_ID = "unused";
#endif
#if UNITY_ANDROID
    private const string ANCHORED_ADAPTIVE_AD_UNIT_ID = "ca-app-pub-3940256099942544/9214589741";
#elif UNITY_IPHONE
        private const string ANCHORED_ADAPTIVE_AD_UNIT_ID = "ca-app-pub-3940256099942544/2435281174";
#else
        private const string ANCHORED_ADAPTIVE_AD_UNIT_ID = "unused";
#endif

    BannerView bannerView;

    public void CreateBannerView()
    {
        if (bannerView != null)
        {
            DestroyBannerView();
        }
        // [START create_banner_view]
        // Create a 320x50 banner at top of the screen.
        bannerView = new BannerView(AD_UNIT_ID, AdSize.Banner, AdPosition.Top);
        // [END create_banner_view]
    }

    public void LoadBannerView()
    {
        // [START load_banner_view]
        // Send a request to load an ad into the banner view.
        bannerView.LoadAd(new AdRequest());
        // [END load_banner_view]
    }

    public void ShowBanner()
    {
        if(bannerView != null)
        {
            CreateBannerView();
        }

        print("Showing Banner add");
        bannerView.Show();
    }

    private void DestroyBannerView()
    {
        // [START destroy_banner_view]
        if (bannerView != null)
        {
            // Always destroy the banner view when no longer needed.
            bannerView.Destroy();
            bannerView = null;
        }
        // [END destroy_banner_view]
    }

    #endregion
}
