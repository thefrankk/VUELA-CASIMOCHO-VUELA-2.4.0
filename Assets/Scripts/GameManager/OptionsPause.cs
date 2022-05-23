using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPause : MonoBehaviour
{
    public static OptionsPause sharedInstance;

    public Sprite OFF;
    public Sprite ON;

    public static bool pressPause = false;

    void Start()
    {
        sharedInstance = this;
    }
    void Update()
    {
       if (pressPause)
        {
            LoadData();
            pressPause = false;
        }
    }
    public void Music()
    {

        if (Options.music)
        {
            Options.music = false;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
                gameObject.GetComponent<Image>().sprite = OFF;

            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                gameObject.GetComponent<Image>().sprite = OFF;

            PlayerPrefs.SetInt("music", Convert.ToInt32(Options.music));

        }
        else if (!Options.music)
        {

            Options.music = true;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
            {
                gameObject.GetComponent<Image>().sprite = ON;
                MenusManager.MenusManagerInstance.BackSound();
            }
            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                gameObject.GetComponent<Image>().sprite = ON;


            PlayerPrefs.SetInt("music", Convert.ToInt32(Options.music));

        }

    }

    public void Sound()
    {
        if (Options.sound)
        {
            Options.sound = false;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
                gameObject.GetComponent<Image>().sprite = OFF;

            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                gameObject.GetComponent<Image>().sprite = OFF;

            PlayerPrefs.SetInt("sound", Convert.ToInt32(Options.sound));
        }
        else if (!Options.sound)
        {

            Options.sound = true;
            if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameMenu)
            {
                gameObject.GetComponent<Image>().sprite = ON;
                MenusManager.MenusManagerInstance.BackSound();
            }

            if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameMenu)
                gameObject.GetComponent<Image>().sprite = ON;

            PlayerPrefs.SetInt("sound", Convert.ToInt32(Options.sound));
        }
    }

    public void LoadData()
    {
        if (Options.music)
        {
            gameObject.GetComponent<Image>().sprite = ON;
        }
        else if (!Options.music)
        {
            gameObject.GetComponent<Image>().sprite = OFF;
        }

        if (Options.sound)
        {
            gameObject.GetComponent<Image>().sprite = ON;
        }
        else if (!Options.sound)
        {
            gameObject.GetComponent<Image>().sprite = OFF;
        }
    }

}
