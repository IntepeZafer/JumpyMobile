using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    [Header("AdMob Test ID'leri")]
    [SerializeField] private string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField] private string interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";

    [Header("Reklamdan sonra geçilecek sahne (opsiyonel)")]
    [SerializeField] private string nextSceneName = "GameOver";

    [Header("Rastgele reklam ayarları")]
    [Range(0, 100)] public int interstitialChance = 15;     // %15 şansla geçiş reklamı
    [Range(0, 100)] public int bannerChance = 50;           // %50 şansla banner reklamı
    [SerializeField] private int minDeathsBeforeAd = 3;     // En az 3 ölüm geçmeden reklam çıkmaz
    [SerializeField] private float minAdInterval = 90f;     // 90 saniye içinde sadece 1 reklam

    private int deathCount = 0;
    private float lastAdTime = -999f;
    private bool isInterstitialLoaded = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Sahne geçişlerinde silinmez
    }

    void Start()
    {
        Debug.Log("🚀 AdsManager başlatıldı.");
        MobileAds.Initialize(initStatus =>
        {
            Debug.Log("✅ AdMob başlatıldı.");

            int bannerRoll = Random.Range(0, 100);
            if (bannerRoll < bannerChance)
            {
                Debug.Log($"📢 Banner reklam gösteriliyor (%{bannerRoll})");
                LoadBanner();
            }
            else
            {
                Debug.Log($"📢 Banner reklam atlandı (%{bannerRoll})");
            }

            LoadInterstitial();
        });

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == nextSceneName)
        {
            Debug.Log("🎬 GameOver sahnesi yüklendi.");
            TryShowInterstitialAd();
        }
    }

    private void LoadBanner()
    {
        bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
        Debug.Log("✅ Banner yüklendi.");
    }

    private void LoadInterstitial()
    {
        InterstitialAd.Load(interstitialAdUnitId, new AdRequest(), (ad, error) =>
        {
            if (error != null)
            {
                Debug.Log("❌ Geçiş reklamı yüklenemedi: " + error.GetMessage());
                return;
            }

            Debug.Log("✅ Geçiş reklamı yüklendi.");
            interstitial = ad;
            isInterstitialLoaded = true;

            interstitial.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("📴 Reklam kapandı. Yeni reklam yükleniyor...");
                LoadInterstitial(); // Yeni reklam hazırla
            };
        });
    }

    public void TryShowInterstitialAd()
    {
        deathCount++;

        if (deathCount < minDeathsBeforeAd)
        {
            Debug.Log($"📉 Yeterli ölüm olmadı ({deathCount}/{minDeathsBeforeAd}), reklam gösterilmiyor.");
            return;
        }

        if (Time.time - lastAdTime < minAdInterval)
        {
            Debug.Log($"⏱️ Süre dolmadı ({Time.time - lastAdTime:F1}s < {minAdInterval}s), reklam gösterilmiyor.");
            return;
        }

        int roll = Random.Range(0, 100);
        Debug.Log($"🎲 Reklam zar atıldı: {roll} < {interstitialChance}");

        if (roll < interstitialChance)
        {
            ShowInterstitialAd();
            deathCount = 0; // reklam gösterildiyse sayaç sıfırla
            lastAdTime = Time.time;
        }
        else
        {
            Debug.Log("⏩ Zar tutmadı, reklam gösterilmedi.");
        }
    }

    public void ShowInterstitialAd()
    {
        if (isInterstitialLoaded && interstitial != null && interstitial.CanShowAd())
        {
            Debug.Log("🎯 Geçiş reklamı gösteriliyor...");
            interstitial.Show();
            isInterstitialLoaded = false;
        }
        else
        {
            Debug.Log("⚠️ Reklam hazır değil.");
        }
    }

    private void OnDestroy()
    {
        bannerView?.Destroy();
        interstitial?.Destroy();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
