using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelStarsLogic : MonoBehaviour
{

    //objects from stars
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int CantidadDeNiveles = 32;

    public static EndLevelStarsLogic sharedInstance;


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCountingStars(Player.CountingStars);

    }

    public void CheckCountingStars(int count)
    {
        
        switch (count)
        {
            case 0:
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);

                AddStarsToLevel();

                break;
            case 1:
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);

                AddStarsToLevel();

                break;
            case 2:
                star1.SetActive(false);
                star2.SetActive(true);
                star3.SetActive(false);

                AddStarsToLevel();

                break;
            case 3:
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(true);

                AddStarsToLevel();
                break;

        }
    }


    public void AddStarsToLevel()
    {
        for (int i = 0; i < CantidadDeNiveles; i++)
        {
            if(GameManager_Menu.currentLevelIndex == i)
            {
                if(Player.CountingStars <= 3)
                {
                    if (GameManager_Menu.CountingStarsPerLevel[i] == 0)
                    {

                      //  Debug.Log("sin estrellas, sumamos las correspondientes" + Player.CountingStars);

                        GameManager_Menu.CountingStarsPerLevel[i] = Player.CountingStars;
                        
                            PlayerPrefs.SetInt("starsGainPerLevel" + i, GameManager_Menu.CountingStarsPerLevel[i]);
                        

                        
                    }
                    else if (GameManager_Menu.CountingStarsPerLevel[i] <= Player.CountingStars)
                    {
                      //  Debug.Log("Tenemos mas estrellas q la partida anterior" + Player.CountingStars);

                        GameManager_Menu.CountingStarsPerLevel[i] = Player.CountingStars;

                       
                            PlayerPrefs.SetInt("starsGainPerLevel" + i, GameManager_Menu.CountingStarsPerLevel[i]);
                        
                    }
                    else if (GameManager_Menu.CountingStarsPerLevel[i] == 3)
                    {
                        GameManager_Menu.CountingStarsPerLevel[i] = 3;

                        //Debug.Log("Conseguimos todas las estrellas" + Player.CountingStars);

                        PlayerPrefs.SetInt("starsGainPerLevel" + i, GameManager_Menu.CountingStarsPerLevel[i]);
                        
                    }
                }
                
            }
        }
        
    }


}
