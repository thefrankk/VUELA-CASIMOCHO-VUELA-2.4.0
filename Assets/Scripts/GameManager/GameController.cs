using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class GameController : MonoBehaviour
{


    //Primera vez jugando?
    public static int firstPlay = 0;

    //GameController gamecontroller;
    public float deltaTime;

    // <>
    //Singleton method
    public static GameController gamecontroller;

    //Poder del salto y gravedad 
    public static float playerJump;
    public static float playerGravity;

    //Propulsion y gravedad de la nave
    public static float rocketPropulsionU;
    public static float rocketPropulsionD;

    //Sector estadisticas:
    public static int recolectedCoins;
    public static int exchangedDiamonds;
    public static int superatedObstacles;
    public static int GLOBALsuperatedObstacles;
    public static int gamesPlayed;
    public static int tapsOnEgg;
    public static int jumpsMaked;
    public static int GLOBALjumpsMaked;
    public static int GLOBALloosedLifesObstacles;
    public static int loosedLifesObstacles;
    public static int gamesLosed;

    //stop controller game -- for revive menu -- REVIVE CONTROLLER
    public static bool isTryingToRevive;
    public static int revivesForGame = 1; //1
    public static int revivesCounter = revivesForGame;

    //Cant receive coins at least 5 coins 
    public static bool cantReceiveCoins;

    //sublevel and level
    public typesOfLevels levelType;
    public enum typesOfLevels
    {
        level,
        subLevel,
        none
    }

    //State machine for player states
    public enum GamingStates
    {
        alive,
        dead,
        pendingAlive,
        transition,
        youWin,
        youLoose,
        becameInvisible,
        menus,

    }
    //Portals
    [HideInInspector]
    public static int[] portal_word;

    //Ultimo personaje usado
    public static playersToPlay latestPlayerPlayed;
    [SerializeReference]
    public static GamingStates gStates;
    
    //Monedas
    public static int coins = 0;
    public static int diamonds = 0;

    //google play services
    public static bool isConnectedToGooglePlayServices;
    //Diamantes y coins DURANTE la partida
    public static int coinsOnPlay = 0;
    public static int diamondsOnPlay = 0;
    public static int eggsOnPlay = 0;

    //Estrellas conseguidas por nivel
    [SerializeField]
    public static int stars = 0;

    //next level
    public string nextLevel;

    //Nivel alcanzado  de difficultad
    public static int currentLevelDifficult = 0;
    public static int levelDifficultIndex = 0;
    //Distancia recorrida en cada mundo
    public static int distanciaRecorrida = 0;
    public static int distanciaRecorrida1 = 0;
    public static int distanciaRecorrida2 = 0;
    public static int distanciaRecorrida3 = 0;


    public int distanceTraveled;
    //Modo actual

    public static bool modeInfinite = false;
    public static bool modeSurvival = false;



    //Distancia recorrida record
    public static int globalDistanciaRecorrida = 0; // ene
    public static int globalDistanciaRecorrida1 = 0; // feb
    public static int globalDistanciaRecorrida2 = 0; // marzo
   
    //Nivel maximo alcanzado record
    public static int levelMax = 0;
    //Valor necesario a llegar para subir de nivel
    int p = 10;

    public GameManager_Menu.stateForScene EscenaCorriendo;
    [SerializeField]
    public static Worlds CurrentInfiniteWorld;
   
    public WorldsAndsLevels currentLevelInfinite;



    //Player object
    public GameObject PlayerPrefab;
    public bool playerJetPack;



    //Level ya jugado
    public static bool[] PlayedLevels;

   

    //Pause MODE
    public static bool gameIsPaused = false;
    public GameObject GUI_PAUSE;

    public Sprite MusicOFF;
    public Sprite MusicON;

    public Sprite SoundOFF;
    public Sprite SoundON;

    public Button SoundButton;
    public Button MusicButton;


    //Mundos infinitos y sus subniveles
    
    public enum WorldsAndsLevels 
    {
        none,
        World1Level1,
        World1SubLevel1,
        World1Level2,
        World1SubLevel2,
        World1Level3,
        World1Sublevel3,
        World1Level4,
    }
    
    public enum Worlds
    {
        World1,
        World2,
        World3,
        World4,
        none,
    }
    

    //Players Disponibles
    public enum playersToPlay : long
    {
        casimocho = 0,
        messimocho,
        casifriend,
        casiduerme,
        casiboxeador,
        todomocho,
        zombimocho,
        constructor,
        amungocho,
        pinomocho,
        casibombero,
        casirojo,
        casiloco,
        casinoob,
        casimono,
        minimocho,
        marinomocho,
        chuckymocho,
        casiviejo,
        casitortufan,
        casitor,
        casiprincesa,
        payamocho,
        casirobot,
        casichef,
        espantamocho,
        casictor,
        wallymocho,
        casipobre,
        supermocho,
        batmocho,
        ironmocho,
        casihulk,
        wolmocho, 
        spidermocho,
        mikimocho,
        casiesponja,
        casisonic,
        mochosans,
        gokumocho,
        vegemocho,
        siremocho,
        submocho,
        casipion,
        pikamocho,
        marimocho,
        casit,
        casiangel,
        cactumocho,
        dracumocho,
        casimomia,
        casizombie,
        casiempanada,
        casigordo,
        barmocho,
        bebemocho,
        casiflor,
        elegantemocho,
        rapmocho,
        casimago,
        popomocho,
        casifreddy,
        jasonmocho,
        casiamor,
        casicreper,
        casidr,
        casimorado,
        polimocho,
        slendermocho,
        terminomocho,
        bailamocho,
        piruletamocho,
        casientrenado,
        chapumocho,
        casidiablo,
        ranamocho,
        casihacker,
        casicerdo,
        caperumocho,
        tarzamocho,
        calamarmocho,
        timbamocho,
        trollmocho,
        spartamocho,
        astromocho,
        casirius,
        toximocho,
        casidongo,
        casimochoEXE,
        casimike,
        chapulinmocho,
        casialien,
        mayomocho,
        armamocho,
        casinix,
        casilyna,
        casigod,
        papamocho,
        casilusion,
        casifuerte,
        andremocho,
        casisoldado,
        gauchomocho,
        mimocho,
        casimochoTV,
        casinvisible,
        casimillonario,
        casilobo,
        casirey,
        cavermocho,
        huggymocho,
        casichino,
       
    }
    public static playersToPlay player; 
   
    //Personajes con o sin habilidades enum  para chequear
    public enum CheckHabilitiesPlayer
    {
        withHabilities,
        outHabilities,
    }

    public static CheckHabilitiesPlayer playerHabs;




    private void Awake()
    {
        
        //Seteamos los fps
        if (Application.isMobilePlatform)
            QualitySettings.vSyncCount = 0;

        Application.targetFrameRate = 144;

        //PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform.Activate();



        gStates = GamingStates.menus;
        player = playersToPlay.casimocho;
        portal_word = new int[1];
        PlayedLevels = new bool[32];
        //Cargamos toda la data:
        LoadData();

        // 


        DontDestroyOnLoad(gameObject);

        //Singleton method
        if (gamecontroller == null)
        {
            gamecontroller = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //gamecontroller = this;
       

    }

    private void Start()
    {
       // SingInToGooglePlayServices();

    }

    /*public void SingInToGooglePlayServices()
    {
        //PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
        {
            switch (result)
            {
                case SignInStatus.Success:
                   isConnectedToGooglePlayServices = true;
                    break;
                default:
                   isConnectedToGooglePlayServices = false;
                    break;
            }
        });
    }
    */
    public void LoadData()
    {
        //Estadisticas

        recolectedCoins = PlayerPrefs.GetInt("recolectedCoins", 0);
        exchangedDiamonds = PlayerPrefs.GetInt("exchangedDiamonds", 0);
        superatedObstacles = PlayerPrefs.GetInt("superatedObstacles", 0);
        gamesPlayed = PlayerPrefs.GetInt("gamesPlayed", 0);
        tapsOnEgg = PlayerPrefs.GetInt("tapsOnEgg", 0);
        jumpsMaked = PlayerPrefs.GetInt("jumpsMaked", 0);
        gamesLosed = PlayerPrefs.GetInt("gamesLosed", 0);
        loosedLifesObstacles = PlayerPrefs.GetInt("loosedLifesObstacles", 0);

        HuevosManager.eggsOpenCounter = PlayerPrefs.GetInt("eggCounter", 0);


        //Configs

      

        //Options.music = Convert.ToBoolean(PlayerPrefs.GetInt("music"));
       // Options.sound = Convert.ToBoolean(PlayerPrefs.GetInt("sound"));
       

        Options.betterPerformance = Convert.ToBoolean(PlayerPrefs.GetInt("betterPerformance"));



        //Load first entrance
        firstPlay = PlayerPrefs.GetInt("firstPlay", 0);

        //Niveles desbloqueados
        for (int i = 0; i < GameManager_Menu.levelReached; i++)
        {
             GameController.PlayedLevels[i] = Convert.ToBoolean(PlayerPrefs.GetInt("playedLevels" + i, 0));
            
           

        }

        //GameController.PlayedLevels[0] = false;


    }

    // Update is called once per frame
    void Update()
    {

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        switch (GameManager_Menu.currentScene)
        {
            case GameManager_Menu.stateForScene.GameInfinite:


                EscenaCorriendo = GameManager_Menu.currentScene;

               /* levelType = typesOfLevels.level; 

                GameController.CurrentInfiniteWorld = GameController.Worlds.World1;
                GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.World1Level1;

                GameManager_Menu.currentEachState = GameManager_Menu.eachStateForGame.GameInfinite;
                GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameInfinite;*/

                if (gStates == GamingStates.pendingAlive)
                {

                    //Creamos al personaje
                    Invoke("CreatePlayer", 0.1f);
                    
                    gStates = GamingStates.alive;


                }


                //Aumento de dificultad a medida que avanza el mapa

                switch (GameManager_Menu.currentMundoIndex)
                {
                    case 1:
                        AdjustDificult(distanciaRecorrida);
                        break;
                    case 2:
                        AdjustDificult(distanciaRecorrida1);
                        break;
                    case 3:
                        AdjustDificult(distanciaRecorrida2);
                        break;
                    case 4:
                        AdjustDificult(distanciaRecorrida3);
                        break;

                }


               
               
                break;

            case GameManager_Menu.stateForScene.GameLevel:

                if (gStates == GamingStates.pendingAlive)
                {
                    //Creamos al personaje
                    Invoke("CreatePlayer", 0.1f);
                    Player.alpha = 3f;

                    gStates = GamingStates.alive;
                }

                EscenaCorriendo = GameManager_Menu.currentScene;
                
                break;

            case GameManager_Menu.stateForScene.GameOver:
                


                break;

        }
    }


    //Dedicado a la creacion de personajes CON habilidades por separado y SIN HABILIDADES todo juntos
    void CreatePlayer()
    {
        switch (GameController.playerHabs)
        {

            //Personajes con habilidades 
            case CheckHabilitiesPlayer.withHabilities:

                var player = (GameObject)Instantiate(PlayerPrefab);
                player.transform.position = new Vector3(-3.1f, -4f, -20f);
                player.transform.localRotation = Quaternion.Euler(0, 0, 40);
                player.transform.localScale = new Vector3(0.5f, .5f, .6f);
                var rb2d = player.GetComponent<Rigidbody2D>();
                //Cambiar luego a static
                rb2d.bodyType = RigidbodyType2D.Static;

                var boxCollider = player.GetComponent<BoxCollider2D>();
                boxCollider.size = new Vector3(2f, 2f, 2f);
                

                playerJetPack = true;
                

                SetParameters(true);

                switch(currentLevelInfinite)
                {
                    case WorldsAndsLevels.World1SubLevel1:
                        BonusParameters(true, 0, 0, 0);
                        break;
                    case WorldsAndsLevels.World1SubLevel2:
                        BonusParameters(true, 1f, 0.1f, 0.01f);
                        break;
                    case WorldsAndsLevels.World1Sublevel3:
                        BonusParameters(true, 2.5f, 0.2f, 0.02f);
                        break;

                }
                

                break;


            case CheckHabilitiesPlayer.outHabilities:
                player = (GameObject)Instantiate(PlayerPrefab);
                player.transform.position = new Vector3(-3.1f, -4f, -20f);
                
                player.transform.localScale = new Vector3(0.9f, .9f, 1f);
                rb2d = player.GetComponent<Rigidbody2D>();
                rb2d.bodyType = RigidbodyType2D.Static;

                if(currentLevelInfinite != WorldsAndsLevels.World1Level1)
                {
                    SetParameters(false);
                    BonusParameters(false, 0, 0, 0);
                }
                //

                break;
        
        }
        
        
    }

    #region //Dedicado a transiciones 


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

    private int _playerLives;

    private int[] distance;
    public void TransicionLevels()
    {

       
        distance = new int[4];

        //Vaciamos los objetos
        ObjectPooling.pool.Clear();
        ObjectPooling.parents.Clear();

    }

    public void BonusParameters(bool value, float speed, float spawner, float parallax)
    {
        var speedObjects = 8.5f + speed;
        var spawnerTime = 0.025f + spawner;
        var parallaxBackgroundSpeed = 0.075f + parallax;

        if (value == true)
        {
            

            Coin_logic.speed = _coinSpeed + speedObjects;
            Obstaculos_logica.speed = _obstalesSpeed + speedObjects;
            Parallax_raw.parallaxSpeed = _backgroundSpeed + parallaxBackgroundSpeed;
            ObjectINFINITE_logic.speedObjects = _speedObjects + speedObjects;
            Spawner.maxTime = _timeSpawner - spawnerTime;
            Coins_generator.maxTime = _timeCoins - spawnerTime;
           
        }
        else
        {

            Coin_logic.speed = _coinSpeed - speedObjects;
            Obstaculos_logica.speed = _obstalesSpeed - speedObjects;
            Parallax_raw.parallaxSpeed = _backgroundSpeed - parallaxBackgroundSpeed;
            ObjectINFINITE_logic.speedObjects = _speedObjects - speedObjects;
            Spawner.maxTime = _timeSpawner + spawnerTime;
            Coins_generator.maxTime = _timeCoins + spawnerTime;
           
        }
       
       
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


        _coinsOnPlay = GameController.coinsOnPlay;
        _eggsOnPlay = GameController.eggsOnPlay;
        _diamondsOnPlay = GameController.diamondsOnPlay;

        _playerLives = Player.vidas;

        /* distance[0] = GameController.distanciaRecorrida;
         distance[1] = GameController.distanciaRecorrida1;
         distance[2] = GameController.distanciaRecorrida2;
         distance[3] = GameController.distanciaRecorrida3;*/

       TransitionLevels();
    }

    public void SetParameters(bool jetPack)
    {
        GameController.currentLevelDifficult = _currentLevelDifficult;
        Coin_logic.speed = _coinSpeed;
        Obstaculos_logica.speed = _obstalesSpeed;
        Parallax_raw.parallaxSpeed = _backgroundSpeed;
        ObjectINFINITE_logic.speedObjects = _speedObjects;
        Spawner.maxTime = _timeSpawner;
        Coins_generator.maxTime = _timeCoins;

        if(!jetPack)
        {
            GameController.playerJump = _powerJump;
            GameController.playerGravity = _powerGravity;
        }
       
        GameController.coinsOnPlay = _coinsOnPlay;
        GameController.eggsOnPlay = _eggsOnPlay;
        GameController.diamondsOnPlay = _diamondsOnPlay;

        Player.vidas = _playerLives;

       /* GameController.distanciaRecorrida = distance[0];
        GameController.distanciaRecorrida1 = distance[1];
        GameController.distanciaRecorrida2 = distance[2];
        GameController.distanciaRecorrida3 = distance[3];*/

    }

    #endregion

    //Dedicado para reinicios de nivel o primer arranque

    public void StartGame()
    {
       
        RestartDifficult();


        Player.vidas = LivesToPlayer();

        switch (GameManager_Menu.currentScene)
        {
            case GameManager_Menu.stateForScene.GameLevel:

                //Restablecemos las estrellas:
                Player.CountingStars = 3;
                //Restablecemos las monedas:
                coinsOnPlay = 0;
                eggsOnPlay = 0;
                diamondsOnPlay = 0;
                //Velocidades de los objectos
                Parallax_raw_Level.parallaxSpeed = 0.04f;
                ObstaculosLogic_Levels.speedObject = 3f;
                CoinLogicLevel.speedCoins = 3f;

                break;

            case GameManager_Menu.stateForScene.GameInfinite:

               

                //Vaciamos los objetos
                ObjectPooling.pool.Clear();
                ObjectPooling.parents.Clear();

                //Restablecemos las monedas:
                coinsOnPlay = 0;
                eggsOnPlay = 0;
                diamondsOnPlay = 0;
                //Restablecemos la dificultad;

                RestartDistance();

                subLevelManager.portalIsOnScreen = false;
                subLevelManager.portalWasActivated = 0;
                GameController.gamecontroller.playerJetPack = false;
                
                GameController.playerHabs = GameController.CheckHabilitiesPlayer.outHabilities;


                break;
        }

        GameController.gStates = GameController.GamingStates.pendingAlive;
        GLOBALsuperatedObstacles = 0;
        GLOBALjumpsMaked = 0;
        GLOBALloosedLifesObstacles = 0;
    }

    public void Restart()
    {
        GameManager_Menu.guiOneTAP = true;
        GameManager_Menu.gameManagerMenu.FadeIn();

        revivesCounter = revivesForGame;

        StartCoroutine(TransicionRestart());


    }

    public int LivesToPlayer()
    {
        Player.lifeSumador = 3; // 3

        //Aumentador de vidas segun el nivel que tengas en el personaje
        if (PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] >= 2 && PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] <= 3)
        {
            Player.lifeSumador += 1;
        }
        else if (PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] >= 4 && PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] <= 5)
        {
            Player.lifeSumador += 2;
        }
        else if (PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] >= 6 && PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] <= 7)
        {
            Player.lifeSumador += 3;
        }
        else if (PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] >= 8 && PlayerManagerMenus.repeatedCarts[(long)PlayerManagerMenus.currentPlayer] <= 10)
        {
            Player.lifeSumador += 4;
        }

        return Player.lifeSumador;
    }

    IEnumerator TransicionRestart()
    {
        
        yield return new WaitForSeconds(1.5f);


        if (GameController.gamecontroller.EscenaCorriendo == GameManager_Menu.stateForScene.GameInfinite)
        {
            
            

            var currentWordInfinite = GameController.CurrentInfiniteWorld;
            switch (currentWordInfinite)
            {
                case GameController.Worlds.World1:
                    SceneManager.LoadScene("Game_Infinite", LoadSceneMode.Single);
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
            Debug.Log("yelllo");
            var currentWordInfinite = GameController.CurrentInfiniteWorld;
            switch (currentWordInfinite)
            {
                case GameController.Worlds.World1:
                    SceneManager.LoadScene("Game_Infinite", LoadSceneMode.Single);
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


        GameManager_Menu.gameManagerMenu.FadeOut();
        //gamecontroller.GetComponent<GameManager_Menu>().FadeOut();
        GameManager_Menu.currentScene = EscenaCorriendo;
        StartGame();

    }

    public void RestartDifficult()
    {

        switch (levelDifficultIndex)
        {
            case 0:
                //DifficultLevels(0, 3f, 0.02f, 1.7f, 1f, 8f, 2f);
                           
                DifficultLevels(0, 3.3f, 0.0210f, 1.6f, 8.4f, 2.2f, 12f, 11.5f);
                break;
            case 1:
                DifficultLevels(4, 4.5f, 0.0290f, 1.4f, 10.24f, 3.12f, /*rocket*/ 13f, 12.5f);
                break;
            case 2:
                DifficultLevels(7, 5.4f, 0.035f, 1.25f, 11.62f, 3.81f, /*rocket*/ 14f, 13.5f);
                break;
            case 3:
                DifficultLevels(12, 6.9f, 0.045f, 1f, 13.92f, 4.96f, /*rocket*/ 15f, 14.5f);
                break;

        }

    }

    void DifficultLevels(int a, float b, float c, float spawner,  /*float objects*/ float powerJump, float gravity /*float objects*/
        ,float rocketPU, float rocketPD)
    {
        //Subimos el nivel
        GameController.currentLevelDifficult = a;
        //Agregamos velocidad a las monedas
        Coin_logic.speed = b;


        //Agregamos velocidad a los obstaculos
        Obstaculos_logica.speed = b;
        //Agregamos velocidad al fondo
        Parallax_raw.parallaxSpeed = c;
        //Velocidad de los objetos
        ObjectINFINITE_logic.speedObjects = b;
        //Agregamos para que aparezcan mas rapido 
        Spawner.maxTime = spawner;

        //Velocidad de aparicion de las monedas
        //Coins_generator.maxTime = coins;

        //Velocidad de aparicion de los objetos 

        //ObjectsGenerator_INFINITE.maxTime = objects;

        GameController.playerJump = powerJump;
        GameController.playerGravity = gravity;

        GameController.rocketPropulsionU = rocketPU;
        GameController.rocketPropulsionD = rocketPD;

    }


   


    //Sector Pause
    #region REGION PAUSE
    public void PauseGame()
    {
        GUI_PAUSE.SetActive(true);
        LoadDataPause();
        Time.timeScale = 0f;
        gameIsPaused = true;

        
    }

    public void ResumeGame()
    {
        
        GUI_PAUSE.SetActive(false);
       
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Music()
    {

        if (Options.music)
        {
            Options.music = false;

                MusicButton.GetComponent<Image>().sprite = MusicOFF;

            PlayerPrefs.SetInt("music", Convert.ToInt32(Options.music));

        }
        else if (!Options.music)
        {
            Options.music = true;

                MusicButton.GetComponent<Image>().sprite = MusicON;

            PlayerPrefs.SetInt("music", Convert.ToInt32(Options.music));

        }

    }

    public void Sound()
    {
        if (Options.sound)
        {
            Options.sound = false;
          
                SoundButton.GetComponent<Image>().sprite = SoundOFF;

            PlayerPrefs.SetInt("sound", Convert.ToInt32(Options.sound));
        }
        else if (!Options.sound)
        {

            Options.sound = true;
          
                SoundButton.GetComponent<Image>().sprite = SoundON;

            PlayerPrefs.SetInt("sound", Convert.ToInt32(Options.sound));
        }
    }

    public void LoadDataPause()
    {
       
        if (Options.music)
        {
            MusicButton.GetComponent<Image>().sprite = MusicON;
        }
        else if (!Options.music)
        {
            MusicButton.GetComponent<Image>().sprite = MusicOFF;
        }

        if (Options.sound)
        {
            SoundButton.GetComponent<Image>().sprite = SoundON;
        }
        else if (!Options.sound)
        {
            SoundButton.GetComponent<Image>().sprite = SoundOFF;
        }
    }

    #endregion



    public void AdjustDificult(int distance)
    {
        for (int i = p; p < distance; i++)
        {
            //Subimos el nivel
            currentLevelDifficult++;

            if(currentLevelDifficult <= 27 )
            {
                //Agregamos velocidad a las monedas
                Coin_logic.speed += 0.3f;


                //Agregamos velocidad a los objetos
                ObjectINFINITE_logic.speedObjects += 0.3f;
                //Agregamos velocidad a los obstaculos
                Obstaculos_logica.speed += 0.3f;
                //Agregamos velocidad al fondo
                
                Parallax_raw.parallaxSpeed += 0.002f;
               
            }

            if (currentLevelDifficult <= 38)
            {
                //Agregamos para que aparezcan mas rapido 
                Spawner.maxTime -= 0.05f;
                //Velocidad de aparicion de las monedas
                Coins_generator.maxTime -= 0.01f;
                //Velocidad de aparicion de los objetos
                ObjectsGenerator_INFINITE.maxTime -= 0.05f;
                //Seccion movements player.
                playerJump += 0.46f;
                playerGravity += 0.23f;

                rocketPropulsionU += 0.30f;
                rocketPropulsionD += .30f;

            }

            
            p += 6 + currentLevelDifficult;
        }
    }


    public void GameOver()
    {
       
            Obstaculos_logica.speed = 0f;
            Coin_logic.speed = 0f;
            ObjectINFINITE_logic.speedObjects = 0f;
            Parallax_raw.parallaxSpeed = 0f;

       
        //Le sacamos el jetpack
        GameController.gamecontroller.playerJetPack = false;
        Debug.Log("Playerjetpack status " + GameController.gamecontroller.playerJetPack);
        GameController.playerHabs = GameController.CheckHabilitiesPlayer.outHabilities;



    }

    public void TransitionLevels()
    {
        Obstaculos_logica.speed = 0f;
        Coin_logic.speed = 0f;
        ObjectINFINITE_logic.speedObjects = 0f;
        Parallax_raw.parallaxSpeed = 0f;
        
    }

    IEnumerator stopMap()
    {
       
       yield return new WaitForSeconds(5f);

        if (gStates != GamingStates.alive && !GameController.isTryingToRevive)
        {
            Obstaculos_logica.speed = 0f;
            Coin_logic.speed = 0f;
            ObjectINFINITE_logic.speedObjects = 0f;
            Parallax_raw.parallaxSpeed = 0f;
        }    
        
      
    }

    public void GameOverLevel()
    {
        Parallax_raw_Level.parallaxSpeed = 0f;
        ObstaculosLogic_Levels.speedObject = 0f;
        CoinLogicLevel.speedCoins = 0f;
    }
   
    void RestartDistance()
    {
        distanciaRecorrida = 0;
        distanciaRecorrida1 = 0;
        distanciaRecorrida2 = 0;
        distanciaRecorrida3 = 0;
    }
     
    public int  ReturnDistanceTraveled()
    {
        switch (GameManager_Menu.currentMundoIndex)
        {
            case 1:
                distanceTraveled = distanciaRecorrida;
                break;
            case 2:
                distanceTraveled = distanciaRecorrida1;
                break;
            case 3:
                distanceTraveled = distanciaRecorrida2;
                break;
            case 4:
                distanceTraveled = distanciaRecorrida3;
                break;
        }

        return distanceTraveled;
    }


}

