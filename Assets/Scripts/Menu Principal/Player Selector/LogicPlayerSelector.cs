using UnityEngine;
using System;
using UnityEngine.UI;

public class LogicPlayerSelector : MonoBehaviour
{

    public Button[] select_player; //coins
    public Button[] select_player_stars;//stars
    
    
    public Image[] playerImage;
    public Image[] playerImageStars;

    public Image[] lockImage; //coins
    public Image[] lockImageStars;

    public Text[] unlockText;
    public Text[] unlockTextStars;
    


    public bool[] unlockPlayer;
    public bool[] unlockPlayerStars;

    public static int[] unlockPrice;
    public static int[] unlockPriceStars;

    public static bool firstEntrance = false;


    // <>
    // Start is called before the first frame update

    void Start()
    {
        LoadData();
        unlockPrice = new int[3];
        unlockPriceStars = new int[1];
        //Precios de los heroes
        unlockPrice[0] = 0; // casimocho
        unlockPrice[1] = 2; //cupido - coins
        unlockPrice[2] = 50; //zombimocho - coins
        //Precio en entrellas
        unlockPriceStars[0] = 1; //todomocho stars
       
    }

    void LoadData()
    {
        //players x coins
       /* unlockPlayer[0] = Convert.ToBoolean(PlayerPrefs.GetInt("unlockCasimocho", 0));
        unlockPlayer[1] = Convert.ToBoolean(PlayerPrefs.GetInt("unlockCupido", 0));
        unlockPlayer[2] = Convert.ToBoolean(PlayerPrefs.GetInt("unlockZombimocho", 0));
        //players x stars
        unlockPlayerStars[0] = Convert.ToBoolean(PlayerPrefs.GetInt("unlockTodomocho", 0));*/
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
        {
            if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR && !firstEntrance)
            {
                ReadButtons();
                firstEntrance = true;
            }
        }
       // ReadButtons();
    }

   /* public void PlayCasimocho()
    {
        if(unlockPlayer[0] == false)
        {
            unlockPlayer[0] = true;
            PlayerPrefs.SetInt("unlockCasimocho", Convert.ToInt32(unlockPlayer[0]));
            ReadButtons();
        }
        else
        {
            

            MenusManager.MenusManagerInstance.BackSound();
            GameController.player = GameController.playersToPlay.casimocho;
            MenusManager.MenusManagerInstance.CHOOSE_A_MODE();
        }
        
       
        
    }

    public void PlayTodoMocho()
    {
        if (unlockPlayerStars[0] == false)
        {

            unlockPlayerStars[0] = true;
            PlayerPrefs.SetInt("unlockTodomocho", Convert.ToInt32(unlockPlayerStars[0]));
            ReadButtons();
        }
        else
        {
            

            MenusManager.MenusManagerInstance.BackSound();
            GameController.player = GameController.playersToPlay.todomocho;
            MenusManager.MenusManagerInstance.CHOOSE_A_MODE();
        }
    }

    public void PlayZombiMocho()
    {
        if (unlockPlayer[2] == false)
        {
            GameController.coins -= unlockPrice[2];
            PlayerPrefs.SetInt("coins", GameController.coins);
            unlockPlayer[2] = true;
            PlayerPrefs.SetInt("unlockZombimocho", Convert.ToInt32(unlockPlayer[3]));
            ReadButtons();
        }
        else
        {
            

            MenusManager.MenusManagerInstance.BackSound();
            GameController.player = GameController.playersToPlay.zombimocho;
            MenusManager.MenusManagerInstance.CHOOSE_A_MODE();
        }
    }
   */

    //funciones 

    public void ReadButtons()
    {
        
        //Desbloqueo de personajes por MONEDAS
        for (int i = 0; i < select_player.Length; i++)
        {
            if (unlockPlayer[i] == false)
            {
                unlockText[i].text = "DESBLOQUEAR";
                if(unlockPrice[i] <= GameController.coins)
                {
                   select_player[i].interactable = true;
                    //stars
                  /*  if(unlockPlayer[2] = false)
                    {
                        select_player[2].interactable = false;
                    }*/
                    
                }
                else
                {
                   select_player[i].interactable = false;

                    //stars
                   /* if (unlockPlayer[2] = false)
                    {
                        select_player[2].interactable = false;
                    }*/

                }
            }
            else
            {
                unlockText[i].text = "SELECCIONAR";
                select_player[i].interactable = true;
            }
        }

        //Desbloqueo de personajes por estrellas
        for (int i = 0; i < select_player_stars.Length; i++)
        {

            if (unlockPlayerStars[i] == false)
            {
                unlockTextStars[i].text = "DESBLOQUEAR";
                if (unlockPriceStars[i] <= GameController.stars)
                {
                    select_player_stars[i].interactable = true;                                       
                }
                else
                {
                    select_player_stars[i].interactable = false;                                  
                }
            }
            else
            {
                unlockTextStars[i].text = "SELECCIONAR";
                select_player_stars[i].interactable = true;
            }
        }

        //Lock Player
        for (int i = 0; i < select_player.Length; i++)
        {
            if (unlockPlayer[i] == false)
            {                           
                lockImage[i].color = Color.red;
                playerImage[i].color = Color.black;


            }
            else
            {              
                lockImage[i].color = Color.green;
                playerImage[i].color = Color.white;
            }

        }

        //Lock Player stars
        for (int i = 0; i < select_player_stars.Length; i++)
        {
            if (unlockPlayerStars[i] == false)
            {
                lockImageStars[i].color = Color.red;
                playerImageStars[i].color = Color.black;


            }
            else
            {
                lockImageStars[i].color = Color.green;
                playerImageStars[i].color = Color.white;
            }

        }



    }
}
