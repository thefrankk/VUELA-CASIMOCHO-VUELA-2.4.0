using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectorControlloer : MonoBehaviour
{
    // Start is called before the first frame update

    // <>

   public static ModeSelectorControlloer sharedInstance;

  

    public GameObject Requeriments;
  

    //Sector bloqueo de mapas
    public GameObject mapBlock1;
    public GameObject mapBlock2;
    public GameObject mapBlock3;

    public Text RequirementsCoins;
    public Text RequirementsHighscore;

    public static int map1 = 0;
    public static int map2 = 0;
    public static int map3 = 0;


    public Text recordTEXT;
    public Text recordTEXT1;
    public Text recordTEXT2;
    public Text recordTEXT3;

    public static int recordMap;
    public static int recordMap1;
    public static int recordMap2;
    public static int recordMap3;



    private void Start()
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

        if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuINFINITE_SELECTOR)
        {
                if (map1 == 1)
            {
                mapBlock1.SetActive(false);

            }
            if (map2 == 1)
            {
                mapBlock2.SetActive(false);

            }
            if (map3 == 1)
            {
                mapBlock3.SetActive(false);

            }

            recordTEXT.text = recordMap.ToString();
            recordTEXT1.text = recordMap1.ToString();
            recordTEXT2.text = recordMap2.ToString();
            recordTEXT3.text = recordMap3.ToString();

        }

     


       




    }

    public void UnlockWorld1()
    {
        MenusManager.MenusManagerInstance.BackSound();
        if (recordMap >= 60 && GameController.coins >= 300)
        {
            GameController.coins -= 300;
           
            

            map1 = 1;
            Manager.sharedInstance.SaveData();
            mapBlock1.SetActive(false);
            Requeriments.SetActive(false);
        }
        else
        {
            Requeriments.SetActive(true);
            RequirementsCoins.text = "300".ToString();
            RequirementsHighscore.text = "60".ToString();
        }



    }   public void UnlockWorld2()
    {
        MenusManager.MenusManagerInstance.BackSound();
        if (recordMap1 >= 130 && GameController.coins >= 500 && map1 == 1)
        {
            GameController.coins -= 500;
           

            map2 = 1;
            Manager.sharedInstance.SaveData();
            mapBlock2.SetActive(false);
            Requeriments.SetActive(false);
        }
        else
        {
            Requeriments.SetActive(true);
            RequirementsCoins.text = "500".ToString();
            RequirementsHighscore.text = "130".ToString();
        }
            



    }   public void UnlockWorld3()
    {
        MenusManager.MenusManagerInstance.BackSound();
        if (recordMap2 >= 180 && GameController.coins >= 950 && map1 == 1 && map2 == 1)
        {
            GameController.coins -= 950;
           
            

            map3 = 1;
            Manager.sharedInstance.SaveData();
            mapBlock3.SetActive(false);
            Requeriments.SetActive(false);
        }
        else
        {
            Requeriments.SetActive(true);
            RequirementsCoins.text = "950".ToString();
            RequirementsHighscore.text = "180".ToString();
        }


    }

   

    public void Accept()
    {
        MenusManager.MenusManagerInstance.BackSound();
        Requeriments.SetActive(false);
        
    }


   
    
}
