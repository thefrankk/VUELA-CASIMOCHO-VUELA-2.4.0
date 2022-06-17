using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static Manager sharedInstance;

    //Ubicacion del archivo data

    private String filePath;


    private void Awake()
    {


        sharedInstance = this;
        filePath = Application.persistentDataPath + "/save.dat";

        

        LoadData();

    }

    private void Start()
    {
        DataSave data = new DataSave();

    }

    private void Update()
    {
       /* if (Input.GetKey(KeyCode.K))
        {
           // Debug.Log("Cleared data");
            ClearData();
            Application.Quit();

        }*/
    }

    public void SaveData()
    {
            
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        

        DataSave data = new DataSave();


        //Datos a guardar

        data.coins = GameController.coins;
        data.stars = GameController.stars;
        data.diamonds = GameController.diamonds;
        data.highscore = GameController.globalDistanciaRecorrida;
        data.highscore1 = GameController.globalDistanciaRecorrida1;
        data.highscore2 = GameController.globalDistanciaRecorrida2;
        data.highscore3 = GameController.globalDistanciaRecorrida3;
        data.eggSavings = HuevosManager.eggsSavings;
        data.LevelReached = GameManager_Menu.levelReached;

        data.map1 = ModeSelectorControlloer.map1;
        data.map2 = ModeSelectorControlloer.map2;
        data.map3 = ModeSelectorControlloer.map3;

        data.recordmap = ModeSelectorControlloer.recordMap;
        data.recordmap1 = ModeSelectorControlloer.recordMap1;
        data.recordmap2 = ModeSelectorControlloer.recordMap2;
        data.recordmap3 = ModeSelectorControlloer.recordMap3;

        data.level_INTERMEDIO = DifficultSelector.LEVEL_INTERMEDIO;
        data.level_CASIPRO = DifficultSelector.LEVEL_CASIPRO;
        data.level_CASIGOD = DifficultSelector.LEVEL_CASIGOD;

        //portals
        data.portal_word0 = GameController.portal_word[0];

        
        


        bf.Serialize(file, data);
        file.Close();

        LoadData();

       
    }
   

    public void LoadData()
    {
        
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            DataSave data = (DataSave)bf.Deserialize(file);

            //Datos a cargar

            GameController.coins = data.coins;
            GameController.stars = data.stars;
            GameController.diamonds = data.diamonds;
            GameController.globalDistanciaRecorrida = data.highscore;
            GameController.globalDistanciaRecorrida1 = data.highscore1;
            GameController.globalDistanciaRecorrida2 = data.highscore2;
            GameController.globalDistanciaRecorrida3 = data.highscore3;
            HuevosManager.eggsSavings = data.eggSavings;
            GameManager_Menu.levelReached = data.LevelReached;

            ModeSelectorControlloer.map1 = data.map1;
            ModeSelectorControlloer.map2 = data.map2;
            ModeSelectorControlloer.map3 = data.map3;

            ModeSelectorControlloer.recordMap = data.recordmap;
            ModeSelectorControlloer.recordMap1 = data.recordmap1;
            ModeSelectorControlloer.recordMap2 = data.recordmap2;
            ModeSelectorControlloer.recordMap3 = data.recordmap3;

            DifficultSelector.LEVEL_CASIGOD = data.level_CASIGOD;
            DifficultSelector.LEVEL_CASIPRO = data.level_CASIPRO;
            DifficultSelector.LEVEL_INTERMEDIO = data.level_INTERMEDIO;

            //gifts

          

         


            //portals
            if (GameManager_Menu.currentEachState != GameManager_Menu.eachStateForGame.MenuPrincipal)
            {
                GameController.portal_word[0] = data.portal_word0;
            }
            

            file.Close();
        }

        

    }


    public void ClearDataExist()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        DataSave data = new DataSave();

        data.coins = 0;
        data.stars = 0;
        data.diamonds = 0;
        data.highscore = 0;
        data.eggSavings = 1;
        data.LevelReached = 0;


        data.map1 = 0;
        data.map2 = 0;
        data.map3 = 0;

        data.recordmap = 0;
        data.recordmap1 = 0;
        data.recordmap2 = 0;
        data.recordmap3 = 0;

        data.level_INTERMEDIO = 0;
        data.level_CASIPRO = 0;
        data.level_CASIGOD = 0;


        bf.Serialize(file, data);
        file.Close();

        LoadData();

        PlayerPrefs.DeleteAll();
    }

    public void ClearData()
    {
        ClearDataExist();

        if (File.Exists(filePath))
        {
          //  Debug.Log("data cleared");
            File.Delete(filePath);
            
        }
        PlayerPrefs.DeleteAll();

        Application.Quit();

        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

       
    }



}
