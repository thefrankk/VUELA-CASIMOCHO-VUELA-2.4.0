using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAds : MonoBehaviour
{

    public bool bannerStay = false;

    public static ManagerAds instance;

   
   

    //<>
    public enum rewards
    {
        rewardCoinsMenu,
        rewardCoinsInGame,
        rewardPlayWithCoins,
        rewardReviveOnPlaying
    }

    public static rewards rewardState;
    // Start is called before the first frame update
    void Awake ()
    {
        //Singleton method
        if (instance == null)
        {
            instance = this;
        }
        else
        {
           // Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Banner
        /*if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuINFINITE_SELECTOR || GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuCHOOSEMODE || GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuDIFFICULTY_SELECTOR || GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuShop || GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuHuevos)
        {
            if (bannerStay != true)
            {
                Admob.include.BannerAd();
                bannerStay = true;
            }

        }
        else
        {
            if (bannerStay)
            {
                Admob.include.DestroyBanner();
            }
            bannerStay = false;
        }*/
           
    }

    public void showRewaredCoinsMenu()
    {
        rewardState = rewards.rewardCoinsMenu;
        Admob.include.showRewardAd();
    }

    public void showRewaredCoinsInGame()
    {
        rewardState = rewards.rewardCoinsInGame;
        Admob.include.showRewardAd();
    }

    public void showRewaredPlayWithCoins()
    {
        rewardState = rewards.rewardPlayWithCoins;
        Admob.include.showRewardAd();
    }

    public void showRewardRevivePlaying()
    {
        rewardState = rewards.rewardReviveOnPlaying;
        Admob.include.showRewardAd();
    }

    //interstitilia
    #region interstitilia


    public void showInterstitialAll()
    {
        Debug.Log("showing");
            Admob.include.ShowInter();
    }

    public void showInterstitial()
    {
        int a = Random.Range(0, 100);

        if (a >= 55)
        {
            Admob.include.ShowInter();
        }

       
    }

    public void showInterstitialBack()
    {
        int a = Random.Range(0, 100);

        if (a >= 80)
        {
            Admob.include.ShowInter();
        }

       
    }
    public void showInterstitialEggs()
    {
        int a = Random.Range(0, 100);

        if (a >= 40)
        {
            Admob.include.ShowInter();
        }

        
    }

    public void showInterstitialRevive()
    {
        int a = Random.Range(0, 100);

        if (a >= 50)
        {
            Admob.include.ShowInter();
        }

      
    }
    #endregion
}
