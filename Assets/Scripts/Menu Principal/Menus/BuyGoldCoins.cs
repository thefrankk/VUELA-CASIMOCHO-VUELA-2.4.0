using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyGoldCoins : MonoBehaviour
{

    public static BuyGoldCoins sharedInstance;

    public GameObject buyGoldCoinsPanel;
    public Text currentGoldCoins;
    public Text currentCoin;

    private int goldCoinsCost = 40;

    // <>

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Update()
    {
        currentCoin.text = GameController.coins.ToString();
        currentGoldCoins.text = GameController.diamonds.ToString();
    }

    public void ChangeCoins()
    {
        if(GameController.coins >= goldCoinsCost)
        {

            MenusManager.MenusManagerInstance.BuySomething();
            GameController.coins -= goldCoinsCost;
           
            

            GameController.diamonds += 1;

            GameController.exchangedDiamonds += 1;
            PlayerPrefs.SetInt("exchangedDiamonds", GameController.exchangedDiamonds);

            Manager.sharedInstance.SaveData();
        }


    }

    //Buy Diamonds
    public void BuyDiamondsPurchase()
    {

        MenusManager.MenusManagerInstance.BuySomething();
        GameController.diamonds += 1000;
        GameController.exchangedDiamonds += 1000;
        PlayerPrefs.SetInt("exchangedDiamonds", GameController.exchangedDiamonds);

        Manager.sharedInstance.SaveData();

    }

    public void PURCHASEDIAMONDS()
    {
        IAPurchase.instace.BuyConsumable();
    }
    public void OpenPanel()
    {
        MenusManager.MenusManagerInstance.BackSound();
        buyGoldCoinsPanel.SetActive(true);
    }
    public void Accept()
    {
        MenusManager.MenusManagerInstance.BackSound();
        buyGoldCoinsPanel.SetActive(false);
    }


   

}
