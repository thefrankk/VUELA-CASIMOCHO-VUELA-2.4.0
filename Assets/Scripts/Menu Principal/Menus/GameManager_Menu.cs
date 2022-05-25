using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameManager_Menu : MonoBehaviour
{

    public static int BETA_TESTER = 0;
    //Singleton method
    public static GameManager_Menu gameManagerMenu;
    //Gameobjects a activar
    public GameObject gui_gaming;
    public GameObject gui_gaming_objectos;
    public GameObject gui_gameOver;
    public GameObject gui_gameOverInfinite;
    public GameObject gui_gameOver_objetos;
    public GameObject gui_youWin;
    public GameObject GUI_PAUSE;
    public GameObject gui_TapToPlay;
    public GameObject gui_isSubLevel;
    public GameObject GUI_LOADINGSCENE;
    public GameObject gui_watchAD;
    public GameObject gui_revive;

    //Gameobject segun partida
    public GameObject GUI_DISTANCE;
    public GameObject GUI_CURRENTLEVEL;

   public static bool DontActivatePlayerSelector;

    public Animator anim;
    

    //Paneles para desativar botones
    public GameObject panel_UI_GameOver;
    public GameObject panel_UI_YouWin;


    public static bool[,] playLevelAgain;
    public static int[] CountingStarsPerLevel;
    public static int[] CountingReplays;
    public static bool enteredLevel = false;


    //Test
    public LOGICLevelSelector logicLevelSelector;
    //Check scene

    //bool para que se ejecute solo 1 vez los codigos 

    public bool ActivateONEtime;
    public static bool guiOneTAP = true;
    public static bool loadingScene = true;


    // <>
    //Referenciamos cada una de las escenas
    public enum stateForScene
    {
        GameMenu,
        GameInfinite,
        GameLevel,
        GameOver,
        WatchAD,
        ReviveMenu,
        GameOverInfinite,
        YouWin
    }

    //Referenciamos cada una de los estados del juego donde va a estar el player

    public enum eachStateForGame
    {
        //Dentro del GameMenu
        MenuPrincipal, 
        MenuCHOOSEMODE,
        MenuLEVEL_SELECTOR,
        MenuPLAYER_SELECTOR,
        MenuINFINITE_SELECTOR,
        MenuDIFFICULTY_SELECTOR,
        MenuOptions,
        MenuAlbum,
        MenuShop,
        MenuMejoras,
        MenuHuevos,
        Menu_SelectorMundo1,
        Menu_SelectorMundo2,
        Menu_SelectorMundo3,
        Menu_SelectorMundo4,
        //Infinte
        GameInfinite,
        //Dentro del GameLevel
        GameMundo1_Level1,
        GameMundo1_Level2,
        GameMundo1_Level3,
        GameMundo1_Level4,
        GameMundo1_Level5,
        GameMundo1_Level6,
        GameMundo1_Level7,
        GameMundo1_Level8,
        GameMundo1_Level9,
        GameMundo2_Level1,
        GameMundo2_Level2,
        GameMundo2_Level3,
        GameMundo2_Level4,
        GameMundo2_Level5,
        GameMundo2_Level6,
        GameMundo2_Level7,
        GameMundo2_Level8,
        GameMundo2_Level9,
        GameMundo3_Level1,
        GameMundo3_Level2,
        GameMundo3_Level3,
        GameMundo3_Level4,
        GameMundo3_Level5,
        GameMundo3_Level6,
        GameMundo3_Level7,
        GameMundo3_Level8,
        GameMundo3_Level9,
        GameMundo4_Level1,
        GameMundo4_Level2,
        GameMundo4_Level3,
        GameMundo4_Level4,
        GameMundo4_Level5,
        GameMundo4_Level6,
        GameMundo4_Level7,
        GameMundo4_Level8,
        GameMundo4_Level9,
    }

    //Controlador de niveles en modo MUNDOS POR NIVELES
    public static int levelReached = 0;
    public static int currentLevelIndex = 0;
    //Controlador de mundos en modo INFINITO
    public static int currentMundoIndex = 0;
    



    // public static checkLevelMap currentLevelMap;
    public static stateForScene currentScene;
    public static eachStateForGame currentEachState;

    public static bool callLevelPlayed;
    public static void LevelPlayed()
    {
        //Cantidad de niveles
  
        for (int i = 0; i < GameController.PlayedLevels.Length; i++)
        {

            if (GameController.PlayedLevels[i] == true)
            {
               
            }
            else
                GameController.PlayedLevels[i] = false;

            if (i >= GameController.PlayedLevels.Length)
            {
                
                return;
            }
        }

        
    }

    private void Awake()
    {
        
       
        BETA_TESTER = PlayerPrefs.GetInt("BETATESTER", 0);

        if(BETA_TESTER == 1)
        {
            Manager.sharedInstance.ClearDataExist();

            Manager.sharedInstance.ClearData();

            BETA_TESTER = 0;
            PlayerPrefs.SetInt("BETATESTER", BETA_TESTER);
        }


        //Seteamos los fps
        Application.targetFrameRate = 144;


        playLevelAgain = new bool[32, 4];
        CountingReplays = new int[32];

        CountingStarsPerLevel = new int[32];

        for (int i = 0; i < GameManager_Menu.levelReached; i++)
        {
            GameManager_Menu.CountingStarsPerLevel[i] = PlayerPrefs.GetInt("starsGainPerLevel" + i, 0);
            GameManager_Menu.CountingReplays[i] = PlayerPrefs.GetInt("CountingReplays" + i, 0);

            GameManager_Menu.playLevelAgain[i, GameManager_Menu.CountingReplays[i]] = Convert.ToBoolean(PlayerPrefs.GetInt("playLevelAgain" + i));
        }

        currentScene = stateForScene.GameMenu;
        currentEachState = eachStateForGame.MenuPrincipal;

        
        GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.none;
        GameController.gamecontroller.levelType = GameController.typesOfLevels.none;

        DontDestroyOnLoad(gameObject);

        //Singleton method
        if (gameManagerMenu == null)
        {
            gameManagerMenu = this;
        }
        else
        {
            Destroy(gameObject);
        }


     

    }
    // Start is called before the first frame update
    void Start()
    {
        callLevelPlayed = true;
        //Levels jugados
       LevelPlayed();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        //Acciones de update en cada escena, manejo de GUI.
        switch (currentScene)
        {
            case stateForScene.GameInfinite:

               
                // FadeOut();
                if (guiOneTAP)
                {
                    gui_gaming.SetActive(false);
                    gui_TapToPlay.SetActive(true);

                    switch(GameController.gamecontroller.levelType)
                    {
                        case GameController.typesOfLevels.level:
                            gui_isSubLevel.SetActive(false);

                            break;

                        case GameController.typesOfLevels.subLevel:
                            gui_isSubLevel.SetActive(true);

                            break;
                    }

                }
                else if (guiOneTAP == false)
                {
                    gui_gaming.SetActive(true);
                    gui_TapToPlay.SetActive(false);
                }

                GUI_DISTANCE.SetActive(true);
                GUI_CURRENTLEVEL.SetActive(false);

                gui_gameOver.SetActive(false);
                gui_gameOverInfinite.SetActive(false);

                

                gui_youWin.SetActive(false);
                gui_revive.SetActive(false);

                break;
            case stateForScene.GameLevel:

                if(loadingScene)
                {
                    GUI_LOADINGSCENE.SetActive(true);
                    gui_gaming.SetActive(false);
                    //gui_TapToPlay.SetActive(false);

                    LoadingSceneFunction();

                } else if (!loadingScene)
                {
                    GUI_LOADINGSCENE.SetActive(false);

                    if (guiOneTAP)
                    {
                        gui_gaming.SetActive(false);
                        gui_TapToPlay.SetActive(true);
                        gui_isSubLevel.SetActive(false);

                        /*switch (GameController.gamecontroller.levelType)
                        {
                            case GameController.typesOfLevels.level:

                                gui_isSubLevel.SetActive(false);

                                break;

                            case GameController.typesOfLevels.subLevel:

                                gui_isSubLevel.SetActive(true);

                                break;
                        }*/
                    }
                    else
                    {
                        gui_gaming.SetActive(true);
                        gui_TapToPlay.SetActive(false);
                    }
                }
                    
                 
               

                GUI_DISTANCE.SetActive(false);
                GUI_CURRENTLEVEL.SetActive(true);

                gui_gameOver.SetActive(false);
                gui_gameOverInfinite.SetActive(false);
                gui_watchAD.SetActive(false);
                gui_youWin.SetActive(false);
                gui_revive.SetActive(false);

                break;
            case stateForScene.GameMenu:
                
                switch(currentEachState)
                {
                    case eachStateForGame.MenuPrincipal:

                        if(callLevelPlayed)
                           LevelPlayed();

                        callLevelPlayed = false;

                        LOGICLevelSelector.firstEntryLogicLevel = false;

                        // FadeOut();
                        gui_gaming.SetActive(false);
                        GUI_DISTANCE.SetActive(false);
                        GUI_CURRENTLEVEL.SetActive(false);

                        gui_gameOverInfinite.SetActive(false);
                        gui_gameOver.SetActive(false);
                        gui_watchAD.SetActive(false);
                        gui_youWin.SetActive(false);

                        gui_revive.SetActive(false);

                        break;

                    case eachStateForGame.MenuCHOOSEMODE:
                        
                       
                          //  FadeOut();
                            gui_gaming.SetActive(false);
                            gui_gameOver.SetActive(false);
                        GUI_DISTANCE.SetActive(false);
                        GUI_CURRENTLEVEL.SetActive(false);
                        gui_gameOverInfinite.SetActive(false);
                        gui_watchAD.SetActive(false);
                        gui_youWin.SetActive(false);

                        gui_revive.SetActive(false);


                        break;
                    case eachStateForGame.MenuPLAYER_SELECTOR:

                        callLevelPlayed = true;
                        LOGICLevelSelector.firstEntryLogicLevel = false;

                        gui_gaming.SetActive(false);
                        gui_gameOver.SetActive(false);
                        gui_gameOverInfinite.SetActive(false);
                        GUI_DISTANCE.SetActive(false);
                        GUI_CURRENTLEVEL.SetActive(false);
                        gui_watchAD.SetActive(false);
                        gui_youWin.SetActive(false);

                        gui_revive.SetActive(false);

                        break;
                    case eachStateForGame.MenuLEVEL_SELECTOR:

                       // FadeOut();
                        gui_gaming.SetActive(false);
                        gui_gameOver.SetActive(false);
                        GUI_DISTANCE.SetActive(false);
                        GUI_CURRENTLEVEL.SetActive(false);
                        gui_gameOverInfinite.SetActive(false);
                        gui_watchAD.SetActive(false);
                        gui_youWin.SetActive(false);
                        gui_revive.SetActive(false);


                        break;

                    case eachStateForGame.MenuINFINITE_SELECTOR:

                        gui_gaming.SetActive(false);
                        gui_gameOver.SetActive(false);
                        GUI_DISTANCE.SetActive(false);
                        GUI_CURRENTLEVEL.SetActive(false);
                        gui_gameOverInfinite.SetActive(false);
                        gui_watchAD.SetActive(false);
                        gui_youWin.SetActive(false);
                        gui_revive.SetActive(false);
                        break;

                    case eachStateForGame.MenuDIFFICULTY_SELECTOR:

                        gui_gaming.SetActive(false);
                        gui_gameOver.SetActive(false);
                        GUI_DISTANCE.SetActive(false);
                        GUI_CURRENTLEVEL.SetActive(false);
                        gui_gameOverInfinite.SetActive(false);
                        gui_watchAD.SetActive(false);
                        gui_youWin.SetActive(false);
                        gui_revive.SetActive(false);

                        break;
                    case eachStateForGame.Menu_SelectorMundo2:
                        break;
                    case eachStateForGame.Menu_SelectorMundo3:
                        break;
                    case eachStateForGame.Menu_SelectorMundo4:
                        break;
                    case eachStateForGame.MenuOptions:

                        gui_gaming.SetActive(false);
                        GUI_DISTANCE.SetActive(false);
                        GUI_CURRENTLEVEL.SetActive(false);
                        gui_gameOver.SetActive(false);
                        gui_gameOverInfinite.SetActive(false);
                        gui_watchAD.SetActive(false);
                        gui_youWin.SetActive(false);
                        gui_revive.SetActive(false);


                        break;
                }
                
                break;
            case stateForScene.GameOver:
                //Gui manager
                gui_gaming.SetActive(false);
                gui_gameOver.SetActive(true);
                gui_gameOverInfinite.SetActive(false);
                gui_watchAD.SetActive(false);
                gui_youWin.SetActive(false);
                gui_revive.SetActive(false);

                break;
            case stateForScene.GameOverInfinite:
                //Gui manager
                gui_gaming.SetActive(false);
                gui_gameOver.SetActive(false);
                gui_gameOverInfinite.SetActive(true);
                gui_youWin.SetActive(false);
                gui_watchAD.SetActive(false);
                gui_revive.SetActive(false);
                break;
            case stateForScene.YouWin:
                

                gui_gaming.SetActive(false);
                gui_gameOver.SetActive(false);
                gui_gameOverInfinite.SetActive(false);
                gui_youWin.SetActive(true);
                gui_watchAD.SetActive(false);
                //Gui manager

                Canvas_general.youWin = true;

                gui_youWin.SetActive(true);
                gui_gaming.SetActive(false);
                gui_revive.SetActive(false);

                break;
            case stateForScene.WatchAD:


                gui_gaming.SetActive(false);
                gui_gameOver.SetActive(false);
                gui_gameOverInfinite.SetActive(false);
                gui_youWin.SetActive(false);
                gui_watchAD.SetActive(true);
                gui_revive.SetActive(false);

                break;

            case stateForScene.ReviveMenu:


                gui_gaming.SetActive(false);
                gui_gameOver.SetActive(false);
                gui_gameOverInfinite.SetActive(false);
                gui_youWin.SetActive(false);
                gui_watchAD.SetActive(false);
                gui_revive.SetActive(true);


                break;
        }
      
    }

    //Funciones para cambiar de escenas
    private float timeLeft = 3f;
    private float time = 0f;
    public void LoadingSceneFunction()
    {
       

        if(time > timeLeft)
        {
            if(loadingScene)
               GameManager_Menu.loadingScene = false;

            timeLeft = 3f;
        }

        timeLeft -= Time.deltaTime;
        

    }

    public void SceneGameMenu()
    {
        
        //Boton menu principal desde el JUEGO:
       FadeIn();
        currentScene = stateForScene.GameMenu;
        if (GameController.gameIsPaused)
        {
            GUI_PAUSE.SetActive(false);
            Time.timeScale = 1f;

        }
       
        GameController.revivesCounter = GameController.revivesForGame;

        StartCoroutine(TransicionSceneGameMenu("GameMenu_Principal", 1));
       
    }


    public void SceneChooseLevel()
    {
        FadeIn();
        currentScene = stateForScene.GameMenu;
        if (GameController.gameIsPaused)
        {
            GUI_PAUSE.SetActive(false);
            Time.timeScale = 1f;

        }

        StartCoroutine(TransicionSceneGameMenu("GameMenu_Principal", 2));
    }




    public void FadeIn()
    {
        anim.Play("FadeOut");
            
    }

    public void FadeOut()
    {
        anim.Play("Fade");
    }

   

    IEnumerator TransicionSceneGameMenu(string scene, int a)
    {
        
        yield return new WaitForSeconds(.8f);
        FadeOut();


        if (GameController.gameIsPaused)
        {
            GameController.gameIsPaused = false;
        }

        GameController.modeInfinite = false;
        GameController.modeSurvival = false;

        GameManager_Menu.loadingScene = true;
        callLevelPlayed = true;
        guiOneTAP = true;

        
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        

        currentScene = stateForScene.GameMenu;
        currentEachState = eachStateForGame.MenuPrincipal;
        GameController.gamecontroller.EscenaCorriendo = currentScene;

        GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.none;
        GameController.gamecontroller.levelType = GameController.typesOfLevels.none;


        yield return new WaitForSeconds(0.01f);
        if (a == 2)
        {
            DontActivatePlayerSelector = true;
            GameController.player = GameController.latestPlayerPlayed;

            GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR;
            //GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuLEVEL_SELECTOR;

        }

        yield return new WaitForSeconds(0.02f);
        if (a == 2)
        {
            DontActivatePlayerSelector = false;
            GameController.player = GameController.latestPlayerPlayed;

           GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuLEVEL_SELECTOR;

        }
    }

    
   


}
