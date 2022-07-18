using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Menu_Principal.Player_Selector.PlayerSelector2._0;


//SELECTOR DE PERSONAJES // ALBUM
public class PlayerManagerMenus : MonoBehaviour
{


    //Primera entrada: 
    public GameObject firstEntrance;
    public static PlayerManagerMenus instance;
    public static bool enter = false;
    public static bool enterA = false;
    [Header("UI - PRINCIPAL - SELECTOR")]
    public Image lockImage; // selector player
    public Image typePlayer; // selector player
    public Image playerImage; // selector player
    [Header("UI - ALBUM - SELECTOR")]
    public Sprite[] playerSprites; // selector player --- album

    [Header("TEXT  - PRINCIPAL - SELECTOR")]
    public Text habilitiesText; //selector player
    public Text playerName; // selector player
    [Header("BUTTON SELECTPLAYER  - PRINCIPAL - SELECTOR")]
    public Button selectPlayer;  // selector player 
    //<>


    //Repeated carts
    [Header("TEXT REPEATED CARTS")]
    public static int[] repeatedCarts;
    public Text[] numberOfCollection;

    //Estado de cada player BLOQUEADO-DESBLOQUEADO

    [NonSerialized]
    public static bool[,] cart;

    [NonSerialized]
    public static GameController.playersToPlay currentPlayer;

    //Todos los botones para presionar y elegir un personaje
    [Header("BOTONERA - ALBUM Y SELECTOR")]
    public Button[] playerButtons;
    public Image[] playerImageButtons;
    public Image[] backgroundButtons;
    public Text[] playerLevel;
    public Text[] playerNameAlbum;


    public static Dictionary<GameController.playersToPlay, Boolean> playersLocked;
    private Dictionary<GameController.playersToPlay, PlayerConfig> playerConfigs;

