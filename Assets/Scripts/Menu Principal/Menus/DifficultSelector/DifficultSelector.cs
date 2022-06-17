using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultSelector : MonoBehaviour
{

    public static DifficultSelector sharedInstance;

    public GameObject Requeriments;

    public Text RequirementsDiamonds;
    public Text RequirementsHighscore;


    //Sector bloqueo de niveles
    public GameObject levelBlock_INTERMEDIO;
    public GameObject levelBlock_CASIPRO;
    public GameObject levelBlock_CASIGOD;

    public static int LEVEL_INTERMEDIO = 0;
    public static int LEVEL_CASIPRO = 0;
    public static int LEVEL_CASIGOD = 0;


    // Start is called before the first frame update
    void Start()
    {
        sharedInstance = this;

        Manager.sharedInstance.LoadData();




        UnlockReader();
    }

    // Update is called once per frame
    void Update()
    {

        UnlockReader();
    }


    public void UnlockReader()
    {

        Manager.sharedInstance.LoadData();

        if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuDIFFICULTY_SELECTOR)
        {

            if (LEVEL_INTERMEDIO == 1)
            {
                levelBlock_INTERMEDIO.SetActive(false);

            }
            if (LEVEL_CASIPRO == 1)
            {
                levelBlock_CASIPRO.SetActive(false);

            }
            if (LEVEL_CASIGOD == 1)
            {
                levelBlock_CASIGOD.SetActive(false);

            }
        }


    }




    //Sector dificultad
    public void UnlockINTERMEDIO()
    {
        MenusManager.MenusManagerInstance.BackSound();


        if (GameController.globalDistanciaRecorrida3 >= 65 && GameController.diamonds >= 25)
        {
            GameController.diamonds -= 25;

            LEVEL_INTERMEDIO = 1;
            Manager.sharedInstance.SaveData();
            levelBlock_INTERMEDIO.SetActive(false);
            Requeriments.SetActive(false);
        }
        else
        {
            Requeriments.SetActive(true);
            RequirementsDiamonds.text = "25".ToString();
            RequirementsHighscore.text = "65".ToString();
        }



    }
    public void UnlockCASIPRO()
    {
        MenusManager.MenusManagerInstance.BackSound();

        if (GameController.globalDistanciaRecorrida3 >= 160 && GameController.diamonds >= 55 && LEVEL_INTERMEDIO == 1)
        {
            GameController.diamonds -= 55;


            LEVEL_CASIPRO = 1;
            Manager.sharedInstance.SaveData();
            levelBlock_CASIPRO.SetActive(false);
            Requeriments.SetActive(false);
        }
        else
        {
            Requeriments.SetActive(true);
            RequirementsDiamonds.text = "55".ToString();
            RequirementsHighscore.text = "160".ToString();
        }




    }
    public void UnlockCASIGOD()
    {
        MenusManager.MenusManagerInstance.BackSound();
        if (GameController.globalDistanciaRecorrida3 >= 240 && GameController.diamonds >= 100 && LEVEL_INTERMEDIO == 1 && LEVEL_CASIPRO == 1)
        {
            GameController.diamonds -= 100;



            LEVEL_CASIGOD = 1;
            Manager.sharedInstance.SaveData();
            levelBlock_CASIGOD.SetActive(false);
            Requeriments.SetActive(false);
        }
        else
        {
            Requeriments.SetActive(true);
            RequirementsDiamonds.text = "100".ToString();
            RequirementsHighscore.text = "240".ToString();
        }


    }

    public void Accept()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Requeriments.SetActive(false);

    }

}
