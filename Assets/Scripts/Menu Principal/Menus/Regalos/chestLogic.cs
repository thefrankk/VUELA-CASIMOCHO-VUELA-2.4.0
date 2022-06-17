using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class chestLogic : MonoBehaviour
{

    [SerializeField]
    public Image mainPlayerImage;
    public Sprite[] playerImages;
    public Text playerName;
    public Text playerType;

    public GameObject giftPanel;
    public Button claimButton;
    public Text claimedGift;
    public ParticleSystem particles;

   // public bool[] claimableObjects = new bool[1];

    public static Dictionary<int, bool> claimObjectsIndex = new Dictionary<int, bool>();

    public cardClass card = new cardClass();
    
    string componentIndex = 1.ToString();  

    private void OnEnable()
    {

        //Debug.Log(GameController.giftclass.GET_List(0));
       
       
        
         claimObjectsIndex.Add(1, GameController.giftclass.GET_List(0));

        for (int i = 0; i < GameController.giftclass.GET_GiftCount() + 1; i++)
        {

            if(GameController.giftclass.GET_List(i)  == false)
            {
                
                mainPlayerImage.sprite = playerImages[i];

                playerName.text = card.getPlayerName(i);
                playerType.text = card.getPlayerType();
                claimButton.interactable = true;
                claimedGift.gameObject.SetActive(false);

                break;
            }
            else
            {
                Debug.Log("asdasd");
                if (claimObjectsIndex.ContainsKey(i + 1) && claimObjectsIndex[i + 1] == true)
                {
                    mainPlayerImage.sprite = playerImages[i];
                    playerName.text = card.getPlayerName(i);
                    playerType.text = card.getPlayerType();
                    claimedGift.gameObject.SetActive(true);
                    claimButton.interactable = false;
                    return;
                }
            }

           
        }



        
    }

   /* public async void Recorrer() 
    {
        await Task.Delay(2);


    }*/

   
    public void Claim()
    {
        Debug.Log(card.getPlayerName(0));

        

            if (claimObjectsIndex[Convert.ToInt32(componentIndex)] == false)
            {


                GameController.giftclass.modifyList(Convert.ToInt32(componentIndex) - 1, claimObjectsIndex[Convert.ToInt32(componentIndex)]);


                //Recompensa.....
                Gift(Convert.ToInt32(componentIndex));

                //Si la key del claimobjects esta desactivada, quiere decir que el personaje ya fue claimeado.
                claimObjectsIndex[Convert.ToInt32(componentIndex)] = true;
                claimButton.interactable = false;

                saveCards.Save(Convert.ToInt32(componentIndex));
                claimedGift.gameObject.SetActive(true);
                GameController.giftclass.checkGifts();
                particles.Play();
                //Manager.sharedInstance.SaveData();
            }
       

    }

    public void Gift(int index)
    {
        switch(index)
        {
            case 1: //Mommy Gift

                PlayerManagerMenus.cart[112, 0] = true;
                PlayerManagerMenus.playersLocked[(GameController.playersToPlay)112] = true;

                PlayerPrefs.SetInt("PlayerLock" + 112, Convert.ToInt32(PlayerManagerMenus.playersLocked[(GameController.playersToPlay)112]));

                PlayerPrefs.SetInt("cart1" + 112 + "carts2" + 0, Convert.ToInt32(PlayerManagerMenus.cart[112, 0] = true));

                PlayerPrefs.SetInt("repeatedCarts" + 112, PlayerManagerMenus.repeatedCarts[112] = 1);

                break;
        }
    }

    public void ChangeClaimableObject()
    {
        GameObject name = EventSystem.current.currentSelectedGameObject.gameObject;
        componentIndex = name.GetComponentInChildren<Text>().text;

        if (!claimObjectsIndex.ContainsKey(Convert.ToInt32(componentIndex)))
                claimObjectsIndex.Add(Convert.ToInt32(componentIndex), GameController.giftclass.GET_List(Convert.ToInt32(componentIndex) - 1));

            claimButton.interactable = true;
            mainPlayerImage.sprite = playerImages[Convert.ToInt32(componentIndex) - 1];
            playerName.text = card.getPlayerName(Convert.ToInt32(componentIndex) - 1);
            playerType.text = card.getPlayerType();

        if (claimObjectsIndex.ContainsKey(Convert.ToInt32(componentIndex)) && claimObjectsIndex[Convert.ToInt32(componentIndex)] == true)
        {
            claimButton.interactable = false;
            return;
        }

        //Deshabilitamos el regalo del mes siguiente.
        if(Convert.ToInt32(componentIndex) == 2)
        {
            claimButton.interactable = false;
        }

    }

    public void Open()
    {
        giftPanel.SetActive(true);
    }

    public static void Close()
    {
        claimObjectsIndex.Clear();
    }

}