    void Start()
    {

        if (GameController.firstPlay != 1 && enter != true)
        {
            FirstEntrance();
        }



        instance = this;
        //Asignamos una cantidad que va a tener


        cart = new bool[113, 9];
        repeatedCarts = new int[113];


        var playersLocked = new Dictionary<GameController.playersToPlay, Boolean>();
        foreach (GameController.playersToPlay player in Enum.GetValues(typeof(GameController.playersToPlay)))
        {
            playersLocked[player] = false;
        }

        // playersLocked[GameController.playersToPlay.ranamocho] = true;
        PlayerManagerMenus.playersLocked = playersLocked;

        var playerConfigs = new Dictionary<GameController.playersToPlay, PlayerConfig>();
        playerConfigs[GameController.playersToPlay.casimocho] = new PlayerConfig("CASIMOCHO", "SOLO UN SIMPLE HUMANO", 60);
        playerConfigs[GameController.playersToPlay.messimocho] = new PlayerConfig("MESSIMOCHO", "EL MEJOR VOLADOR DEL MUNDO", 40);
        playerConfigs[GameController.playersToPlay.casifriend] = new PlayerConfig("CASIFRIEND", "TU MEJOR AMIGO!", 60);
        playerConfigs[GameController.playersToPlay.casiduerme] = new PlayerConfig("CASIDUERME", "IMPOSIBLE DE DESPERTAR", 60);
        playerConfigs[GameController.playersToPlay.casiboxeador] = new PlayerConfig("CASIBOXEADOR", "ROCKY BALBOA", 60);
        playerConfigs[GameController.playersToPlay.todomocho] = new PlayerConfig("TODOMOCHO", "CASIMOCHO MALVADO!", 60);
        playerConfigs[GameController.playersToPlay.zombimocho] = new PlayerConfig("ZOMBIMOCHO", "VOLVIO A LA VIDA PARA SEGUIR VOLANDO!", 60);
        playerConfigs[GameController.playersToPlay.constructor] = new PlayerConfig("CONSTRUCTOR", "OBRERO", 60);
        playerConfigs[GameController.playersToPlay.amungocho] = new PlayerConfig("AMUNGOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casimike] = new PlayerConfig("CASIMIKE", ".", 60);
        playerConfigs[GameController.playersToPlay.casimochoEXE] = new PlayerConfig("CASIMOCHO.EXE", ".", 60);
        playerConfigs[GameController.playersToPlay.casirojo] = new PlayerConfig("CASIROJO", ".", 60);
        playerConfigs[GameController.playersToPlay.timbamocho] = new PlayerConfig("TIMBAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.trollmocho] = new PlayerConfig("TROLLMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.spartamocho] = new PlayerConfig("SPARTAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.minimocho] = new PlayerConfig("MINIMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.marinomocho] = new PlayerConfig("MARINOMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.chuckymocho] = new PlayerConfig("CHUKYMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casiviejo] = new PlayerConfig("CASIVIEJO", ".", 60);
        playerConfigs[GameController.playersToPlay.casitortufan] = new PlayerConfig("CASITORTUFAN", ".", 60);
        playerConfigs[GameController.playersToPlay.casitor] = new PlayerConfig("CASITOR", ".", 60);
        playerConfigs[GameController.playersToPlay.casiprincesa] = new PlayerConfig("CASIPRINCESA", ".", 60);
        playerConfigs[GameController.playersToPlay.payamocho] = new PlayerConfig("PAYAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casirobot] = new PlayerConfig("CASIROBOT", ".", 60);
        playerConfigs[GameController.playersToPlay.mayomocho] = new PlayerConfig("MAYOMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casirius] = new PlayerConfig("CASIRIUS", ".", 60);
        playerConfigs[GameController.playersToPlay.casictor] = new PlayerConfig("CASICTOR", ".", 60);
        playerConfigs[GameController.playersToPlay.casinix] = new PlayerConfig("CASINIX", ".", 60);
        playerConfigs[GameController.playersToPlay.casidongo] = new PlayerConfig("CASIDONGO", ".", 60);
        playerConfigs[GameController.playersToPlay.supermocho] = new PlayerConfig("SUPERMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.batmocho] = new PlayerConfig("BATMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.ironmocho] = new PlayerConfig("IRONMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casihulk] = new PlayerConfig("CASIHULK", ".", 60);
        playerConfigs[GameController.playersToPlay.wolmocho] = new PlayerConfig("WOLMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.spidermocho] = new PlayerConfig("SPIDERMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.mikimocho] = new PlayerConfig("MIKIMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casiesponja] = new PlayerConfig("CASIESPONJA", ".", 60);
        playerConfigs[GameController.playersToPlay.casisonic] = new PlayerConfig("CASISONIC", ".", 60);
        playerConfigs[GameController.playersToPlay.mochosans] = new PlayerConfig("MOCHOSANS", ".", 60);
        playerConfigs[GameController.playersToPlay.gokumocho] = new PlayerConfig("GOKUMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.vegemocho] = new PlayerConfig("VEGEMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.siremocho] = new PlayerConfig("SIREMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.submocho] = new PlayerConfig("SUBMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casipion] = new PlayerConfig("CASIPION", ".", 60);
        playerConfigs[GameController.playersToPlay.pikamocho] = new PlayerConfig("PIKAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.marimocho] = new PlayerConfig("MARIMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casit] = new PlayerConfig("CASI-T", ".", 60);
        playerConfigs[GameController.playersToPlay.casiangel] = new PlayerConfig("CASIANGEL", ".", 60);
        playerConfigs[GameController.playersToPlay.cactumocho] = new PlayerConfig("CACTUMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.dracumocho] = new PlayerConfig("DRACUMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casimomia] = new PlayerConfig("CASIMOMIA", ".", 60);
        playerConfigs[GameController.playersToPlay.casizombie] = new PlayerConfig("CASIZOMBIE", ".", 60);
        playerConfigs[GameController.playersToPlay.casiempanada] = new PlayerConfig("CASIEMPANADA", ".", 60);
        playerConfigs[GameController.playersToPlay.casigordo] = new PlayerConfig("CASIGORDO", ".", 60);
        playerConfigs[GameController.playersToPlay.barmocho] = new PlayerConfig("BARMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.bebemocho] = new PlayerConfig("BEBEMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casiflor] = new PlayerConfig("CASIFLOR", ".", 60);
        playerConfigs[GameController.playersToPlay.elegantemocho] = new PlayerConfig("ELEGANTEMOCHO", ".", 55);
        playerConfigs[GameController.playersToPlay.rapmocho] = new PlayerConfig("RAPMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casimago] = new PlayerConfig("CASIMAGO", ".", 60);
        playerConfigs[GameController.playersToPlay.popomocho] = new PlayerConfig("POPOMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casifreddy] = new PlayerConfig("CASIFREDDY", ".", 60);
        playerConfigs[GameController.playersToPlay.jasonmocho] = new PlayerConfig("JASONMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casiamor] = new PlayerConfig("CASIAMOR", ".", 60);
        playerConfigs[GameController.playersToPlay.casicreper] = new PlayerConfig("CASICREPER", ".", 60);
        playerConfigs[GameController.playersToPlay.casidr] = new PlayerConfig("CasiDR", ".", 60);
        playerConfigs[GameController.playersToPlay.casimorado] = new PlayerConfig("CASIMORADO", ".", 60);
        playerConfigs[GameController.playersToPlay.polimocho] = new PlayerConfig("POLIMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.slendermocho] = new PlayerConfig("SLENDERMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.terminomocho] = new PlayerConfig("TERMINOMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.bailamocho] = new PlayerConfig("BAILAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.piruletamocho] = new PlayerConfig("PIRULETAMOCHO", ".", 55);
        playerConfigs[GameController.playersToPlay.casientrenado] = new PlayerConfig("CASIENTRENADO", ".", 55);
        playerConfigs[GameController.playersToPlay.chapumocho] = new PlayerConfig("CHUPAMOCHO", ".", 55);
        playerConfigs[GameController.playersToPlay.casidiablo] = new PlayerConfig("CASIDIABLO", ".", 60);
        playerConfigs[GameController.playersToPlay.casigod] = new PlayerConfig("CASIGOD", ".", 60);
        playerConfigs[GameController.playersToPlay.casihacker] = new PlayerConfig("CASIHACKER", ".", 60);
        playerConfigs[GameController.playersToPlay.casicerdo] = new PlayerConfig("CASICERDO", ".", 60);
        playerConfigs[GameController.playersToPlay.armamocho] = new PlayerConfig("ARMAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.tarzamocho] = new PlayerConfig("TARZAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.calamarmocho] = new PlayerConfig("CALAMARMOCHO", ".", 55);
        playerConfigs[GameController.playersToPlay.casiloco] = new PlayerConfig("CASILOCO", ".", 60);
        playerConfigs[GameController.playersToPlay.casinoob] = new PlayerConfig("CASINOOB", ".", 60);
        playerConfigs[GameController.playersToPlay.casimono] = new PlayerConfig("CASIMONO", ".", 60);
        playerConfigs[GameController.playersToPlay.astromocho] = new PlayerConfig("ASTROMOCHO", ".", 55);
        playerConfigs[GameController.playersToPlay.espantamocho] = new PlayerConfig("ESPANTAMOCHO", ".", 55);
        playerConfigs[GameController.playersToPlay.toximocho] = new PlayerConfig("TOXIMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casipobre] = new PlayerConfig("CASIPOBRE", ".", 60);
        playerConfigs[GameController.playersToPlay.casibombero] = new PlayerConfig("CASIBOMBERO", ".", 60);
        playerConfigs[GameController.playersToPlay.pinomocho] = new PlayerConfig("PINOMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.chapulinmocho] = new PlayerConfig("CHAPUMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casialien] = new PlayerConfig("CASIALIEN", ".", 60);
        playerConfigs[GameController.playersToPlay.casichef] = new PlayerConfig("CASICHEF", ".", 60);
        playerConfigs[GameController.playersToPlay.caperumocho] = new PlayerConfig("CAPERUMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.wallymocho] = new PlayerConfig("WALLYMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casilyna] = new PlayerConfig("CASILYNA", ".", 60);
        playerConfigs[GameController.playersToPlay.ranamocho] = new PlayerConfig("RANAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.papamocho] = new PlayerConfig("PAPAMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casilusion] = new PlayerConfig("CASILUSION", ".", 60);
        playerConfigs[GameController.playersToPlay.casifuerte] = new PlayerConfig("CASIFUERTE", ".", 60);
        playerConfigs[GameController.playersToPlay.andremocho] = new PlayerConfig("ANDREMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casisoldado] = new PlayerConfig("CASISOLDADO", ".", 60);
        playerConfigs[GameController.playersToPlay.gauchomocho] = new PlayerConfig("GAUCHOMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.mimocho] = new PlayerConfig("MIMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casimochoTV] = new PlayerConfig("CASIMOCHOTV", ".", 60);
        playerConfigs[GameController.playersToPlay.casinvisible] = new PlayerConfig("CASINVISIBLE", ".", 60);
        playerConfigs[GameController.playersToPlay.casimillonario] = new PlayerConfig("CASIMILLONARIO", ".", 60);
        playerConfigs[GameController.playersToPlay.casilobo] = new PlayerConfig("CASILOBO", ".", 60);
        playerConfigs[GameController.playersToPlay.casirey] = new PlayerConfig("CASIREY", ".", 60);
        playerConfigs[GameController.playersToPlay.cavermocho] = new PlayerConfig("CAVERMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.huggymocho] = new PlayerConfig("HUGGYMOCHO", ".", 60);
        playerConfigs[GameController.playersToPlay.casichino] = new PlayerConfig("CASICHINO", ".", 60);
        playerConfigs[GameController.playersToPlay.mommy] = new PlayerConfig("MOMMY", ".", 60);
        this.playerConfigs = playerConfigs;





        //Funcion para desbloquear todos los pj

       /*foreach (GameController.playersToPlay player in Enum.GetValues(typeof(GameController.playersToPlay)))
        {
            playersLocked[player] = true;
            PlayerPrefs.SetInt("PlayerLock" + (long)player, Convert.ToInt32(PlayerManagerMenus.playersLocked[(GameController.playersToPlay)(long)player]));
            //Chequeamos todos los status de los personajes para activar los botones
        }*/


        //Actualizamos los players
        ReadAllPlayers();
        //PlayerIndex (que player esta mostrando en pantalla)
        //currentPlayer = GameController.playersToPlay.casimocho;
        //Actualizamos todos los botones
        ReadAllButtons();

        //Actualizamos todas la cartas repetidas
        //ReadRepeatedCarts();


        //Dejamos como predeterminado el personaje de casimocho

        Casimocho();











    }

    private void Update()
    {

        if (GameManager_Menu.currentEachState != GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR && enter == false)
        {

            enter = true;
        }
        else if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR && enter == true)
        {

            ReadAllPlayers();
            ReadAllButtons();
            ReadRepeatedCartsInMenus();

            if (!GameManager_Menu.DontActivatePlayerSelector)
                Casimocho();




            enter = false;
        }

        if (GameManager_Menu.currentEachState != GameManager_Menu.eachStateForGame.MenuAlbum && enterA == false)
        {
            enterA = true;
        }
        else if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuAlbum && enterA == true)
        {
            ReadRepeatedCarts();
            ReadAllButtons();

            enterA = false;
            enterA = false;
        }

        if (!enter)
        {




            //enter = true;
        }
    }




    public void ReadAllPlayers()
    {
        //Personajes desbloqueados
        foreach (GameController.playersToPlay player in Enum.GetValues(typeof(GameController.playersToPlay)))
        {
            playersLocked[player] = Convert.ToBoolean(PlayerPrefs.GetInt("PlayerLock" + (long)player, 0));
            //Chequeamos todos los status de los personajes para activar los botones
        }
        //cartas y subcartas
    }


    //Lector de personajes desbloqueados y bloqueados. Para activarlos. EN BOTONERA
    public void ReadAllButtons()
    {
        foreach (var item in playersLocked)
        {
            //Chequeamos todos los status de los personajes para activar los botones
            if (item.Value)
            {
                playerImageButtons[(long)item.Key].gameObject.SetActive(true);
                playerImageButtons[(long)item.Key].sprite = playerSprites[(long)item.Key];
                backgroundButtons[(long)item.Key].gameObject.SetActive(true);

                if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuAlbum)
                {
                    playerLevel[(long)item.Key].gameObject.SetActive(true);
                    playerNameAlbum[(long)item.Key].gameObject.SetActive(true);
                }

                //Desactivamos el fondo bloqueado
                playerButtons[(long)item.Key].targetGraphic.enabled = false;
            }
        }
    }

    //Lector de cantidad de cartas repetidas

    void ReadRepeatedCarts()
    {
        for (int i = 0; i < 113; i++)
        {
            repeatedCarts[i] = PlayerPrefs.GetInt("repeatedCarts" + i, 0);

            if (repeatedCarts[i] != null)
            {

                repeatedCarts[i] = PlayerPrefs.GetInt("repeatedCarts" + i, 0);
                numberOfCollection[i].text = repeatedCarts[i].ToString();
            }

        }

    }

    void ReadRepeatedCartsInMenus()
    {
        for (int i = 0; i < 113; i++)
        {
            repeatedCarts[i] = PlayerPrefs.GetInt("repeatedCarts" + i, 0);

            if (repeatedCarts[i] != null)
            {

                repeatedCarts[i] = PlayerPrefs.GetInt("repeatedCarts" + i, 0);
            }

        }

    }



    //PlayPlayer
    public void PlayPlayer()
    {


        MenusManager.MenusManagerInstance.BackSound();

        GameController.player = currentPlayer;

        GameController.playerHabs = GameController.CheckHabilitiesPlayer.outHabilities;
        MenusManager.MenusManagerInstance.CHOOSE_A_MODE();


    }



    //First entrance

    public void FirstEntrance()
    {

        firstEntrance.SetActive(true);

    }

    public void AcceptFirstEntrance()
    {

        firstEntrance.SetActive(false);

        MenusManager.MenusManagerInstance.EGGS();


        GameController.firstPlay = 1;
        PlayerPrefs.SetInt("firstPlay", GameController.firstPlay);
    }



    //Acciones buttons -- SELECTOR
    #region Buttons actions from SELECTOR
    //<>
    private void doGenericPlayer(GameController.playersToPlay player)
    {

        if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR)
        {

            MenusManager.MenusManagerInstance.BackSound();
            PlayerConfig config = playerConfigs[player];
            currentPlayer = player;
            GameController.latestPlayerPlayed = player;
            //Designamos el nombre
            playerName.text = config.Name;
            playerName.fontSize = config.FontSize;


            //Type player
            typePlayer.color = Color.white;

            // habilitiesText.text = config.HabilitiesText;


            repeatedCarts[(long)player] = PlayerPrefs.GetInt("repeatedCarts" + (long)player, 0);

            if (repeatedCarts[(long)player] != null)
            {
                repeatedCarts[(long)player] = PlayerPrefs.GetInt("repeatedCarts" + (long)player, 0);
                habilitiesText.text = repeatedCarts[(long)player].ToString();
            }


        }

        //Si el personaje esta bloqueado
        if (!playersLocked[player])
        {
            //ponemos en rojo la bolita de disponible
            lockImage.color = Color.red;
            //ponemos en negro el color del personaje
            playerImage.color = Color.black;
            playerImage.sprite = playerSprites[(long)player];
            playerName.text = "???";
            //Texto de la habilidad
            //VER SI LA HABILIDAD LA MOSTRAMOS SIEMPRE O SOLO SI ESTA DESBLOQUEADO
            //Desactivamos el button select
            selectPlayer.interactable = false;

        }
        else
        {

            if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.MenuPLAYER_SELECTOR)
            {
                lockImage.color = Color.green;
                playerImage.color = Color.white;
                playerImage.sprite = playerSprites[(long)player];

                if ((long)player <= 49)
                {
                    typePlayer.color = Color.white;
                }
                else if ((long)player >= 49 && (long)player <= 79)
                {
                    typePlayer.color = Color.red;

                }
                else
                    typePlayer.color = Color.yellow;



                //Texto de la habilidad
                //VER SI LA HABILIDAD LA MOSTRAMOS SIEMPRE O SOLO SI ESTA DESBLOQUEADO



                //Activamos el button select
                selectPlayer.interactable = true;
            }
        }

    }

    private void DoGenericALBUM(GameController.playersToPlay player, String method)
    {
        currentPlayer = player;
        GameController.latestPlayerPlayed = player;

        MenusManager.MenusManagerInstance.BackSound();
        //Si el personaje esta bloqueado
        if (!playersLocked[player]) //Si el personaje esta bloqueado
        {
            //Enviar a la tienda en la seccion HUEVOS
            MenusManager.MenusManagerInstance.BackSound();
            MenusManager.MenusManagerInstance.EGGS();

        }
        else
        {
            //Enviarlo al selector de personajes 
            MenusManager.MenusManagerInstance.BackSound();
            MenusManager.MenusManagerInstance.PLAYER_SELECTOR();

            Invoke(method, 1f);


        }
    }

    public void Casimocho()
    {

        this.doGenericPlayer(GameController.playersToPlay.casimocho);
    }

    public void Messimocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.messimocho);
    }

    public void Casifriend()
    {
        this.doGenericPlayer(GameController.playersToPlay.casifriend);
    }

    public void Casiduerme()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiduerme);
    }

    public void CasiBoxeador()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiboxeador);
    }

