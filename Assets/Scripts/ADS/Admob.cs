using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{
    //private string bannerId = "ca-app-pub-3940256099942544/6300978111";

    //Interstitial de test ca-app-pub-3940256099942544/1033173712
    //Rewared test ca-app-pub-3940256099942544/5224354917

    private string appID = "ca-app-pub-2282644264228516~3643693005";
    private string interID = "ca-app-pub-2282644264228516/5747746621"; // ca-app-pub-2282644264228516/5747746621
    private string rewardID = "ca-app-pub-2282644264228516/9403070548";// ca-app-pub-2282644264228516/9403070548



    public BannerView adBanner;
    public InterstitialAd adInter;
    public RewardedAd adRewarded;

    public Revive revive;




    public static Admob include;

    private void Awake()
    {

        //Singleton method
        if (include == null)
        {
            include = this;
        }
        else
        {
            Destroy(gameObject);
        }

       

        LoadRewaredAd();
        ResInter();
    }

    //Sector Banner
    #region sector banner
   /* public void BannerAd()
    {
        this.adBanner = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);

        this.adBanner.OnAdLoaded += this.HandleOnAdLoaded;
        this.adBanner.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;

        AdRequest request = new AdRequest.Builder().Build();

        this.adBanner.LoadAd(request);
    }

    public void DestroyBanner()
    {
            adBanner.Destroy();
    }*/

    #endregion

    //Sector interstitial

    #region interstitial
    public void ResInter()
    {
        adInter = new InterstitialAd(interID);
        // Called when an ad request has successfully loaded.
        this.adInter.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.adInter.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.adInter.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.adInter.OnAdClosed += HandleOnAdClosed;

        // Called when the ad click caused the user to leave the application.
        //this.adInter.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();

        adInter.LoadAd(request);

    }


    public void ShowInter()
    {
        if(adInter.IsLoaded())
        {
            adInter.Show();
            ResInter();
        }
    }
    #endregion

    //Sector rewardd video
    public void LoadRewaredAd()
    {
        adRewarded = new RewardedAd(rewardID);
        AdRequest request = new AdRequest.Builder().Build();
        adRewarded.LoadAd(request);

        // Called when the ad is closed.
        adRewarded.OnAdClosed += HandleRewardedAdClosed;
        // Called when the user should be rewarded for interacting with the ad.
        adRewarded.OnUserEarnedReward += HandleUserEarnedReward;

    }

  public void showRewardAd()
    {
        if(adRewarded.IsLoaded())
        {
           
            adRewarded.Show();
            LoadRewaredAd();
        }
        else
        {
            SSTools.ShowMessage("No hay publicidades. Try again.", SSTools.Position.bottom, SSTools.Time.twoSecond);
            SSTools.ShowMessage("O reinicia la aplicacion. ", SSTools.Position.top, SSTools.Time.twoSecond);
            LoadRewaredAd();
        }
            
    }

    public void CerrarAd()
    {
       // Debug.Log("se ejecuta algo cuando se cierra ");
    }
    public void LoadRewardAd()
    {
        
    }
  

 

    #region datos
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                           + args.ToString());
    }
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
       Debug.Log("ejectura algo cuando se cierra el anuncio");
    }

    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        switch(ManagerAds.rewardState)
        {
            case ManagerAds.rewards.rewardCoinsMenu:

                GameController.coins += 60;
                MenusManager.MenusManagerInstance.BuySomething();

                break;

            case ManagerAds.rewards.rewardCoinsInGame:

                GameController.coinsOnPlay = GameController.coinsOnPlay * 2;
                WatchAD_INFINITE.sharedInstance.RewardedAd.SetActive(true);
               

                break;

            case ManagerAds.rewards.rewardPlayWithCoins:

                LOGICLevelSelector.sharedInstance.PanelReplay2.SetActive(true);

                break;

            case ManagerAds.rewards.rewardReviveOnPlaying:

                GameManager_Menu.guiOneTAP = true;
                GameManager_Menu.gameManagerMenu.FadeIn();

                Debug.Log("revive player");


                GameController.gStates = GameController.GamingStates.pendingAlive;

                revive.StartCoroutine(revive.restartGame());

                break;

        }

      
        Manager.sharedInstance.SaveData();

        //Debug.Log("se ha reclamado la recompensa");
    }

  
    #endregion
}


