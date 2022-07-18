using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
/* HOW TO ADD NEW WORLD
 * 1) Create a new array of buttons and add all the buttons to this array(on the inspector)
 * 2) Same thing with the lock symbol
 * 3) Create a bool to detect if the world is unlocked or locked
 * 4) create a int to set the price
 * 5) on the function "ReadButtonsAndLocks" add a new bucle FOR following the another concepts.
 * 6) Create a new fuction with the name "PlayLevel.." and follow the other concepts.
 * 7)Now, in the GameController, you'v to add the new level on the function "ToTheNextLevel"
 * 8) on LEVELSELECTOR CARRUSEL, good luck my friend
 * 9) in the Hierarchy, copy another world and paste, just change the obvius points
 * 10) 
 */
public class LOGICLevelSelector : MonoBehaviour
{

    public static LOGICLevelSelector sharedInstance;

    public Button[] levelButtons;
    public Button[] levelButtonsW2;
    public Button[] levelButtonsW3;
    public Button[] levelButtonsW4;
    public GameObject[] lockSymbol;
    public GameObject[] lockSymbolW2;
    public GameObject[] lockSymbolW3;
    public GameObject[] lockSymbolW4;

    //Texto de las replays
    public Text[] replaysText;
    //rejugar nivel panel
    public GameObject panelReplay;

    //Replay levels
    [SerializeField]
    public GameObject[,] replaysSymbols;

    //Replay with coins
    [SerializeField]
    public GameObject PanelReplay2;

    //Decos
    public GameObject[] decos;
    public GameObject[] decosAlpha;

   

   
    //<>
    [SerializeField]
    bool unlockWorld2 = false;
    [SerializeField]
    bool unlockWorld3 = false;
    [SerializeField]
    bool unlockWorld4 = false;
    [SerializeField]
    int LevelCounter;

    
    public static int priceToUnlockWorld2 = 15; 
    public static int priceToUnlockWorld3 = 38;
    public static int priceToUnlockWorld4 = 49;


    //firstentrance
    public static bool firstEntryLogicLevel = false;



    // <>

