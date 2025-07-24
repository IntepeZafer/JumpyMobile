using UnityEngine;
using GoogleMobileAds.Api;
public class BannerAdsManager : MonoBehaviour
{
    private BannerView bannerView;
    private void Start()
    {
        MobileAds.Initialize(initStatus => 
        {
            Debug.Log("Mobile Ads SDK initialized.");
            RequestBanner();
        });
    }
    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // Test ad unit ID
        AdSize adSize = new AdSize(728, 90); // Custom size for the banner
        bannerView = new BannerView(adUnitId, adSize, AdPosition.Top);
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
    }
    private void OnDestroy()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }
}
