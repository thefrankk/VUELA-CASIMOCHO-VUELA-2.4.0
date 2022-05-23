using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejorasManager : MonoBehaviour
{
    public int[] upgrade_cost;
    public Button[] upgrade_buttons;
    public GameObject confirmBuy_panel;

    private int currentUpgrade;

    public string[] upgradeInfo_string;
    public Text[] upgradeInfo;


    public Text[] upgradeTitle;
    public Text[] unlockedText;
    // <>
    // Start is called before the first frame update
    void OnEnable()
    {
        Manager.sharedInstance.LoadData();

        CheckButtons();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyUpgradeWord1()
    {
            currentUpgrade = 0;
            confirmBuy_panel.SetActive(true);
            upgradeInfo[0].text = upgradeInfo_string[0];

        CheckButtons();
    }


    public void BuyUpgrade()
    {
        switch(currentUpgrade)
        {
            case 0:

                if(GameController.diamonds >= upgrade_cost[currentUpgrade])
                {
                    GameController.diamonds -= upgrade_cost[currentUpgrade];
                    GameController.portal_word[currentUpgrade] = 1;

                    upgrade_buttons[0].image.color = Color.green;
                    //agregar sonido de compra

                    Manager.sharedInstance.SaveData();

                    CheckButtons();

                    DontBuy();
                }
                else
                {
                    SSTools.ShowMessage("No tienes diamantes suficientes", SSTools.Position.bottom, SSTools.Time.twoSecond);
                   
                }

                break;
            case 1:
                break;
            case 2:
                break;

        }
    }

    //Close Panel
    public void DontBuy()
    {
        confirmBuy_panel.SetActive(false);
    }


    void CheckButtons()
    {
        Debug.Log("hello" + GameController.portal_word[0]);

        for (int i = 0; i < GameController.portal_word.Length; i++)
        {
            if(GameController.portal_word[i] != 0)
            {
                upgrade_buttons[0].image.color = Color.green;
                upgrade_buttons[0].interactable = false;
                upgradeTitle[0].text = "Portal mundo " + (i + 1) + " disponible";
                unlockedText[0].text = "Desbloqueado";
            }
        }



    }






}
