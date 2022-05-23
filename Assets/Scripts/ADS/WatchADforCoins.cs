using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WatchADforCoins : MonoBehaviour
{

    public GameObject panel;
    public GameObject noAdsToShow;

    public static WatchADforCoins instance;

    private void Awake()
    {
        instance = this;

    }





    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }



    public void WatchAd()
    {
        ClosePanel();
        ManagerAds.instance.showRewaredCoinsMenu();
    }
 
   
}