    public void Todomocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.todomocho);
    }

    public void Zombimocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.zombimocho);
    }

    public void Constructor()
    {
        this.doGenericPlayer(GameController.playersToPlay.constructor);
    }

    public void Amungocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.amungocho);
    }

    public void Casimike()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimike);
    }

    public void CasimochoEXE()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimochoEXE);
    }
    #endregion
    public void Casirojo()
    {
        this.doGenericPlayer(GameController.playersToPlay.casirojo);
    }


    public void Timbamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.timbamocho);
    }

    public void Trollmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.trollmocho);
    }

    public void Spartamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.spartamocho);
    }

    public void Minimocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.minimocho);
    }

    public void Marinomocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.marinomocho);
    }

    public void Chukymocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.chuckymocho);
    }

    public void Casiviejo()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiviejo);
    }

    public void Casitortufan()
    {
        this.doGenericPlayer(GameController.playersToPlay.casitortufan);
    }

    public void Casitor()
    {
        this.doGenericPlayer(GameController.playersToPlay.casitor);
    }

    public void Casiprincesa()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiprincesa);
    }

    public void Payamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.payamocho);
    }

    public void Casirobot()
    {
        this.doGenericPlayer(GameController.playersToPlay.casirobot);
    }

    public void Mayomocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.mayomocho);
    }

    public void Casirius()
    {
        this.doGenericPlayer(GameController.playersToPlay.casirius);
    }

    public void Casictor()
    {
        this.doGenericPlayer(GameController.playersToPlay.casictor);
    }

    public void Casinix()
    {
        this.doGenericPlayer(GameController.playersToPlay.casinix);
    }

    public void Casidongo()
    {
        this.doGenericPlayer(GameController.playersToPlay.casidongo);
    }

    public void Supermocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.supermocho);
    }

    public void Batmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.batmocho);
    }

    public void Ironmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.ironmocho);
    }

    public void Casihulk()
    {
        this.doGenericPlayer(GameController.playersToPlay.casihulk);
    }

    public void Wolmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.wolmocho);
    }

    public void Spidermocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.spidermocho);
    }

    public void Mikimocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.mikimocho);
    }

    public void Casiesponja()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiesponja);
    }

    public void Casisonic()
    {
        this.doGenericPlayer(GameController.playersToPlay.casisonic);
    }

    public void Casisans()
    {
        this.doGenericPlayer(GameController.playersToPlay.mochosans);
    }

    public void Gokumocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.gokumocho);
    }

    public void Vegemocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.vegemocho);
    }

    public void Siremocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.siremocho);
    }

    public void Submocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.submocho);
    }

    public void Casipion()
    {
        this.doGenericPlayer(GameController.playersToPlay.casipion);
    }

    public void Pikamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.pikamocho);
    }

    public void Marimocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.marimocho);
    }

    public void Casit()
    {
        this.doGenericPlayer(GameController.playersToPlay.casit);
    }

    public void Casiangel()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiangel);
    }

    public void Cactumocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.cactumocho);
    }

    public void Dracumocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.dracumocho);
    }

    public void Casimomia()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimomia);
    }

    public void Casizombie()
    {
        this.doGenericPlayer(GameController.playersToPlay.casizombie);
    }

    public void Casiempanada()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiempanada);
    }

    public void Casigordo()
    {
        this.doGenericPlayer(GameController.playersToPlay.casigordo);
    }

    public void Barmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.barmocho);
    }

    public void Bebemocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.bebemocho);
    }

    public void Casiflor()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiflor);
    }

    public void Elegantemocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.elegantemocho);
    }

    public void Rapmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.rapmocho);
    }

    public void Casimago()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimago);
    }

    public void Popomocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.popomocho);
    }

    public void Casifreddy()
    {
        this.doGenericPlayer(GameController.playersToPlay.casifreddy);
    }

    public void Jasonmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.jasonmocho);
    }

    public void Casiamor()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiamor);
    }

    public void Casicreper()
    {
        this.doGenericPlayer(GameController.playersToPlay.casicreper);
    }

    public void Casidr()
    {
        this.doGenericPlayer(GameController.playersToPlay.casidr);
    }

    public void Casimorado()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimorado);
    }

    public void Polimocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.polimocho);
    }

    public void Slendermocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.slendermocho);

    }

    public void Terminomocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.terminomocho);
    }

    public void Bailamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.bailamocho);
    }

    public void Piruletamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.piruletamocho);
    }

    public void Casientrenado()
    {
        this.doGenericPlayer(GameController.playersToPlay.casientrenado);
    }

    public void Chupamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.chapumocho);
    }

    public void Casidiablo()
    {
        this.doGenericPlayer(GameController.playersToPlay.casidiablo);
    }

    public void Casigod()
    {
        this.doGenericPlayer(GameController.playersToPlay.casigod);
    }

    public void Casihacker()
    {
        this.doGenericPlayer(GameController.playersToPlay.casihacker);
    }

    public void Casicerdo()
    {
        this.doGenericPlayer(GameController.playersToPlay.casicerdo);
    }

    public void Armamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.armamocho);
    }

    public void Tarzamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.tarzamocho);
    }

    public void Calamarmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.calamarmocho);
    }

    public void Casiloco()
    {
        this.doGenericPlayer(GameController.playersToPlay.casiloco);
    }

    public void Casinoob()
    {
        this.doGenericPlayer(GameController.playersToPlay.casinoob);
    }

    public void Casimono()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimono);
    }

    public void Astromocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.astromocho);
    }

    public void Espantamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.espantamocho);
    }

    public void Toximocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.toximocho);
    }

    public void Casipober()
    {
        this.doGenericPlayer(GameController.playersToPlay.casipobre);
    }

    public void Casibombero()
    {
        this.doGenericPlayer(GameController.playersToPlay.casibombero);
    }

    public void Pinomocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.pinomocho);
    }

    public void Chapulinmocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.chapulinmocho);
    }

    public void Casialien()
    {
        this.doGenericPlayer(GameController.playersToPlay.casialien);
    }

    public void Casichef()
    {
        this.doGenericPlayer(GameController.playersToPlay.casichef);
    }

    public void Caperumocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.caperumocho);
    }

    public void Wallymocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.wallymocho);
    }

    public void Casilyna()
    {
        this.doGenericPlayer(GameController.playersToPlay.casilyna);
    }

    public void Ranamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.ranamocho);
    }
    public void Papamocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.papamocho);
    }
    public void Casilusion()
    {
        this.doGenericPlayer(GameController.playersToPlay.casilusion);
    }
    public void Casifuerte()
    {
        this.doGenericPlayer(GameController.playersToPlay.casifuerte);
    }
    public void Andremocho ()
    {
        this.doGenericPlayer(GameController.playersToPlay.andremocho);
    }
    public void Casisoldado()
    {
        this.doGenericPlayer(GameController.playersToPlay.casisoldado);
    }
    public void Gauchomocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.gauchomocho);
    }
      public void Mimocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.mimocho);
    }  
    public void CasimochoTV()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimochoTV);
    } 
    public void Casinvisible()
    {
        this.doGenericPlayer(GameController.playersToPlay.casinvisible);
    }
     public void Casimillonario()
    {
        this.doGenericPlayer(GameController.playersToPlay.casimillonario);
    }

     public void Casilobo()
    {
        this.doGenericPlayer(GameController.playersToPlay.casilobo);
    }
      public void Casirey()
    {
        this.doGenericPlayer(GameController.playersToPlay.casirey);
    }
         public void Cavermocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.cavermocho);
    }   
    public void Huggymocho()
    {
        this.doGenericPlayer(GameController.playersToPlay.huggymocho);
    }  
    public void Casichino()
    {
        this.doGenericPlayer(GameController.playersToPlay.casichino);
    }

    public void Mommy()
    {
        this.doGenericPlayer(GameController.playersToPlay.mommy);
    }


    #region Button actions from ALBUM



    public void CasimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimocho, "Casimocho");
    }

    public void MessimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.messimocho, "Messimocho");

    }

    public void CasifriendALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casifriend, "Casifriend");
    }

    public void CasiduermeALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiduerme, "Casiduerme");
    }

    public void CasiboxeadorALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiboxeador, "CasiBoxeador");
    }

    public void TodomochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.todomocho, "Todomocho");
    }

    public void ZombimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.zombimocho, "Zombimocho");
    }

    public void ConstructorALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.constructor, "Constructor");
    }

    public void AmungochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.amungocho, "Amungocho");
    }

    public void CasimikeALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimike, "Casimike");
    }

    public void CasimochoEXEALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimochoEXE, "CasimochoEXE");
    }

    public void CasirojoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casirojo, "Casirojo");
    }

    public void TimbamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.timbamocho, "Timbamocho");
    }

    public void TrollmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.trollmocho, "Trollmocho");
    }

    public void SpartamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.spartamocho, "Spartamocho");
    }

    public void MinimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.minimocho, "Minimocho");
    }

    public void MarinomochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.marinomocho, "Marinomocho");
    }

    public void ChukymochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.chuckymocho, "Chukymocho");
    }

    public void CasiviejoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiviejo, "Casiviejo");
    }

    public void CasitortufanALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casitortufan, "Casitortufan");
    }

    public void CasitorALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casitor, "Casitor");
    }

    public void CasiprincesaALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiprincesa, "Casiprincesa");
    }

    public void PayamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.payamocho, "Payamocho");
    }

    public void CasirobotALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casirobot, "Casirobot");
    }

    public void MayomochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.mayomocho, "Mayomocho");
    }

    public void CasiriusALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casirius, "Casirius");
    }

    public void CasictorALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casictor, "Casictor");
    }

    public void CasinixALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casinix, "Casinix");
    }

    public void CasidongoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casidongo, "Casidongo");
    }

    public void SupermochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.supermocho, "Supermocho");
    }

    public void BatmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.batmocho, "Batmocho");
    }

    public void IronmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.ironmocho, "Ironmocho");
    }

    public void CasihulkALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casihulk, "Casihulk");
    }

    public void WolmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.wolmocho, "Wolmocho");
    }

    public void SpidermochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.spidermocho, "Spidermocho");
    }

    public void MikimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.mikimocho, "Mikimocho");
    }

    public void CasiesponjaALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiesponja, "Casiesponja");
    }

    public void CasisonicALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casisonic, "Casisonic");
    }

    public void CasisansALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.mochosans, "Casisans");
    }

    public void GokumochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.gokumocho, "Gokumocho");
    }

    public void VegemochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.vegemocho, "Vegemocho");
    }

    public void SiremochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.siremocho, "Siremocho");
    }

    public void SubmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.submocho, "Submocho");
    }

    public void CasipionALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casipion, "Casipion");
    }

    public void PikamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.pikamocho, "Pikamocho");
    }

    public void MarimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.marinomocho, "Marimocho");
    }

    public void CasitALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casit, "Casit");
    }

    public void CasiangelALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiangel, "Casiangel");
    }

    public void CactumochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.cactumocho, "Cactumocho");
    }

    public void DracumochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.dracumocho, "Dracumocho");
    }

    public void CasimomiaALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimomia, "Casimomia");
    }

    public void CasizombieALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casizombie, "Casizombie");
    }

    public void CasiempanadaALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiempanada, "Casiempanada");
    }

    public void CasigordoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casigordo, "Casigordo");
    }

    public void BarmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.barmocho, "Barmocho");
    }

    public void BebemmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.bebemocho, "Bebemocho");
    }

    public void CasiflorALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiflor, "Casiflor");
    }

    public void ElegantemochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.elegantemocho, "Elegantemocho");
    }

    public void RapmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.rapmocho, "Rapmocho");
    }

    public void CasimagoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimago, "Casimago");
    }

    public void PopomochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.popomocho, "Popomocho");
    }

    public void CasifreddyALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casifreddy, "Casifreddy");
    }

    public void JasonmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.jasonmocho, "Jasonmocho");
    }

    public void CasiamorALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiamor, "Casiamor");
    }

    public void CasicreperALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casicreper, "Casicreper");
    }

    public void CasiDrALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casidr, "Casidr");
    }

    public void CasimoradoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimorado, "Casimorado");
    }

    public void PolimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.polimocho, "Polimocho");
    }

    public void SlendermochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.slendermocho, "Slendermocho");
    }

    public void TerminomochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.terminomocho, "Terminomocho");
    }

    public void BailamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.bailamocho, "Bailamocho");
    }

    public void PiruletamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.piruletamocho, "Piruletamocho");
    }

    public void CasientrenadoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casientrenado, "Casientrenado");
    }

    public void ChapumochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.chapumocho, "Chapumocho");
    }

    public void CasidiabloALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casidiablo, "Casidiablo");
    }

    public void CasigodALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casigod, "Casigod");
    }

    public void CasihackerALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casihacker, "Casihacker");
    }

    public void CasicerdoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casicerdo, "Casicerdo");
    }

    public void ArmamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.armamocho, "Armamocho");
    }

    public void TarzamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.tarzamocho, "Tarzamocho");
    }

    public void CalamarmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.calamarmocho, "Calamarmocho");
    }

    public void CasilocoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casiloco, "Casiloco");
    }

    public void CasinoobALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casinoob, "Casinoob");
    }

    public void CasimonoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimono, "Casimono");
    }

    public void AstromochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.astromocho, "Astromocho");
    }

    public void EspantamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.espantamocho, "Espantamocho");
    }

    public void ToximochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.toximocho, "Toximocho");
    }

    public void CasipobreALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casipobre, "Casipober");
    }

    public void CasibomberoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casibombero, "Casibombero");
    }

    public void PinomochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.pinomocho, "Pinomocho");
    }

    public void ChapulinmochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.chapulinmocho, "Chapulinmocho");
    }

    public void CasialienALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casialien, "Casialien");
    }

    public void CasichefALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casichef, "Casichef");
    }

    public void CaperumochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.caperumocho, "Caperumocho");
    }

    public void WallymochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.wallymocho, "Wallymocho");
    }

    public void CasilynaALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casilyna, "Casilyna");
    }

    public void RanamochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.ranamocho, "Ranamocho");
    }

    public void PapamochoLBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.papamocho, "Papamocho");
    } 
    public void CasilusionALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casilusion, "Casilusion");
    }
    public void CasifuerteALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casifuerte, "Casifuerte");
    } 
    public void AndremochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.andremocho, "Andremocho");
    }
    public void CasisoldadoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casisoldado, "Casisoldado");
    }  
    public void GauchomochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.gauchomocho, "Gauchomocho");
    } 
    public void MimochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.mimocho, "Mimocho");
    } 
    public void CasimochoTVALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimochoTV, "CasimochoTV");
    } 
    public void CasinvisibleTVALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casinvisible, "Casinvisible");
    }
    public void CasimillonarioALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casimillonario, "Casimillonario");
    } 
    public void CasiloboALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casilobo, "Casilobo");
    }
    public void CasireyALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casirey, "Casirey");
    } 
    public void CavermochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.cavermocho, "Cavermocho");
    }
    public void HuggymochoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.huggymocho, "Huggymocho");
    } 
    public void CasichinoALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.casichino, "Casichino");
    }
    public void MommyALBUM()
    {
        this.DoGenericALBUM(GameController.playersToPlay.mommy, "Mommy");
    }
    #endregion











}
