using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener, IUnityAdsLoadListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    private string _gameId;
    private string intId = "Interstitial_Android";
    private string rewId = "Rewarded_Android";
    private string banId = "Banner_Android";

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }
    
    void Awake()
    {
        InitializeAds();
    }
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, true, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        Advertisement.Load(intId, this);
        Advertisement.Load(rewId, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void ShowAd()
    {
        Advertisement.Show(intId);
    }

    public void ShowAdWithBonus()
    {
        Advertisement.Show(rewId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(intId))
        {
            Debug.Log("IntAdsLoaded");
        }
        if (placementId.Equals(rewId))
        {
            Debug.Log("RewAdsLoaded");
        }
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        if (placementId.Equals(intId))
        {
            Debug.Log($"Unity IntAds Load Failed: {error.ToString()} - {message}");
        }
        if (placementId.Equals(rewId))
        {
            Debug.Log($"Unity RewAds Load Failed: {error.ToString()} - {message}");
        }
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) 
    {
        if (placementId.Equals(rewId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            //добавляем 1000 монет игроку
            //playerController.GetMoney(1000);
            //загружаем новую рекламу для следующего показа
            print("+1000");
            Advertisement.Load(rewId, this);
        }
    }
}
