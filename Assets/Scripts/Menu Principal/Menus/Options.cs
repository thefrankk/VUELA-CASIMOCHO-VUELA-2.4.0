using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{


    public static bool betterPerformance;
    public GameObject betterPerformanceButton;

    public GameObject logros_ui;
    public GameObject gui_options;
    public GameObject credits_ui;
    public GameObject hallOfFame_ui;
    public GameObject misRecords;

    public GameObject deleteData;

    public GameObject musicButton;
    public GameObject soundButton;

    public Sprite OFF;
    public Sprite ON;

    public static bool music = true;
    public static bool sound = true;

    public GameObject stats_ui;


    public Text recolectedCoins;
    public Text exchangedDiamonds;
    public Text superatedObstacles;
    public Text gamesPlayed;
    public Text tapsOnEgg;
    public Text openedEggs;
    public Text jumpsMaked;
    public Text loosedLifesObstacles;
    public Text gamesLosed;


     // <>
    private void Start()
    {
        music = true;
        sound = true;
        betterPerformance = false;

       

       // music = Convert.ToBoolean(PlayerPrefs.GetInt("music"));
       // sound = Convert.ToBoolean(PlayerPrefs.GetInt("sound"));

        betterPerformance = Convert.ToBoolean(PlayerPrefs.GetInt("betterPerformance"));

        if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
        {
            LoadDataMenu();
        }


        



    }

    public void Update()
    {
        recolectedCoins.text = GameController.recolectedCoins.ToString();
        exchangedDiamonds.text = GameController.exchangedDiamonds.ToString();
        superatedObstacles.text = GameController.superatedObstacles.ToString();
        gamesPlayed.text = GameController.gamesPlayed.ToString();
        tapsOnEgg.text = GameController.tapsOnEgg.ToString();
        openedEggs.text = HuevosManager.eggsOpenCounter.ToString();
        jumpsMaked.text = GameController.jumpsMaked.ToString();
        loosedLifesObstacles.text = GameController.loosedLifesObstacles.ToString();
        gamesLosed.text = GameController.gamesLosed.ToString();
    }

    void LoadDataMenu()
    {
        if (music)
        {
            musicButton.GetComponent<Image>().sprite = ON;
        }
        else if (!music)
        {
            musicButton.GetComponent<Image>().sprite = OFF;
        }

        if (sound)
        {
            soundButton.GetComponent<Image>().sprite = ON;
        }
        else if (!sound)
        {
            soundButton.GetComponent<Image>().sprite = OFF;
        }

        if (betterPerformance)
        {
            betterPerformanceButton.GetComponent<Image>().sprite = ON;
        }
        else if (!betterPerformance)
        {
            betterPerformanceButton.GetComponent<Image>().sprite = OFF;
        }

    }

    //Better performance

    public void BetterPerformance()
    {

        if (betterPerformance)
        {
            betterPerformance = false;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
                betterPerformanceButton.GetComponent<Image>().sprite = OFF;

            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                betterPerformanceButton.GetComponent<Image>().sprite = OFF;

            PlayerPrefs.SetInt("betterPerformance", Convert.ToInt32(betterPerformance));


        }
        else if (!betterPerformance)
        {

            betterPerformance = true;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
            {
                betterPerformanceButton.GetComponent<Image>().sprite = ON;
                MenusManager.MenusManagerInstance.BackSound();
            }
            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                betterPerformanceButton.GetComponent<Image>().sprite = ON;

            PlayerPrefs.SetInt("betterPerformance", Convert.ToInt32(betterPerformance));


        }

    }

    //Music and sound
    public void Music()
    {

        if (music)
        {
            music = false;
            if(GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
                 musicButton.GetComponent<Image>().sprite = OFF;

            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                musicButton.GetComponent<Image>().sprite = OFF;

            PlayerPrefs.SetInt("music", Convert.ToInt32(music));

        }
        else if (!music)
        {
            
            music = true;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
            {
                musicButton.GetComponent<Image>().sprite = ON;
                MenusManager.MenusManagerInstance.BackSound();
            }
            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                musicButton.GetComponent<Image>().sprite = ON;


            PlayerPrefs.SetInt("music", Convert.ToInt32(music));

        }  
        
    }

    public void Sound()
    {
        if (sound)
        {
            sound = false;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
                soundButton.GetComponent<Image>().sprite = OFF;

            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                soundButton.GetComponent<Image>().sprite = OFF;

            PlayerPrefs.SetInt("sound", Convert.ToInt32(sound));
        }
        else if (!sound)
        {
           
            sound = true;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
            {
                soundButton.GetComponent<Image>().sprite = ON;
                MenusManager.MenusManagerInstance.BackSound();
            }

            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                soundButton.GetComponent<Image>().sprite = ON;

            PlayerPrefs.SetInt("sound", Convert.ToInt32(sound));
        }
    }
    //Mis records
    public void OpenMisRecords()
    {
        misRecords.SetActive(true);
    }
    public void CloseMisRecords()
    {
        misRecords.SetActive(false);
    }

    //Hall of fame
    public void HallOfFame()
    {
        hallOfFame_ui.SetActive(true);
    }  
    public void CloseHallOfFame()
    {
        hallOfFame_ui.SetActive(false);
    }    

    //Estadisticas
    public void stats()
    {
        stats_ui.SetActive(true);
    }

    public void CloseStats()
    {
        stats_ui.SetActive(false);
    }

    //logros
    public void Logros()
    {
        logros_ui.SetActive(true);
    }

    public void CloseLogros()
    {
        logros_ui.SetActive(false);

    }

    //info and credits

    public void CreditsAndInfo()
    {
        credits_ui.SetActive(true);
    }
    public void CloseCreditsAndInfo()
    {
        credits_ui.SetActive(false);
    }

    //Data ui
    public void DeleteData()
    {
        deleteData.SetActive(true);
    }

    public void DontDeleteData()
    {
        deleteData.SetActive(false);
    }




    //Social media
    public void OpenInstagramCasimocho()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Application.OpenURL("https://www.instagram.com/casimochotv/");
    }
    public void OpenFacebookCasimocho()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Application.OpenURL("https://www.facebook.com/casimochotv/");
    }
    public void OpenYoutubeCasimocho()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Application.OpenURL("https://www.youtube.com/channel/UCyIV9CarCowla0kj-197DoA");
    }
    

    public void OpenInstagramVeinsofgames()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Application.OpenURL("https://www.instagram.com/veinsofgames/");
    
    }
    public void OpenFacebookVeinsofgames()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Application.OpenURL("https://www.facebook.com/veinsofgames/");
    
    }

    public void OpenInstagramVeinsoft()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Application.OpenURL("https://www.instagram.com/veinsoft.gaming/");
    }

    public void OpenFacebookVeinsoft()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Application.OpenURL("https://www.facebook.com/profile.php?id=100063579729200");
    
    }


    public void openOptions()
    {
        MenusManager.MenusManagerInstance.BackSound();
        GameManager_Menu.gameManagerMenu.FadeIn();
        StartCoroutine(TransicionOptions());
    }
    IEnumerator TransicionOptions()
    {
        yield return new WaitForSeconds(.5f);

       GameManager_Menu.gameManagerMenu.FadeOut();

        gui_options.SetActive(true);
       GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuOptions;
    }

    public void BackMenu()
    {
        MenusManager.MenusManagerInstance.BackSound();

        GameManager_Menu.gameManagerMenu.FadeIn();
        StartCoroutine(TransicionBack());
    }

    IEnumerator TransicionBack()
    {
        yield return new WaitForSeconds(.5f);
//
       GameManager_Menu.gameManagerMenu.FadeOut();

        gui_options.SetActive(false);
        GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.MenuPrincipal;
    }




   

}


