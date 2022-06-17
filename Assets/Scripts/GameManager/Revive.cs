using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Revive : MonoBehaviour
{

    private int _currentLevelDifficult;
    private float _coinSpeed;
    private float _obstalesSpeed;
    private float _backgroundSpeed;
    private float _speedObjects;
    private float _timeSpawner;
    private float _timeCoins;
    private float _powerJump;
    private float _powerGravity;

    private int _coinsOnPlay;
    private int _diamondsOnPlay;
    private int _eggsOnPlay;

    private GameController.CheckHabilitiesPlayer _playerHabs = GameController.playerHabs;

    private int _playerLives;

    private int[] distance;

    public Button buttonReviveAD;
    



    private void Start()
    {
        
    }


    private void OnEnable()
    {
       
        GameController.isTryingToRevive = true;
        distance = new int[4];
        GetParameters();
    }

  



    public void GetParameters()
    {

        _currentLevelDifficult = GameController.currentLevelDifficult;
        _coinSpeed = Coin_logic.speed;
        _obstalesSpeed = Obstaculos_logica.speed;
        _backgroundSpeed = Parallax_raw.parallaxSpeed;
        _speedObjects = ObjectINFINITE_logic.speedObjects;
        _timeSpawner = Spawner.maxTime;
        _timeCoins = Coins_generator.maxTime;
        _powerJump = GameController.playerJump;
        _powerGravity = GameController.playerGravity;

        _playerHabs = GameController.playerHabs;

        


        _coinsOnPlay = GameController.coinsOnPlay;
        _eggsOnPlay = GameController.eggsOnPlay;
        _diamondsOnPlay = GameController.diamondsOnPlay;

        _playerLives = 3;

        distance[0] = GameController.distanciaRecorrida;
        distance[1] = GameController.distanciaRecorrida1;
        distance[2] = GameController.distanciaRecorrida2;
        distance[3] = GameController.distanciaRecorrida3;

      

        //Debug.Log("Settings are saved.");

        
        buttonReviveAD.interactable = true;
    }

    void SetParameters()
    {
        GameController.currentLevelDifficult = _currentLevelDifficult;
        Coin_logic.speed = _coinSpeed;
        Obstaculos_logica.speed = _obstalesSpeed;
        Parallax_raw.parallaxSpeed = _backgroundSpeed;
        ObjectINFINITE_logic.speedObjects = _speedObjects;
        Spawner.maxTime =    _timeSpawner;
        Coins_generator.maxTime =  _timeCoins;
        GameController.playerJump =   _powerJump;
        GameController.playerGravity =  _powerGravity;
        GameController.coinsOnPlay = _coinsOnPlay;
        GameController.eggsOnPlay = _eggsOnPlay;
        GameController.diamondsOnPlay = _diamondsOnPlay;

        GameController.playerHabs = _playerHabs;


        Player.vidas = _playerLives;

        GameController.distanciaRecorrida = distance[0];
        GameController.distanciaRecorrida1 = distance[1];
        GameController.distanciaRecorrida2 = distance[2];
        GameController.distanciaRecorrida3 = distance[3];


        if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.GameInfinite)
        {
            
        }

       // Debug.Log("Settings are loaded.");
        
    }

    public void RevivePlayer()
    {
        
        GameController.revivesCounter--;
        ManagerAds.instance.showRewardRevivePlaying();

    }

     public IEnumerator restartGame()
    {
        yield return new WaitForSeconds(1f);


        if (GameController.gamecontroller.EscenaCorriendo == GameManager_Menu.stateForScene.GameInfinite)
        {
            var currentLevelInfinite = GameController.gamecontroller.currentLevelInfinite;
            var currentWordInfinite = GameController.CurrentInfiniteWorld;

            switch (currentWordInfinite)
            {
                case GameController.Worlds.World1:

                    switch(currentLevelInfinite)
                    {
                        case GameController.WorldsAndsLevels.World1Level1:

                            SceneManager.LoadScene("Game_Infinite", LoadSceneMode.Single);

                        break;

                        case GameController.WorldsAndsLevels.World1SubLevel1:

                            SceneManager.LoadScene("Game_subNivel1", LoadSceneMode.Single);

                        break;

                        case GameController.WorldsAndsLevels.World1Level2:

                            SceneManager.LoadScene("Game_nivel2", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1SubLevel2:

                            SceneManager.LoadScene("Game_subNivel2", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1Level3:

                            SceneManager.LoadScene("Game_nivel3", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1Sublevel3:

                            SceneManager.LoadScene("Game_SubNivel3", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1Level4:

                            SceneManager.LoadScene("Game_nivel4", LoadSceneMode.Single);

                            break;
                    }

                    
                    break;

                case GameController.Worlds.World2:
                    SceneManager.LoadScene("Game_Infinite2", LoadSceneMode.Single);
                    break;

                case GameController.Worlds.World3:
                    SceneManager.LoadScene("Game_Infinite3", LoadSceneMode.Single);
                    break;

                case GameController.Worlds.World4:
                    SceneManager.LoadScene("Game_Infinite4", LoadSceneMode.Single);
                    break;
            }
            
           
           

        }
        else
        {
            var currentLevelInfinite = GameController.gamecontroller.currentLevelInfinite;
            var currentWordInfinite = GameController.CurrentInfiniteWorld;

            switch (currentWordInfinite)
            {
                case GameController.Worlds.World1:

                    switch (currentLevelInfinite)
                    {
                        case GameController.WorldsAndsLevels.World1Level1:

                            SceneManager.LoadScene("Game_Infinite", LoadSceneMode.Single);

                            break;

                        case GameController.WorldsAndsLevels.World1SubLevel1:

                            SceneManager.LoadScene("Game_subNivel1", LoadSceneMode.Single);

                            break;

                        case GameController.WorldsAndsLevels.World1Level2:

                            SceneManager.LoadScene("Game_nivel2", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1SubLevel2:

                            SceneManager.LoadScene("Game_subNivel2", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1Level3:

                            SceneManager.LoadScene("Game_nivel3", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1Sublevel3:

                            SceneManager.LoadScene("Game_SubNivel3", LoadSceneMode.Single);

                            break;
                        case GameController.WorldsAndsLevels.World1Level4:

                            SceneManager.LoadScene("Game_nivel4", LoadSceneMode.Single);

                            break;
                    }

                    break;

                case GameController.Worlds.World2:
                    SceneManager.LoadScene("Game_Infinite2", LoadSceneMode.Single);
                    break;

                case GameController.Worlds.World3:
                    SceneManager.LoadScene("Game_Infinite3", LoadSceneMode.Single);
                    break;

                case GameController.Worlds.World4:
                    SceneManager.LoadScene("Game_Infinite4", LoadSceneMode.Single);
                    break;
            }
        }


        //Seteamos los parametros
        SetParameters();

        GameManager_Menu.gameManagerMenu.FadeOut();
        //gamecontroller.GetComponent<GameManager_Menu>().FadeOut();
        GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameInfinite; //GameController.gamecontroller.EscenaCorriendo;

        startGame();

    }


    void startGame()
    {

       
        if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.GameInfinite)
        {

            //Portales
            subLevelManager.portalIsOnScreen = false;
            subLevelManager.portalWasActivated = 0;

            //Clear objects
            ObjectPooling.pool.Clear();
            ObjectPooling.parents.Clear();
        }
       
    }




    public void DontRevive()
    {
        if (GameController.coinsOnPlay >= 5)
        {
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.WatchAD;
        }
        else
        {
             if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.GameInfinite)
                GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOverInfinite;
            else
                GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOver;
        }
      

        //Portales
        subLevelManager.portalIsOnScreen = false;
        subLevelManager.portalWasActivated = 0;




        //Habilidades
        //Playerhabs
        //Le sacamos el jetpack
        GameController.gamecontroller.playerJetPack = false;
        GameController.playerHabs = GameController.CheckHabilitiesPlayer.outHabilities;

        GameController.gamecontroller.GameOver();
        GameController.isTryingToRevive = false;
    }

}
