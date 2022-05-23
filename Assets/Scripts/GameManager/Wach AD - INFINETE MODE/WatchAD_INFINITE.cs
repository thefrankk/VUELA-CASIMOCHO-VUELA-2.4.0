using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchAD_INFINITE : MonoBehaviour
{
    public static WatchAD_INFINITE sharedInstance;

    public Text currentCoins;
    public GameObject RewardedAd;

    public Transform coinsDropping;

    public Button watchAd_button;


    private void Start()
    {
       // watchAd_button.interactable = true;
        sharedInstance = this;
        currentCoins.text = GameController.coinsOnPlay.ToString();
        RewardedAd.SetActive(false);
    }
    public void WatchAD()
    {
        currentCoins.text = GameController.coinsOnPlay.ToString();

        //Publicidad
        ManagerAds.instance.showRewaredCoinsInGame();
        //watchAd_button.interactable = false;



    }

   


    public void  AcceptReward()
    {

        if(GameController.modeInfinite)
        {
          //  watchAd_button.interactable = true;
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOverInfinite;
            
        }
        else
        {
          //  watchAd_button.interactable = true;
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.YouWin;
        }
          


        RewardedAd.SetActive(false);
        CollectCoins();

    }
    public void DontSeeAnAd()
    {

        

        if (GameController.modeInfinite)
        {
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOverInfinite;
            CollectCoins();
        }
        else
        {
            CollectCoins();
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.YouWin;
        }
            
    }



    public void CollectCoins()
    {
       

        GameController.coins += GameController.coinsOnPlay;

        GameController.recolectedCoins += GameController.coinsOnPlay;
        PlayerPrefs.SetInt("recolectedCoins", GameController.recolectedCoins);
       

        GameController.diamonds += GameController.diamondsOnPlay;
        HuevosManager.eggsSavings += GameController.eggsOnPlay;

        GameController.diamondsOnPlay = 0;
        GameController.eggsOnPlay = 0;


        Manager.sharedInstance.SaveData();

        
    }
}