    private void Awake()
    {
        //Singleton method
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
       
        firstEntryLogicLevel = false;

        ReadButtonsAndLocks();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
        {
            if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuLEVEL_SELECTOR && firstEntryLogicLevel != true)
            {
               

                ReadButtonsAndLocks();
                ReadReplays();
                UnlockWords();

                firstEntryLogicLevel = true;


            }
        }
    }


    int value;
    string gameLevelValue;
    void GenericPlayLevel(int a, string gameLevel)
    {
        if (GameController.PlayedLevels[a] && GameManager_Menu.CountingReplays[a] <= 2) 
        {
            panelReplay.SetActive(true);
        }
        else
        {
            GameController.modeSurvival = true;
            GameManager_Menu.currentLevelIndex = a;
            GameManager_Menu.gameManagerMenu.FadeIn();
            MenusManager.MenusManagerInstance.BackSound();

            GameController.playerHabs = GameController.CheckHabilitiesPlayer.outHabilities;

            GameController.gamesPlayed += 1;
            PlayerPrefs.SetInt("gamesPlayed", GameController.gamesPlayed);

            StartCoroutine(TransicionSceneGameLevel(gameLevel));
        }

        value = a;
        gameLevelValue = gameLevel;
    }
    

    public void PlayLevel1()
    {
        GenericPlayLevel(0, "Game_level1");
    }

    public void PlayLevel2()
    {
        GenericPlayLevel(1, "Game_level2");
    }

    public void PlayLevel3()
    {
        GenericPlayLevel(2, "Game_level3");
    }

    public void PlayLevel4()
    {
        GenericPlayLevel(3, "Game_level4");
    }

    public void PlayLevel5()
    {
        GenericPlayLevel(4, "Game_level5");
    }

    public void PlayLevel6()
    {
        GenericPlayLevel(5, "Game_level6");
    }
    public void PlayLevel7()
    {
        GenericPlayLevel(6, "Game_level7");
    }  
    public void PlayLevel8()
    {
        GenericPlayLevel(7, "Game_level8");
    }
    public void PlayLevel9()
    {
        GenericPlayLevel(8, "Game_level9");
    }
    public void PlayLevel10()
    {
        GenericPlayLevel(9, "Game_level10");
    } 
    public void PlayLevel11()
    {
        GenericPlayLevel(10, "Game_level11");
    }
    public void PlayLevel12()
    {
        GenericPlayLevel(11, "Game_level12");
    }
    public void PlayLevel13()
    {
        GenericPlayLevel(12, "Game_level13");
    }
    public void PlayLevel14()
    {
        GenericPlayLevel(13, "Game_level14");
    }
    public void PlayLevel15()
    {
        GenericPlayLevel(14, "Game_level15");
    }
    public void PlayLevel16()
    {
        GenericPlayLevel(15, "Game_level16");
    } 
    public void PlayLevel17()
    {
        GenericPlayLevel(16, "Game_level17");
    } 
    public void PlayLevel18()
    {
        GenericPlayLevel(17, "Game_level18");
    } 
    public void PlayLevel19()
    {
        GenericPlayLevel(18, "Game_level19");
    } 
    public void PlayLevel20()
    {
        GenericPlayLevel(19, "Game_level20");
    } 
    public void PlayLevel21()
    {
        GenericPlayLevel(20, "Game_level21");
    }
    public void PlayLevel22()
    {
        GenericPlayLevel(21, "Game_level22");
    }
    public void PlayLevel23()
    {
        GenericPlayLevel(22, "Game_level23");
    }
    public void PlayLevel24()
    {
        GenericPlayLevel(23, "Game_level24");
    }
    
    IEnumerator TransicionSceneGameLevel(string name)
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameLevel;
        SceneManager.LoadScene(name, LoadSceneMode.Single);
        GameController.gamecontroller.StartGame();
    }


    public void ReplayLevelWithCoins()
    {
        ManagerAds.rewardState = ManagerAds.rewards.rewardPlayWithCoins;
        ManagerAds.instance.showRewaredPlayWithCoins();

        

    }

    public void ReplayLevel()
    {
        replayWithCoins(value, gameLevelValue);
        PanelReplay2.SetActive(false);
    }

    public void ReplayLevelWithoutCoins()
    {
        replayWithOutCoins(value, gameLevelValue);
    }
    public void replayWithCoins(int a, string gameLevel)
    {
        panelReplay.SetActive(false);

        GameController.PlayedLevels[a] = false;

        GameController.modeSurvival = true;
        GameManager_Menu.currentLevelIndex = a;
        GameManager_Menu.gameManagerMenu.FadeIn();
        MenusManager.MenusManagerInstance.BackSound();

        GameController.gamesPlayed += 1;
        PlayerPrefs.SetInt("gamesPlayed", GameController.gamesPlayed);

        StartCoroutine(TransicionSceneGameLevel(gameLevel));


    }
    public void replayWithOutCoins(int a, string gameLevel)
    {
        panelReplay.SetActive(false);


        GameController.modeSurvival = true;
        GameManager_Menu.currentLevelIndex = a;
        GameManager_Menu.gameManagerMenu.FadeIn();
        MenusManager.MenusManagerInstance.BackSound();

        GameController.gamesPlayed += 1;
        PlayerPrefs.SetInt("gamesPlayed", GameController.gamesPlayed);

        StartCoroutine(TransicionSceneGameLevel(gameLevel));
    }

    public void Volver()
    {
        panelReplay.SetActive(false);
    }

    public void ReadButtonsAndLocks()
    {

        //Mundo 1 - niveles
        for (int i = 0; i < levelButtons.Length; i++)
        {

            if (i > GameManager_Menu.levelReached)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }
        }
        //Lock level 1
        for (int i = 0; i < lockSymbol.Length; i++)
        {
            if (i  > GameManager_Menu.levelReached)
            {
                lockSymbol[i].SetActive(true);
            }
            else
            {
                lockSymbol[i].SetActive(false);
            }

        }
        //Mundo 2 - Niveles
        for (int i = 0; i < levelButtonsW2.Length; i++)
        {
            if (unlockWorld2)
            {
                if (i + 8 > GameManager_Menu.levelReached)
                {
                    levelButtonsW2[i].interactable = false;
                }
                else
                {
                    levelButtonsW2[i].interactable = true;
                }
            }
            else
            {
                levelButtonsW2[i].interactable = false;
            }
        }

        //Lock level 2
        for (int i = 0; i < lockSymbolW2.Length; i++)
        {
            if (unlockWorld2)
            {
                //Reachedlevels por mundo + 1
                    if (i + 8 > GameManager_Menu.levelReached)
                    {
                    lockSymbolW2[i].SetActive(true);
                    }
                    else
                    {
                    lockSymbolW2[i].SetActive(false);
                    }
                
            }
            else
            {
                lockSymbolW2[i].SetActive(true);
            }

        }

        //Mundo 3 - Niveles
        for (int i = 0; i < levelButtonsW3.Length; i++)
        {
            if (unlockWorld3)
            {
                if (i + 16 > GameManager_Menu.levelReached)
                {
                    levelButtonsW3[i].interactable = false;
                }
                else
                {
                    levelButtonsW3[i].interactable = true;
                }
            }
            else
            {
                levelButtonsW3[i].interactable = false;
            }
        }

        //Lock level 3
        for (int i = 0; i < lockSymbolW3.Length; i++)
        {
            if (unlockWorld3)
            {
                    //Reachedlevels por mundo + 1
                if (i + 16 > GameManager_Menu.levelReached)
                {
                    lockSymbolW3[i].SetActive(true);
                }
                else
                {
                    lockSymbolW3[i].SetActive(false);
                }
            }
            else
            {
                lockSymbolW3[i].SetActive(true);
            }

        }

        //Mundo 4 - Niveles
        for (int i = 0; i < levelButtonsW4.Length; i++)
        {
            if (unlockWorld4)
            {
                if (i + 24 > GameManager_Menu.levelReached)
                {
                    levelButtonsW4[i].interactable = false;
                }
                else
                {
                    levelButtonsW4[i].interactable = true;
                }
            }
            else
            {
                levelButtonsW4[i].interactable = false;
            }
        }

        //Lock level 4
        for (int i = 0; i < lockSymbolW4.Length; i++)
        {
            if (unlockWorld4)
            {
                    //Reachedlevels por mundo + 1
                    if (i + 24 > GameManager_Menu.levelReached)
                {
                    lockSymbolW4[i].SetActive(true);
                }
                else
                {
                    lockSymbolW4[i].SetActive(false);
                }
            }
            else
            {
                lockSymbolW4[i].SetActive(true);
            }
        }

    }


    public void ReadReplays()
    {
        for (int i = 0; i < GameManager_Menu.levelReached; i++)
        {
        
            replaysText[i].text = GameManager_Menu.CountingReplays[i].ToString();

        }
    }
   public void UnlockWords()
    {
        
        if(GameController.stars >= 15)
        {
            unlockWorld2 = true;
            decos[0].SetActive(false);
            Image decosA = decosAlpha[0].GetComponent<Image>();
            Color c = decosA.color;
            c.a = 1;

            decosA.color = c;


        }   
        else if( GameController.stars >= 38)
        {
            unlockWorld3 = true;
        }
        else if(GameController.stars >= 49)
        {
            unlockWorld4 = true;
        }
           
    }




  /*  public void LoadReplays()
    {
        for (int i = 0; i < GameManager_Menu.levelReached; i++)
        {
            GameManager_Menu.CountingReplays[i] = PlayerPrefs.GetInt("CountingReplays" + i, 0);

            GameManager_Menu.playLevelAgain[i, GameManager_Menu.CountingReplays[i]] = Convert.ToBoolean(PlayerPrefs.GetInt("playLevelAgain" + i));
        }
    }*/
    
   
}


