using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenusManager : MonoBehaviour
{

    //Singleton method
    public static MenusManager MenusManagerInstance;

    //First image

    public GameObject[] portadaSprite;
    

    //Sector GUI
    [Header("GUI")]
    public GameObject GUI_PRINCIPAL;
    public GameObject GUI_LEVELSELECTOR;
    public GameObject GUI_PLAYERSELECTOR;
    public GameObject GUI_CHOOSETYPEGAME;
    public GameObject GUI_INFINITESELECTOR;
    public GameObject GUI_ALBUM;
    public GameObject GUI_SHOP;
    public GameObject GUI_HUEVOS;
    public GameObject GUI_CHOOSEDIFFICULTY;
    public GameObject GUI_MEJORAS;

    [Header("PANELES GUI")]
    public GameObject PANEL_PRINCIPAL;
    public GameObject PANEL_LEVELSELECTOR;
    public GameObject PANEL_PLAYERSELECTOR;
    public GameObject PANEL_CHOOSEMODE;

    [Header("AUDIO Y SONIDOS")]
    public AudioSource audioSource;
    public AudioSource soundSource;
    public AudioClip MusicMenu;
    public AudioClip ButtonsSound;
    public AudioClip egg_crack1;
    public AudioClip egg_crack2;
    public AudioClip egg_crack3;
    public AudioClip egg_opening;
    public AudioClip buySomething;


    public DailyReward dailyReward;

   
    // <>

    public bool enter = false;
    private void Awake()
    {
        var p = Random.Range(0, 9);
       
        portadaSprite[p].SetActive(true);

        MenusManagerInstance = this;

        if (Options.music)
        {
            audioSource.PlayOneShot(MusicMenu);
        }
        DeactivateScene();      

        GUI_PRINCIPAL.SetActive(true);
       
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {


        if (GameManager_Menu.currentEachState != GameManager_Menu.eachStateForGame.MenuPrincipal)
        {
            enter = false;
        }

        //Music
        if (Options.music)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
        //Sound
        if (Options.sound)
        {
            soundSource.mute = false;
        }
        else
        {
            soundSource.mute = true;
        }

        switch (GameManager_Menu.currentEachState)
        {
            case GameManager_Menu.eachStateForGame.MenuPrincipal:
                GUI_PRINCIPAL.SetActive(true);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false); GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_ALBUM.SetActive(false);
                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);

                if (!enter)
                {
                    DeactivateScene();
                    enter = true;
                   
                }

                 break;
            case GameManager_Menu.eachStateForGame.MenuCHOOSEMODE:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(true);
                GUI_INFINITESELECTOR.SetActive(false); GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_ALBUM.SetActive(false);
                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);

                break;
            case GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(true);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false);
                GUI_ALBUM.SetActive(false); GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);

                break;
            case GameManager_Menu.eachStateForGame.MenuLEVEL_SELECTOR:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(true);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false);
                GUI_ALBUM.SetActive(false);
                GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);

                break;
            case GameManager_Menu.eachStateForGame.MenuINFINITE_SELECTOR:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(true);
                GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_ALBUM.SetActive(false);
                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);
                break;

            case GameManager_Menu.eachStateForGame.MenuDIFFICULTY_SELECTOR:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false);
                GUI_CHOOSEDIFFICULTY.SetActive(true);
                GUI_ALBUM.SetActive(false);
                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);
                break;


            case GameManager_Menu.eachStateForGame.MenuOptions:
                GUI_PRINCIPAL.SetActive(false);
                break;

            case GameManager_Menu.eachStateForGame.MenuAlbum:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false); GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_ALBUM.SetActive(true);

                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);

                break;
            case GameManager_Menu.eachStateForGame.MenuShop:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false); GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_ALBUM.SetActive(false);

                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(true);
                GUI_MEJORAS.SetActive(false);

                break;

            case GameManager_Menu.eachStateForGame.MenuMejoras:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false); GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_ALBUM.SetActive(false);

                GUI_HUEVOS.SetActive(false);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(true);

                break;
            case GameManager_Menu.eachStateForGame.MenuHuevos:
                GUI_PRINCIPAL.SetActive(false);
                GUI_LEVELSELECTOR.SetActive(false);
                GUI_PLAYERSELECTOR.SetActive(false);
                GUI_CHOOSETYPEGAME.SetActive(false); GUI_CHOOSEDIFFICULTY.SetActive(false);
                GUI_INFINITESELECTOR.SetActive(false);
                GUI_ALBUM.SetActive(false);

                GUI_HUEVOS.SetActive(true);
                GUI_SHOP.SetActive(false);
                GUI_MEJORAS.SetActive(false);
                break;



        }
        
        

    }


    //Deactivate player selector

    public void DeactivateScene()
    {
        GUI_PLAYERSELECTOR.SetActive(true);
        StartCoroutine(sceneDeactivator());
    }
    
    IEnumerator sceneDeactivator()
    {
        yield return new WaitForSeconds(.5f);
        GUI_PLAYERSELECTOR.SetActive(false);
    }
    //transiciones
    //Menu principal
    public void MENU_PRINCIPAL()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();
        StartCoroutine(ChangeToMenuPrincipal());
    }
    IEnumerator ChangeToMenuPrincipal()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.guiOneTAP = true;
        GameManager_Menu.gameManagerMenu.FadeOut();

        GameManager_Menu.LevelPlayed();
        GameController.gamecontroller.RestartDifficult();

        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuPrincipal;

        GameController.gamecontroller.EscenaCorriendo = GameManager_Menu.currentScene;
        GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.none;
        GameController.gamecontroller.levelType = GameController.typesOfLevels.none;

       // StartCoroutine(chargeDaily());
       
    }

   /* IEnumerator chargeDaily()
    {
        yield return new WaitForSeconds(0.1f);
        
        dailyReward.InitializeThings();

    }*/

    //Level selector
    public void LEVEL_SELECTOR()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();


        StartCoroutine(ChangeToLevelSelector());
    }

    IEnumerator ChangeToLevelSelector()
    {
        yield return new WaitForSeconds(.5f);

        GameManager_Menu.gameManagerMenu.FadeOut();
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuLEVEL_SELECTOR;
    }

    //Player Selector
    public void PLAYER_SELECTOR()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToPlayerSelector());
    }
    IEnumerator ChangeToPlayerSelector()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        LogicPlayerSelector.firstEntrance = false;
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR;
    }

    //ALBUM

    public void ALBUM()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToAlbum());
    }
    IEnumerator ChangeToAlbum()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        LogicPlayerSelector.firstEntrance = false;
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuAlbum;
    }

    //SHOP
    public void SHOP()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToShop());
    }
    IEnumerator ChangeToShop()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        LogicPlayerSelector.firstEntrance = false;
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuShop;
    }

    //MEJORAS
    public void MEJORAS()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToMejoras());
    }
    IEnumerator ChangeToMejoras()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        LogicPlayerSelector.firstEntrance = false;
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuMejoras;
    }

    #region //HUEVOS
    public void EGGS()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToEGGS());
    }
    IEnumerator ChangeToEGGS()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        LogicPlayerSelector.firstEntrance = false;
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuHuevos;
    }
    //ChooseMode
    public void CHOOSE_A_MODE()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToChooseAMode());
    }
    IEnumerator ChangeToChooseAMode()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuCHOOSEMODE;
    }

    //ChooseInfiniteWord
    public void INFINITE_SELECTOR()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToInfiniteSelector());
    }
    IEnumerator ChangeToInfiniteSelector()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuINFINITE_SELECTOR;
    }

    //ChooseDifficlty selector
    public void DIFFICULTY_sELECTOR()
    {
        BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();

        StartCoroutine(ChangeToDifficultySelector());
    }
    IEnumerator ChangeToDifficultySelector()
    {
        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuDIFFICULTY_SELECTOR;
    }

    #endregion



    //DIFFICULTY

    public void CasiFacil()
    {
        BackSound();
        GameController.gamecontroller.RestartDifficult();
        GameController.levelDifficultIndex = 0;
        INFINITE_SELECTOR();
    }
    public void CasiDificil()
    {
        BackSound();
        GameController.gamecontroller.RestartDifficult();
        //Nivel de dificultad: 3
        AdjustDifficult(3, 0.9f, 0.006f, 0.20f, 0.20f, 0.92f, 0.46f);
        GameController.levelDifficultIndex = 1;

        INFINITE_SELECTOR();
    }
    public void CasiPRO()
    {
        BackSound();
        GameController.gamecontroller.RestartDifficult();
        GameController.levelDifficultIndex = 2;
        AdjustDifficult(7, 2.1f, 0.014f, 0.49f, 0.49f, 2.76f, 1.38f);
        INFINITE_SELECTOR();
    } 
    public void CasiGOD()
    {
        BackSound();
        GameController.gamecontroller.RestartDifficult();
        GameController.levelDifficultIndex = 3;
        AdjustDifficult(13, 3.9f, 0.026f, .79f, .79f, 5.52f, 2.76f);
        INFINITE_SELECTOR();
    }


    void AdjustDifficult(int a, float b, float c, float spawner, float coins, float powerJump, float gravity)
    {
        //Subimos el nivel
        GameController.currentLevelDifficult = a;
        //Agregamos velocidad a las monedas
        Coin_logic.speed += b;
       

        //Agregamos velocidad a los obstaculos
        Obstaculos_logica.speed += b;
        //Agregamos velocidad al fondo
        Parallax_raw.parallaxSpeed += c;
        //Velocidad de los objetos
        ObjectINFINITE_logic.speedObjects = b;
        //Agregamos para que aparezcan mas rapido 
        Spawner.maxTime -= spawner;

        //Velocidad de aparicion de las monedas
        Coins_generator.maxTime -= coins;

        GameController.playerJump += powerJump;
        GameController.playerGravity += gravity;

    }




    //MODO INFINITO
    //Selector de escenas, modo infinito
    public void SceneGameInfinite()
    {
        BackSound();
        
        GameManager_Menu.gameManagerMenu.FadeIn();
        GameManager_Menu.currentMundoIndex = 1;


        //Seteamos donde estamos

        GameController.gamecontroller.levelType = GameController.typesOfLevels.level;

        GameController.CurrentInfiniteWorld = GameController.Worlds.World1;
        GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.World1Level1;

       

        StartCoroutine(TransicionSceneGameInfinite("Game_Infinite"));
       
    }
    public void SceneGameInfinite2()
    {
        BackSound();

        GameManager_Menu.gameManagerMenu.FadeIn();
        GameManager_Menu.currentMundoIndex = 2;

        GameController.CurrentInfiniteWorld = GameController.Worlds.World2;
        GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.none;

        StartCoroutine(TransicionSceneGameInfinite("Game_Infinite2"));
    }

    public void SceneGameInfinite3()
    {

        BackSound();
        GameManager_Menu.currentMundoIndex = 3;
        GameManager_Menu.gameManagerMenu.FadeIn();

        GameController.CurrentInfiniteWorld = GameController.Worlds.World3;
        GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.none;

        StartCoroutine(TransicionSceneGameInfinite("Game_Infinite3"));
    }
    public void SceneGameInfinite4()
    {

        BackSound();
        GameManager_Menu.currentMundoIndex = 4;
        GameManager_Menu.gameManagerMenu.FadeIn();

        GameController.CurrentInfiniteWorld = GameController.Worlds.World4;
        GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.none;

        StartCoroutine(TransicionSceneGameInfinite("Game_Infinite4"));
  
    }
    IEnumerator TransicionSceneGameInfinite(string scene)
    {
        GameController.gamesPlayed += 1;
        PlayerPrefs.SetInt("gamesPlayed", GameController.gamesPlayed);

        GameController.modeInfinite = true;

        

        yield return new WaitForSeconds(.5f);
        GameManager_Menu.gameManagerMenu.FadeOut();

        
        SceneManager.LoadScene(scene, LoadSceneMode.Single);

        

        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.GameInfinite;
        GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameInfinite;

        GameController.gamecontroller.StartGame();

       
        
    }

    public void BackSound()
    {
        if (Options.sound)
        {
            soundSource.PlayOneShot(ButtonsSound);
        }
    } 

    public void BuySomething()
    {
        if(Options.sound)
        {
            soundSource.PlayOneShot(buySomething);
        }
    }
    public void CrackEggs(int type)
    {
        if(type == 1)
        {
            if (Options.sound)
            {
                var crack1 = egg_crack1;
                var crack2 = egg_crack2;
                var crack3 = egg_crack3;


                var p = Random.Range(0, 2);

                switch (p)
                {
                    case 0:
                        soundSource.PlayOneShot(egg_crack1);

                        break;
                    case 1:
                        soundSource.PlayOneShot(egg_crack2);

                        break;
                    case 2:
                        soundSource.PlayOneShot(egg_crack3);

                        break;

                }


            }
        }

        else if(type == 2)
        {
            soundSource.PlayOneShot(egg_opening);
            
        }
       
    }


    

}
