using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_general : MonoBehaviour
{
    // <>
    public Text currentLevelText;
    public Text currentCoinsText;
    public Text coinsTextDuplicated;
    public Text currentDistanceText;
    public Text currentLifeText;
    public Text currentLevel;

    //textos en menúes

    public Text coins;
    public Text stars;
    public Text recordDistance;
    public Text[] unlockPriceText;
    public Text[] unlockPriceTextStars;
    public Text coinsNotDiamond;

    public Text word2_cost;
    public Text word3_cost;
    public Text word4_cost;

   public Text[] starsPerLevel;

    public static bool youWin = false;

    public static Canvas_general inst;

    //Game over infinite -- make at least 5 points to receive coins
    
    public GameObject cantReceiveCoins;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
         
        switch(GameManager_Menu.currentScene)
        {
            case GameManager_Menu.stateForScene.GameInfinite:

                //Actualizamos los valores en el Text:
               
                currentCoinsText.text = GameController.coinsOnPlay.ToString();
                

                switch (GameManager_Menu.currentMundoIndex)
                {
                    case 1:
                        currentDistanceText.text = GameController.distanciaRecorrida.ToString();
                        break;
                    case 2:
                        currentDistanceText.text = GameController.distanciaRecorrida1.ToString();
                        break;
                    case 3:
                        currentDistanceText.text = GameController.distanciaRecorrida2.ToString();
                        break;
                    case 4:
                        currentDistanceText.text = GameController.distanciaRecorrida3.ToString();
                        break;

                }


                currentLifeText.text = Player.vidas.ToString();

                break;

            case GameManager_Menu.stateForScene.GameLevel:

                //Actualizamos los valores en el Text:
              
                currentCoinsText.text = GameController.coinsOnPlay.ToString();
                var leveIndex = GameManager_Menu.currentLevelIndex + 1;
                currentLevel.text = leveIndex.ToString();


                currentLifeText.text = Player.vidas.ToString();


                break;

            case GameManager_Menu.stateForScene.GameMenu:

                

                switch(GameManager_Menu.currentEachState)
                {
                    case GameManager_Menu.eachStateForGame.MenuLEVEL_SELECTOR:

                        stars.text = GameController.stars.ToString();

                        word2_cost.text = LOGICLevelSelector.priceToUnlockWorld2.ToString();
                        word3_cost.text = LOGICLevelSelector.priceToUnlockWorld3.ToString();
                        word4_cost.text = LOGICLevelSelector.priceToUnlockWorld4.ToString();

                        //Cantidad de niveles
                        for (int i = 0; i < GameManager_Menu.levelReached; i++)
                        {
                            
                            starsPerLevel[i].text = GameManager_Menu.CountingStarsPerLevel[i].ToString();
                        }


                        break;
                    case GameManager_Menu.eachStateForGame.MenuPrincipal:



                        // recordDistance.text = GameController.globalDistanciaRecorrida.ToString();
                        //recordDistance.text = GameController.globalDistanciaRecorrida1.ToString();

                        coins.text = GameController.diamonds.ToString();
                        recordDistance.text = GameController.globalDistanciaRecorrida2.ToString();
                        coinsNotDiamond.text = GameController.coins.ToString();

                        break;

                    case GameManager_Menu.eachStateForGame.MenuHuevos:

                        coins.text = GameController.diamonds.ToString();

                        break;
                    case GameManager_Menu.eachStateForGame.MenuMejoras:

                        coins.text = GameController.diamonds.ToString();

                        break;
                    case GameManager_Menu.eachStateForGame.MenuCHOOSEMODE:


                        break;

                    case GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR:

                       // coins.text = GameController.coins.ToString();
                        //Costos de cada personaje
                        for (int i = 0; i < unlockPriceText.Length; i++)
                        {
                            
                            unlockPriceText[i].text = LogicPlayerSelector.unlockPrice[i].ToString();
                        }

                        for (int i = 0; i < unlockPriceTextStars.Length; i++)
                        {

                            unlockPriceTextStars[i].text = LogicPlayerSelector.unlockPriceStars[i].ToString();
                        }


                        break;


                }

                break;

            case GameManager_Menu.stateForScene.GameOverInfinite:

                currentCoinsText.text = GameController.coinsOnPlay.ToString();
                //recordDistance.text = GameController.globalDistanciaRecorrida.ToString();
                recordDistance.text = GameController.globalDistanciaRecorrida2.ToString();

                if (GameController.cantReceiveCoins)
                {
                    
                    cantReceiveCoins.SetActive(true);
                }
                else if (GameController.cantReceiveCoins != true)
                {
                    
                    cantReceiveCoins.SetActive(false);
                }
                   


                switch (GameManager_Menu.currentMundoIndex)
                {
                    case 1:
                        currentDistanceText.text = GameController.distanciaRecorrida.ToString();

                        break;
                    case 2:
                        currentDistanceText.text = GameController.distanciaRecorrida1.ToString();
                        break;

                    case 3:
                        currentDistanceText.text = GameController.distanciaRecorrida2.ToString();
                        break;
                    case 4:
                        currentDistanceText.text = GameController.distanciaRecorrida3.ToString();
                        break;

                }

                break;

            case GameManager_Menu.stateForScene.WatchAD:

                //currentCoinsText.text = GameController.coinsOnPlay.ToString();
                var p = 0;

                p = GameController.coinsOnPlay * 2;

                //coinsTextDuplicated.text = p.ToString();



                break;


            case GameManager_Menu.stateForScene.YouWin:
               
                
                if (youWin)
                {
                    currentCoinsText.text = GameController.coinsOnPlay.ToString();
                    coins.text = GameController.coins.ToString();
                    stars.text = GameController.stars.ToString();
                }
               

                break;

        }
      

        //Textos de menues
    }


    

}
