using System;
using System.Collections;
using System.IO.IsolatedStorage;
using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class AdManager : MonoBehaviour
{
    public static AdManager Instance;
    private float timePassedTillLastAd;
    [SerializeField] private float minimumTimeBetweenAds;

    private string testId = "3863B0DE3158C0FD8295B27D56C2F6D5";

    private string appId;
    private string interstitialId;
    private string rewardedId;
    private string bannerId;

    public bool testAds;  


    private void Init()
    {
        appId = AdmobIds.appId;
        if (!testAds)
        {
            interstitialId = AdmobIds.intersitialId;
            rewardedId = AdmobIds.rewardedId;
        }
        else
        {
            interstitialId = AdmobIds.intersitialTestId;
            rewardedId = AdmobIds.rewardedTestId;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        Init();
        // Initialize the Google Mobile Ads SDK.       
        MobileAds.Initialize(s => {});
        StartCoroutine(load());
    }

    private IEnumerator load()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        
        RequestInterstitial();
        RequestRewarded();
    }


    void Update()
    {
        timePassedTillLastAd += Time.deltaTime;
    }

    public InterstitialAd interstitial;

    private void RequestInterstitial()
    {
        interstitial?.Destroy();
        this.interstitial = new InterstitialAd(interstitialId);
        //interstitial.OnAdClosed += ReloadInterstitial;
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
        Debug.Log(interstitial);
    }

    private BannerView bannerView;
    private void RequestBanner()
    {
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

    public RewardedAd rewardedAd;

    private void RequestRewarded()
    {
        this.rewardedAd = new RewardedAd(rewardedId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        Debug.Log("interstitial");
        if (CanPlayInterstitial())
        {
            interstitial.OnAdClosed += ReloadInterstitial;
            timePassedTillLastAd = 0;
            interstitial.Show();
        }
        
    }

    public void ShowBanner(EventArgs e)
    {
        bannerView.Show();
    }

    public void ShowRewarded()
    {
        if (CanPlayRewarded())
        {
            rewardedAd.OnAdClosed += ReloadRewarded;
           // timePassedTillLastAd = 0;
            rewardedAd.Show();
        }
    }
    
    public bool CanPlayInterstitial()
    {
        Debug.Log(interstitial != null);
        Debug.Log(timePassedTillLastAd);
        Debug.Log(minimumTimeBetweenAds);
        Debug.Log(timePassedTillLastAd >= minimumTimeBetweenAds);
        Debug.Log(interstitial.IsLoaded());
        
        return interstitial != null &&
               timePassedTillLastAd >= minimumTimeBetweenAds && interstitial.IsLoaded();
    }

    public bool CanPlayRewarded()
    {
        return rewardedAd != null && rewardedAd.IsLoaded();
    }

    
    private void ReloadInterstitial(object sender, EventArgs e)
    {

        Debug.Log("reload");
        Time.timeScale = 0;
        triedReloadInterstitial = true;
        interstitial.OnAdClosed -= ReloadInterstitial;
        RequestInterstitial();
    }

    private bool triedReloadRewarded = false;
    private void ReloadRewarded(object sender, EventArgs e)
    {
        triedReloadRewarded = false;
        rewardedAd.OnAdClosed -= ReloadRewarded;
        RequestRewarded();
    }   
    
    private void TryReloadRewardedAgain(object sender, EventArgs e)
    {
        rewardedAd.OnAdFailedToLoad -= TryReloadRewardedAgain;
        if(triedReloadRewarded)
            return;
        triedReloadRewarded = true;
        RequestRewarded();
    }  
    
    private bool triedReloadInterstitial = false;
    private void TryReloadInterstitialAgain(object sender, EventArgs e)
    {
        interstitial.OnAdFailedToLoad -= TryReloadInterstitialAgain;
        if(triedReloadInterstitial)
            return;
        triedReloadInterstitial = true;
        RequestRewarded();
    }
}