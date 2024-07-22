using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdScript : MonoBehaviour
{
    private void Awake()
    {
        IronSource.Agent.init("1f2054b95",IronSourceAdUnits.REWARDED_VIDEO);
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
        
    }

    private void SdkInitializationCompletedEvent()
    {
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;
    }

    void OnApplicationPause(bool isPaused)
    {
        IronSource.Agent.onApplicationPause(isPaused);
    }


    public void ShowAdd()
    {
        Debug.Log(IronSource.Agent.isRewardedVideoAvailable());
        if(IronSource.Agent.isRewardedVideoAvailable())
            IronSource.Agent.showRewardedVideo();
    }

    private void RewardedVideoOnAdClickedEvent(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {
        throw new NotImplementedException();
    }

    private void RewardedVideoOnAdRewardedEvent(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {
        GetComponent<EndScreenManager>().Double();
    }

    private void RewardedVideoOnAdShowFailedEvent(IronSourceError arg1, IronSourceAdInfo arg2)
    {
        throw new NotImplementedException();
    }

    private void RewardedVideoOnAdUnavailable()
    {
        throw new NotImplementedException();
    }

    private void RewardedVideoOnAdAvailable(IronSourceAdInfo obj)
    {
        throw new NotImplementedException();
    }

    private void RewardedVideoOnAdClosedEvent(IronSourceAdInfo obj)
    {
        throw new NotImplementedException();
    }

    private void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo obj)
    {
        throw new NotImplementedException();
    }
}
