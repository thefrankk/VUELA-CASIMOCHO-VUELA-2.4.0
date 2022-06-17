
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    #region //How to add new players
    /*
    1r paso: Agregar el personaje en el gamecontroller
    2do paso: Agregar el personaje a las variables Sprites, anim y asignarle estas variables a cada personaje
    3r paso: Agregar todas las variables del personaje en juego y en el album al script playermanagermenus




    */
    #endregion


    // <>
    public static Player playerInstance;

    //Variable de vidas del player
    public static int vidas = 3;
    public static int vidasRevivir = 2;
    public static int lifeSumador = 3;
    //Poder de salto  
    //SALTO EN 14 Y GRAVEDAD 5 
    public static float powerJump = GameController.playerJump;
    
    //Limitador del salto
    bool jump = true;

   

    public static float alpha = 3f;


    //Prefab jump / l0ose
    public Transform particleJump;
    public Transform particleLoose;
    public Transform particleWin;

    //chequeador del contador de estrellas

    public static int CountingStars = 3;

    //Accedemos al rigidbody
    public static Rigidbody2D rb2d;

   

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip jumpSound;

    [Header("Sprites por personajes")]

    #region  /// sprites y animaciones de personajes
    public Sprite casimocho;
    public Sprite messimocho;
    public Sprite casifriend;
    public Sprite casiduerme;
    public Sprite casiboxeador;
    public Sprite todomocho;
    public Sprite zombimocho;
    public Sprite constructor;
    public Sprite amungocho;
    public Sprite casimike;
    public Sprite casimochoEXE;
    public Sprite casirojo;
    public Sprite timbamocho;
    public Sprite trollmocho;
    public Sprite spartamocho;
    public Sprite minimocho;
    public Sprite marinomocho;
    public Sprite chuckymocho;
    public Sprite casiviejo;
    public Sprite casitortufan;
    public Sprite casitor;
    public Sprite casiprincesa;
    public Sprite payamocho;
    public Sprite casirobot;
    public Sprite mayomocho;
    public Sprite casirius;
    public Sprite casictor;
    public Sprite casinix;
    public Sprite casidongo;
    public Sprite supermocho;
    public Sprite batmocho;
    public Sprite ironmocho;
    public Sprite casihulk;
    public Sprite wolmocho;
    public Sprite spidermocho;
    public Sprite mikimocho;
    public Sprite casiesponja;
    public Sprite casisonic;
    public Sprite mochosans;
    public Sprite gokumocho;
    public Sprite vegemocho;
    public Sprite siremocho;
    public Sprite submocho;
    public Sprite casipion;
    public Sprite pikamocho;
    public Sprite marimocho;
    public Sprite casit;
    public Sprite casiangel;
    public Sprite cactumocho;
    public Sprite dracumocho;
    public Sprite casimomia;
    public Sprite casizombie;
    public Sprite casiempanada;
    public Sprite casigordo;
    public Sprite barmocho;
    public Sprite bebemocho;
    public Sprite casiflor;
    public Sprite elegantemocho;
    public Sprite rapmocho;
    public Sprite casimago;
    public Sprite popomocho;
    public Sprite casifreddy;
    public Sprite jasonmocho;
    public Sprite casiamor;
    public Sprite casicreper;
    public Sprite casidr;
    public Sprite casimorado;
    public Sprite polimocho;
    public Sprite slendermocho;
    public Sprite terminomocho;
    public Sprite bailamocho;
    public Sprite piruletamocho;
    public Sprite casientrenado;
    public Sprite chapumocho;
    public Sprite casidiablo;
    public Sprite casigod;
    public Sprite casihacker;
    public Sprite casicerdo;
    public Sprite armamocho;
    public Sprite tarzamocho;
    public Sprite calamarmocho;
    public Sprite casiloco;
    public Sprite casinoob;
    public Sprite casimono;
    public Sprite astromocho;
    public Sprite espantamocho;
    public Sprite toximocho;
    public Sprite casipobre;
    public Sprite casibombero;
    public Sprite pinomocho;
    public Sprite chapulinmocho;
    public Sprite casialien;
    public Sprite casichef;
    public Sprite caperumocho;
    public Sprite wallymocho;
    public Sprite casilyna;
    public Sprite ranamocho;
    public Sprite papamocho;
    public Sprite casilusion;
    public Sprite casifuerte;
    public Sprite andremocho;
    public Sprite casisoldado;
    public Sprite gauchomocho;
    public Sprite mimocho;
    public Sprite casimochoTV;
    public Sprite casinvisible;
    public Sprite casimillonario;
    public Sprite casilobo;
    public Sprite casirey;
    public Sprite cavermocho;
    public Sprite huggymocho;
    public Sprite casichino;
    public Sprite mommy;
    #endregion
    #region animaciones
    [Header("Animaciones por personaje")]
    public RuntimeAnimatorController anim_Casimocho;
    public RuntimeAnimatorController anim_Messimocho;
    public RuntimeAnimatorController anim_Casifriend;
    public RuntimeAnimatorController anim_casiDuerme;
    public RuntimeAnimatorController anim_casiboxeador;
    public RuntimeAnimatorController anim_todomocho;
    public RuntimeAnimatorController anim_zombimocho;
    public RuntimeAnimatorController anim_constructor;
    public RuntimeAnimatorController anim_amungocho;
    public RuntimeAnimatorController anim_casimike;
    public RuntimeAnimatorController anim_casimochoEXE;
    public RuntimeAnimatorController anim_casirojo;

    public RuntimeAnimatorController anim_timbamocho;
    public RuntimeAnimatorController anim_trollmocho;
    public RuntimeAnimatorController anim_spartamocho;
    public RuntimeAnimatorController anim_minimocho;
    public RuntimeAnimatorController anim_marinomocho;
    public RuntimeAnimatorController anim_chuckymocho;
    public RuntimeAnimatorController anim_casiviejo;
    public RuntimeAnimatorController anim_casitortufan;
    public RuntimeAnimatorController anim_casitor;
    public RuntimeAnimatorController anim_casiprincesa;
    public RuntimeAnimatorController anim_payamocho;
    public RuntimeAnimatorController anim_casirobot;
    public RuntimeAnimatorController anim_mayomocho;
    public RuntimeAnimatorController anim_casirius;
    public RuntimeAnimatorController anim_casictor;
    public RuntimeAnimatorController anim_casinix;
    public RuntimeAnimatorController anim_casidongo;
    public RuntimeAnimatorController anim_supermocho;
    public RuntimeAnimatorController anim_batmocho;
    public RuntimeAnimatorController anim_ironmocho;
    public RuntimeAnimatorController anim_casihulk;
    public RuntimeAnimatorController anim_wolmocho;
    public RuntimeAnimatorController anim_spidermocho;
    public RuntimeAnimatorController anim_mikimocho;
    public RuntimeAnimatorController anim_casiesponja;
    public RuntimeAnimatorController anim_casisonic;
    public RuntimeAnimatorController anim_mochosans;
    public RuntimeAnimatorController anim_gokumocho;
    public RuntimeAnimatorController anim_vegemocho;
    public RuntimeAnimatorController anim_siremocho;
    public RuntimeAnimatorController anim_submocho;
    public RuntimeAnimatorController anim_casipion;
    public RuntimeAnimatorController anim_pikamocho;
    public RuntimeAnimatorController anim_marimocho;
    public RuntimeAnimatorController anim_casit;
    public RuntimeAnimatorController anim_casiangel;
    public RuntimeAnimatorController anim_cactumocho;
    public RuntimeAnimatorController anim_dracumocho;
    public RuntimeAnimatorController anim_casimomia;
    public RuntimeAnimatorController anim_casizombie;
    public RuntimeAnimatorController anim_casiempanada;
    public RuntimeAnimatorController anim_casigordo;
    public RuntimeAnimatorController anim_barmocho;
    public RuntimeAnimatorController anim_bebemocho;
    public RuntimeAnimatorController anim_casiflor;
    public RuntimeAnimatorController anim_elegantemocho;
    public RuntimeAnimatorController anim_rapmocho;
    public RuntimeAnimatorController anim_casimago;
    public RuntimeAnimatorController anim_popomocho;
    public RuntimeAnimatorController anim_casifreddy;
    public RuntimeAnimatorController anim_jasonmocho;
    public RuntimeAnimatorController anim_casiamor;
    public RuntimeAnimatorController anim_casicreper;
    public RuntimeAnimatorController anim_casidr;
    public RuntimeAnimatorController anim_casimorado;
    public RuntimeAnimatorController anim_polimocho;
    public RuntimeAnimatorController anim_slendermocho;
    public RuntimeAnimatorController anim_terminomocho;
    public RuntimeAnimatorController anim_bailamocho;
    public RuntimeAnimatorController anim_piruletamocho;
    public RuntimeAnimatorController anim_casientrenado;
    public RuntimeAnimatorController anim_chapumocho;
    public RuntimeAnimatorController anim_casidiablo;
    public RuntimeAnimatorController anim_casigod;
    public RuntimeAnimatorController anim_casihacker;
    public RuntimeAnimatorController anim_casicerdo;
    public RuntimeAnimatorController anim_armamocho;
    public RuntimeAnimatorController anim_tarzamocho;
    public RuntimeAnimatorController anim_calamarmocho;
    public RuntimeAnimatorController anim_casiloco;
    public RuntimeAnimatorController anim_casinoob;
    public RuntimeAnimatorController anim_casimono;
    public RuntimeAnimatorController anim_astromocho;
    public RuntimeAnimatorController anim_espantamocho;
    public RuntimeAnimatorController anim_toximocho;
    public RuntimeAnimatorController anim_casipobre;
    public RuntimeAnimatorController anim_casibombero;
    public RuntimeAnimatorController anim_pinomocho;
    public RuntimeAnimatorController anim_chapulinmocho;

    public RuntimeAnimatorController anim_casialien;
    public RuntimeAnimatorController anim_casichef;
    public RuntimeAnimatorController anim_caperumocho;
    public RuntimeAnimatorController anim_wallymocho;
    public RuntimeAnimatorController anim_casilyna;
    public RuntimeAnimatorController anim_ranamocho;
    public RuntimeAnimatorController anim_papamocho;
    public RuntimeAnimatorController anim_casilusion;
    public RuntimeAnimatorController anim_casifuerte;
    public RuntimeAnimatorController anim_andremocho;
    public RuntimeAnimatorController anim_casisoldado;
    public RuntimeAnimatorController anim_gauchomocho;
    public RuntimeAnimatorController anim_mimocho;
    public RuntimeAnimatorController anim_casimochoTV;
    public RuntimeAnimatorController anim_casinvisible;
    public RuntimeAnimatorController anim_casimillonario;
    public RuntimeAnimatorController anim_casilobo;
    public RuntimeAnimatorController anim_casirey;
    public RuntimeAnimatorController anim_cavermocho;
    public RuntimeAnimatorController anim_huggymocho;
    public RuntimeAnimatorController anim_casichino;
    public RuntimeAnimatorController anim_mommy;


    #endregion 

    Animator anim;
    Sprite sp;




    private void Awake()
    {
        //Seteamos los fps
       Application.targetFrameRate = 144;

        //Asignamos la variable rb2d a la clase rigidbody
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Static;

        

        //Traemos los componente
        anim = GetComponent<Animator>();
        sp = GetComponent<Sprite>();

       /* var playerAlpha = gameObject.GetComponent<SpriteRenderer>().color;
        playerAlpha.a = 1;
        gameObject.GetComponent<SpriteRenderer>().color = playerAlpha;*/

    }
    // Start is called before the first frame update
    void Start()
    {
     

        powerJump = GameController.playerJump;
        rb2d.gravityScale = GameController.playerGravity;
        //Chooose Skin
        switch (GameController.player)
        {
            case GameController.playersToPlay.casimocho:

                this.sp = casimocho;
                this.anim.runtimeAnimatorController = anim_Casimocho;

                break;

            case GameController.playersToPlay.messimocho:

                this.sp = messimocho;
                this.anim.runtimeAnimatorController = anim_Messimocho;

                break;

            case GameController.playersToPlay.casifriend:

                this.sp = casifriend;
                this.anim.runtimeAnimatorController = anim_Casifriend;

                break;

            case GameController.playersToPlay.casiduerme:

                this.sp = casiduerme;
                this.anim.runtimeAnimatorController = anim_casiDuerme;

                break;

            case GameController.playersToPlay.casiboxeador:

                this.sp = casiboxeador;
                this.anim.runtimeAnimatorController = anim_casiboxeador;

                break;

            case GameController.playersToPlay.todomocho:

                this.sp = todomocho;
                this.anim.runtimeAnimatorController = anim_todomocho;

                break;

            case GameController.playersToPlay.zombimocho:

                this.sp = zombimocho;
                this.anim.runtimeAnimatorController = anim_zombimocho;

                break;

            case GameController.playersToPlay.constructor:

                this.sp = constructor;
                this.anim.runtimeAnimatorController = anim_constructor;

                break;

            case GameController.playersToPlay.amungocho:

                this.sp = amungocho;
                this.anim.runtimeAnimatorController = anim_amungocho;

                break;

            case GameController.playersToPlay.casimike:

                this.sp = casimike;
                this.anim.runtimeAnimatorController = anim_casimike;

                break;

            case GameController.playersToPlay.casimochoEXE:

                this.sp = casimochoEXE;
                this.anim.runtimeAnimatorController = anim_casimochoEXE;

                break;

            case GameController.playersToPlay.casirojo:

                this.sp = casirojo;
                this.anim.runtimeAnimatorController = anim_casirojo;

                break;

            case GameController.playersToPlay.timbamocho:

                this.sp = timbamocho;
                this.anim.runtimeAnimatorController = anim_timbamocho;

                break;

            case GameController.playersToPlay.trollmocho:

                this.sp = trollmocho;
                this.anim.runtimeAnimatorController = anim_trollmocho;

                break;
            case GameController.playersToPlay.spartamocho:

                this.sp = spartamocho;
                this.anim.runtimeAnimatorController = anim_spartamocho;

                break;
            case GameController.playersToPlay.minimocho:

                this.sp = minimocho;
                this.anim.runtimeAnimatorController = anim_minimocho;

                break;

            case GameController.playersToPlay.marinomocho:

                this.sp = marinomocho;
                this.anim.runtimeAnimatorController = anim_marinomocho;

                break;

            case GameController.playersToPlay.chuckymocho:

                this.sp = chuckymocho;
                this.anim.runtimeAnimatorController = anim_chuckymocho;

                break;

            case GameController.playersToPlay.casiviejo:

                this.sp = casiviejo;
                this.anim.runtimeAnimatorController = anim_casiviejo;

                break;
            case GameController.playersToPlay.casitortufan:

                this.sp = casitortufan;
                this.anim.runtimeAnimatorController = anim_casitortufan;

                break;
            case GameController.playersToPlay.casitor:

                this.sp = casitor;
                this.anim.runtimeAnimatorController = anim_casitor;

                break;
            case GameController.playersToPlay.casiprincesa:

                this.sp = casiprincesa;
                this.anim.runtimeAnimatorController = anim_casiprincesa;

                break;
            case GameController.playersToPlay.payamocho:

                this.sp = payamocho;
                this.anim.runtimeAnimatorController = anim_payamocho;

                break;
            case GameController.playersToPlay.casirobot:

                this.sp = casirobot;
                this.anim.runtimeAnimatorController = anim_casirobot;

                break;
            case GameController.playersToPlay.mayomocho:

                this.sp = mayomocho;
                this.anim.runtimeAnimatorController = anim_mayomocho;

                break;
            case GameController.playersToPlay.casirius:

                this.sp = casirius;
                this.anim.runtimeAnimatorController = anim_casirius;

                break;
            case GameController.playersToPlay.casictor:

                this.sp = casictor;
                this.anim.runtimeAnimatorController = anim_casictor;

                break;
            case GameController.playersToPlay.casinix:

                this.sp = casinix;
                this.anim.runtimeAnimatorController = anim_casinix;

                break;
            case GameController.playersToPlay.casidongo:

                this.sp = casidongo;
                this.anim.runtimeAnimatorController = anim_casidongo;

                break;
            case GameController.playersToPlay.supermocho:

                this.sp = supermocho;
                this.anim.runtimeAnimatorController = anim_supermocho;

                break;
            case GameController.playersToPlay.batmocho:

                this.sp = batmocho;
                this.anim.runtimeAnimatorController = anim_batmocho;

                break;
            case GameController.playersToPlay.ironmocho:

                this.sp = ironmocho;
                this.anim.runtimeAnimatorController = anim_ironmocho;

                break;
            case GameController.playersToPlay.casihulk:

                this.sp = casihulk;
                this.anim.runtimeAnimatorController = anim_casihulk;

                break;
            case GameController.playersToPlay.wolmocho:

                this.sp = wolmocho;
                this.anim.runtimeAnimatorController = anim_wolmocho;

                break;
            case GameController.playersToPlay.spidermocho:

                this.sp = spidermocho;
                this.anim.runtimeAnimatorController = anim_spidermocho;

                break;
            case GameController.playersToPlay.mikimocho:

                this.sp = mikimocho;
                this.anim.runtimeAnimatorController = anim_mikimocho;

                break;
            case GameController.playersToPlay.casiesponja:

                this.sp = casiesponja;
                this.anim.runtimeAnimatorController = anim_casiesponja;

                break;
            case GameController.playersToPlay.casisonic:

                this.sp = casisonic;
                this.anim.runtimeAnimatorController = anim_casisonic;

                break;
            case GameController.playersToPlay.mochosans:

                this.sp = mochosans;
                this.anim.runtimeAnimatorController = anim_mochosans;

                break;
            case GameController.playersToPlay.gokumocho:

                this.sp = gokumocho;
                this.anim.runtimeAnimatorController = anim_gokumocho;

                break;
            case GameController.playersToPlay.vegemocho:

                this.sp = vegemocho;
                this.anim.runtimeAnimatorController = anim_vegemocho;

                break;
            case GameController.playersToPlay.siremocho:

                this.sp = siremocho;
                this.anim.runtimeAnimatorController = anim_siremocho;

                break;
            case GameController.playersToPlay.submocho:

                this.sp = submocho;
                this.anim.runtimeAnimatorController = anim_submocho;

                break;
            case GameController.playersToPlay.casipion:

                this.sp = casipion;
                this.anim.runtimeAnimatorController = anim_casipion;

                break;
            case GameController.playersToPlay.pikamocho:

                this.sp = pikamocho;
                this.anim.runtimeAnimatorController = anim_pikamocho;

                break;
            case GameController.playersToPlay.marimocho:

                this.sp = marimocho;
                this.anim.runtimeAnimatorController = anim_marimocho;

                break;
            case GameController.playersToPlay.casit:

                this.sp = casit;
                this.anim.runtimeAnimatorController = anim_casit;

                break;
            case GameController.playersToPlay.casiangel:

                this.sp = casiangel;
                this.anim.runtimeAnimatorController = anim_casiangel;

                break;
            case GameController.playersToPlay.cactumocho:

                this.sp = cactumocho;
                this.anim.runtimeAnimatorController = anim_cactumocho;

                break;
            case GameController.playersToPlay.dracumocho:

                this.sp = dracumocho;
                this.anim.runtimeAnimatorController = anim_dracumocho;

                break;
            case GameController.playersToPlay.casimomia:

                this.sp = casimomia;
                this.anim.runtimeAnimatorController = anim_casimomia;

                break;
            case GameController.playersToPlay.casizombie:

                this.sp = casizombie;
                this.anim.runtimeAnimatorController = anim_casizombie;

                break;

            case GameController.playersToPlay.casiempanada:

                this.sp = casiempanada;
                this.anim.runtimeAnimatorController = anim_casiempanada;

                break;

            case GameController.playersToPlay.casigordo:

                this.sp = casigordo;
                this.anim.runtimeAnimatorController = anim_casigordo;

                break;
            case GameController.playersToPlay.barmocho:

                this.sp = barmocho;
                this.anim.runtimeAnimatorController = anim_barmocho;

                break;
            case GameController.playersToPlay.bebemocho:

                this.sp = bebemocho;
                this.anim.runtimeAnimatorController = anim_bebemocho;

                break;
            case GameController.playersToPlay.casiflor:

                this.sp = casiflor;
                this.anim.runtimeAnimatorController = anim_casiflor;

                break;
            case GameController.playersToPlay.elegantemocho:

                this.sp = elegantemocho;
                this.anim.runtimeAnimatorController = anim_elegantemocho;

                break;
            case GameController.playersToPlay.rapmocho:

                this.sp = rapmocho;
                this.anim.runtimeAnimatorController = anim_rapmocho;

                break;
            case GameController.playersToPlay.casimago:

                this.sp = casimago;
                this.anim.runtimeAnimatorController = anim_casimago;

                break;
            case GameController.playersToPlay.popomocho:

                this.sp = popomocho;
                this.anim.runtimeAnimatorController = anim_popomocho;

                break;
            case GameController.playersToPlay.casifreddy:

                this.sp = casifreddy;
                this.anim.runtimeAnimatorController = anim_casifreddy;

                break;
            case GameController.playersToPlay.jasonmocho:

                this.sp = jasonmocho;
                this.anim.runtimeAnimatorController = anim_jasonmocho;

                break;
            case GameController.playersToPlay.casiamor:

                this.sp = casiamor;
                this.anim.runtimeAnimatorController = anim_casiamor;

                break;

            case GameController.playersToPlay.casicreper:

                this.sp = casicreper;
                this.anim.runtimeAnimatorController = anim_casicreper;

                break;
            case GameController.playersToPlay.casidr:

                this.sp = casidr;
                this.anim.runtimeAnimatorController = anim_casidr;

                break;

            case GameController.playersToPlay.casimorado:

                this.sp = casimorado;
                this.anim.runtimeAnimatorController = anim_casimorado;

                break;
            case GameController.playersToPlay.polimocho:

                this.sp = polimocho;
                this.anim.runtimeAnimatorController = anim_polimocho;

                break;
            case GameController.playersToPlay.slendermocho:

                this.sp = slendermocho;
                this.anim.runtimeAnimatorController = anim_slendermocho;

                break;
            case GameController.playersToPlay.terminomocho:

                this.sp = terminomocho;
                this.anim.runtimeAnimatorController = anim_terminomocho;

                break;
            case GameController.playersToPlay.bailamocho:

                this.sp = bailamocho;
                this.anim.runtimeAnimatorController = anim_bailamocho;

                break;
            case GameController.playersToPlay.piruletamocho:

                this.sp = piruletamocho;
                this.anim.runtimeAnimatorController = anim_piruletamocho;

                break;
            case GameController.playersToPlay.casientrenado:

                this.sp = casientrenado;
                this.anim.runtimeAnimatorController = anim_casientrenado;

                break;
            case GameController.playersToPlay.chapumocho:

                this.sp = chapumocho;
                this.anim.runtimeAnimatorController = anim_chapumocho;

                break;
            case GameController.playersToPlay.casidiablo:

                this.sp = casidiablo;
                this.anim.runtimeAnimatorController = anim_casidiablo;

                break;
            case GameController.playersToPlay.casigod:

                this.sp = casigod;
                this.anim.runtimeAnimatorController = anim_casigod;

                break;
            case GameController.playersToPlay.casihacker:

                this.sp = casihacker;
                this.anim.runtimeAnimatorController = anim_casihacker;

                break;

            case GameController.playersToPlay.casicerdo:

                this.sp = casicerdo;
                this.anim.runtimeAnimatorController = anim_casicerdo;

                break;
            case GameController.playersToPlay.armamocho:

                this.sp = armamocho;
                this.anim.runtimeAnimatorController = anim_armamocho;

                break;
            case GameController.playersToPlay.tarzamocho:

                this.sp = tarzamocho;
                this.anim.runtimeAnimatorController = anim_tarzamocho;

                break;
            case GameController.playersToPlay.calamarmocho:

                this.sp = calamarmocho;
                this.anim.runtimeAnimatorController = anim_calamarmocho;

                break;
            case GameController.playersToPlay.casiloco:

                this.sp = casiloco;
                this.anim.runtimeAnimatorController = anim_casiloco;

                break;
            case GameController.playersToPlay.casinoob:

                this.sp = casinoob;
                this.anim.runtimeAnimatorController = anim_casinoob;

                break;
            case GameController.playersToPlay.casimono:

                this.sp = casimono;
                this.anim.runtimeAnimatorController = anim_casimono;

                break;
            case GameController.playersToPlay.astromocho:

                this.sp = astromocho;
                this.anim.runtimeAnimatorController = anim_astromocho;

                break;
            case GameController.playersToPlay.espantamocho:

                this.sp = espantamocho;
                this.anim.runtimeAnimatorController = anim_espantamocho;

                break;
            case GameController.playersToPlay.toximocho:

                this.sp = toximocho;
                this.anim.runtimeAnimatorController = anim_toximocho;

                break;
            case GameController.playersToPlay.casipobre:

                this.sp = casipobre;
                this.anim.runtimeAnimatorController = anim_casipobre;

                break;
            case GameController.playersToPlay.casibombero:

                this.sp = casibombero;
                this.anim.runtimeAnimatorController = anim_casibombero;

                break;
            case GameController.playersToPlay.pinomocho:

                this.sp = pinomocho;
                this.anim.runtimeAnimatorController = anim_pinomocho;

                break;
            case GameController.playersToPlay.chapulinmocho:

                this.sp = chapulinmocho;
                this.anim.runtimeAnimatorController = anim_chapulinmocho;

                break;
            case GameController.playersToPlay.casialien:

                this.sp = casialien;
                this.anim.runtimeAnimatorController = anim_casialien;

                break;
            case GameController.playersToPlay.casichef:

                this.sp = casichef;
                this.anim.runtimeAnimatorController = anim_casichef;

                break;
            case GameController.playersToPlay.caperumocho:

                this.sp = caperumocho;
                this.anim.runtimeAnimatorController = anim_caperumocho;

                break;
            case GameController.playersToPlay.wallymocho:

                this.sp = wallymocho;
                this.anim.runtimeAnimatorController = anim_wallymocho;

                break;
            case GameController.playersToPlay.casilyna:

                this.sp = casilyna;
                this.anim.runtimeAnimatorController = anim_casilyna;

                break;
            case GameController.playersToPlay.ranamocho:

                this.sp = ranamocho;
                this.anim.runtimeAnimatorController = anim_ranamocho;

                break;

            case GameController.playersToPlay.papamocho:

                this.sp = papamocho;
                this.anim.runtimeAnimatorController = anim_papamocho;

                break;
            case GameController.playersToPlay.casilusion:

                this.sp = casilusion;
                this.anim.runtimeAnimatorController = anim_casilusion;

                break;
            case GameController.playersToPlay.casifuerte:

                this.sp = casifuerte;
                this.anim.runtimeAnimatorController = anim_casifuerte;

                break;
            case GameController.playersToPlay.andremocho:

                this.sp = andremocho;
                this.anim.runtimeAnimatorController = anim_andremocho;

                break;
            case GameController.playersToPlay.casisoldado:

                this.sp = casisoldado;
                this.anim.runtimeAnimatorController = anim_casisoldado;

                break;
            case GameController.playersToPlay.gauchomocho:

                this.sp = gauchomocho;
                this.anim.runtimeAnimatorController = anim_gauchomocho;

                break;  

            case GameController.playersToPlay.mimocho:

                this.sp = mimocho;
                this.anim.runtimeAnimatorController = anim_mimocho;

                break;
            case GameController.playersToPlay.casimochoTV:

                this.sp = casimochoTV;
                this.anim.runtimeAnimatorController = anim_casimochoTV;

                break;
            case GameController.playersToPlay.casinvisible:

                this.sp = casinvisible;
                this.anim.runtimeAnimatorController = anim_casinvisible;

                break;
            
            case GameController.playersToPlay.casimillonario:

                this.sp = casimillonario;
                this.anim.runtimeAnimatorController = anim_casimillonario;

                break;
            case GameController.playersToPlay.casilobo:

                this.sp = casilobo;
                this.anim.runtimeAnimatorController = anim_casilobo;

                break; 
            case GameController.playersToPlay.casirey:

                this.sp = casirey;
                this.anim.runtimeAnimatorController = anim_casirey;

                break;
            case GameController.playersToPlay.cavermocho:

                this.sp = cavermocho;
                this.anim.runtimeAnimatorController = anim_cavermocho;

                break;
            case GameController.playersToPlay.huggymocho:

                this.sp = huggymocho;
                this.anim.runtimeAnimatorController = anim_huggymocho;

                break;
            case GameController.playersToPlay.casichino:

                this.sp = casichino;
                this.anim.runtimeAnimatorController = anim_casichino;

                break;

            case GameController.playersToPlay.mommy:

                this.sp = mommy;
                this.anim.runtimeAnimatorController = anim_mommy;

                break;

        }

    }
   
    // Update is called once per frames
    private void Update()
    {
     

        switch (GameManager_Menu.currentScene)
        {
            case GameManager_Menu.stateForScene.GameInfinite:


               
                //Si el personaje entra en transicion, lo destruimos.
                if (GameController.gStates == GameController.GamingStates.dead)
                {
                    DestroyPlayerTransition();
                }

                if (GameController.gamecontroller.playerJetPack == true)
                    return;

                if (Input.GetMouseButtonDown(0) && jump)
                {
                    Vector3 mousePosition = Input.mousePosition;

                    if(mousePosition.y < Screen.height/1.2 )
                    {
                       
                        if (!GameController.gameIsPaused)
                        {
                            //Agregamos velocidad a Y.

                            //Activamos el menu
                            if (GameManager_Menu.guiOneTAP && GameController.gStates == GameController.GamingStates.alive)
                            {
                                rb2d.bodyType = RigidbodyType2D.Dynamic;
                                GameManager_Menu.guiOneTAP = false;
                            }


                            if (Options.sound)
                            {
                                audioSource.PlayOneShot(jumpSound);
                            }

                            if (GameController.gStates == GameController.GamingStates.alive)
                            {
                                Instantiate(particleJump, new Vector3(transform.position.x - 0.3f, transform.position.y - 0.35f, transform.position.z + 10f), Quaternion.identity);

                                rb2d.velocity = new Vector2(0, powerJump);
                                //Desactivamos el poder de salto
                                jump = false;

                                //Invocamos la funcion en 0.4 segundos para poder volver a saltar
                                Invoke("CanJump", .05f);

                                GameController.GLOBALjumpsMaked += 1;
                            }






                        }
                        
                    }    

                    
                }


                break;

            case GameManager_Menu.stateForScene.GameLevel:
               

                if (Input.GetMouseButtonDown(0) && jump)
                {

                    Vector3 mousePosition = Input.mousePosition;

                    if (mousePosition.y < Screen.height / 1.2)
                    {

                        if (!GameController.gameIsPaused)
                        {
                            if(!GameManager_Menu.loadingScene)
                            {
                                //Activamos el menu
                                if (GameManager_Menu.guiOneTAP && GameController.gStates == GameController.GamingStates.alive)
                                {
                                    rb2d.bodyType = RigidbodyType2D.Dynamic;
                                    GameManager_Menu.guiOneTAP = false;
                                }
                                if (Options.sound)
                                {
                                    audioSource.PlayOneShot(jumpSound);
                                }

                               if(GameController.gStates == GameController.GamingStates.alive)
                                {

                                    Instantiate(particleJump, new Vector3(transform.position.x - 0.3f, transform.position.y - 0.35f, transform.position.z + 10f), Quaternion.identity);

                                    rb2d.velocity = new Vector2(0, powerJump);
                                    //Desactivamos el poder de salto
                                    jump = false;

                                    //Invocamos la funcion en 0.4 segundos para poder volver a saltar
                                    Invoke("CanJump", .05f);

                                    GameController.GLOBALjumpsMaked += 1;
                                }
                                    
                              
                                
                            }    
                           
                        }

                    }
                   
                }

              
                
                break;
           // case GameManager_Menu.stateForScene.YouWin:

                
                                
               // break;
        }
            


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "end_level")
        {

            SoundManager.sharedInstance.WinSound();
            WinLevel();


        }

        //Colision contra el map limit

        if(collision.tag == "mapLimit")
        {
            Player.vidas -= Player.vidas;
          
            this.GetComponent<SpriteRenderer>().color = Color.red;

            //Matamos al player, en base a esta variable, se activiaran otros mecanismos.
            GameController.gStates = GameController.GamingStates.youLoose;
        }
        #region //Aumentar puntaje cuando pasamos entremedio de los palos

        //Chequeamos el tag del objeto colisionando
        if (collision.tag == "obstacles")
        {
          
            if (collision.GetType() == typeof(CapsuleCollider2D))
            {
                switch (GameManager_Menu.currentMundoIndex)
                {
                    case 1:
                        //Agregamos la distancia
                        GameController.distanciaRecorrida += 1;
                        break;
                    case 2:
                        GameController.distanciaRecorrida1 += 1;
                        break;
                    case 3:
                        GameController.distanciaRecorrida2 += 1;
                        break;
                    case 4:
                        GameController.distanciaRecorrida3 += 1;
                        break;
                }

                GameController.GLOBALsuperatedObstacles += 1;
               


            }

        }
        #endregion

    }


    //Poder volver a saltar
    void CanJump()
    {
        jump = true;
    }

    private void OnBecameInvisible()
    {
        if (GameController.gStates == GameController.GamingStates.youWin)
            return;

        if (GameController.gStates == GameController.GamingStates.transition)
            return;


        //Portales
        subLevelManager.portalIsOnScreen = false;
        subLevelManager.portalWasActivated = 0;

        //Ponemos el nuevo estado
        GameController.gStates = GameController.GamingStates.becameInvisible;
        //Cambiamos el estado del player
        var playerAlpha = gameObject.GetComponent<SpriteRenderer>().color;
        playerAlpha.a = 0;
        gameObject.GetComponent<SpriteRenderer>().color = playerAlpha;
        rb2d.bodyType = RigidbodyType2D.Kinematic;

        //Creamos las particulas.
        if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameLevel || GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameInfinite)
            {
               
                Instantiate(particleLoose, new Vector3(transform.position.x+2f, transform.position.y+0.5f, transform.position.z), Quaternion.identity);
                SoundManager.sharedInstance.LoseSound();
                
            }
                 
        if(GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameLevel)
        {
            
            StartCoroutine(DeathPlayer(false, true, false));

        }

        if (GameManager_Menu.currentScene == GameManager_Menu.stateForScene.GameInfinite)
        {
            if(GameController.gamecontroller.ReturnDistanceTraveled() >= 5)
            {

             
                GameController.cantReceiveCoins = false;
             

                if (GameController.revivesCounter >= GameController.revivesForGame)
                {
                    StartCoroutine(DeathPlayer(false, false, true));
                }
                else
                {

                    GameController.revivesCounter = GameController.revivesForGame;
                    StartCoroutine(DeathPlayer(true, false, false));
                }
            } 
            else
            {

                
                //Si el personaje hizo menos de 5 puntos
                GameController.cantReceiveCoins = true;
                GameController.revivesCounter = GameController.revivesForGame;
                StartCoroutine(DeathPlayer(false, false, false));
            }


            //Si estamos en el modo infinito guardamos
            SaveData();
        }



    }

    public  IEnumerator DeathPlayer(bool watchAD, bool typeGame, bool revive)
    {
        

        //Estadisticas
        GameController.superatedObstacles += GameController.GLOBALsuperatedObstacles;
        PlayerPrefs.SetInt("superatedObstacles", GameController.superatedObstacles);
        GameController.jumpsMaked += GameController.GLOBALjumpsMaked;
        PlayerPrefs.SetInt("jumpsMaked", GameController.jumpsMaked);
        GameController.gamesLosed += 1;
        PlayerPrefs.SetInt("gamesLosed", GameController.gamesLosed);


        //Portales
        subLevelManager.portalIsOnScreen = false;
        subLevelManager.portalWasActivated = 0;



        MusicLevelManager.sharedInstance.audioSource.volume = 0.05f;
        
        

        if (typeGame)
        { GameController.gamecontroller.GameOverLevel(); }
        else
        { /*GameController.gamecontroller.GameOver();*/ }

            yield return new WaitForSeconds(1.5f);

        if (typeGame)
        {
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOver;
            
        }
        else
        {
            
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOverInfinite;
        }


        if (watchAD)
        {
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.WatchAD;
        }
        else if (revive && GameController.revivesCounter >= GameController.revivesForGame)
        {
            if (GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.GameInfinite)
                GameManager_Menu.currentScene = GameManager_Menu.stateForScene.ReviveMenu;
            /* if(GameManager_Menu.currentEachState == GameManager_Menu.eachStateForGame.GameInfinite)
                 GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOverInfinite;
             else
                 GameManager_Menu.currentScene = GameManager_Menu.stateForScene.GameOver;*/
        }


        

        SoundManager.sharedInstance.LoseSound2();
        Destroy(gameObject);

    }

    public void WinLevel()
    {

        GameController.loosedLifesObstacles += GameController.GLOBALloosedLifesObstacles;
        PlayerPrefs.SetInt("loosedLifesObstacles", GameController.loosedLifesObstacles);

        StartCoroutine(WinnerCartel());

        GameController.gStates = GameController.GamingStates.youWin;

        Instantiate(particleWin, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f), Quaternion.identity);
        
              
                //Desbloquear el siguiente nivel   
                AdvanceToNewLevel();

              
               

        
        
    }

   public IEnumerator WinnerCartel()
    {

        var playerAlpha = gameObject.GetComponent<SpriteRenderer>().color;
        playerAlpha.a = 0;
        gameObject.GetComponent<SpriteRenderer>().color = playerAlpha;

        rb2d.bodyType = RigidbodyType2D.Static;
        

        yield return new WaitForSeconds(1.5f);

        //aqui ponemos para duplicar monedas. o en su defecto, el cartel de ganadro
        //
        if(!GameController.PlayedLevels[GameManager_Menu.currentLevelIndex])
        {
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.WatchAD;
        }
        else
            GameManager_Menu.currentScene = GameManager_Menu.stateForScene.YouWin;

        //agregamos las estrellas que ganamos a la variable principal
        PlayedLevel();

        Destroy(gameObject);
    }




    void AdvanceToNewLevel()
    {
        if (GameManager_Menu.currentLevelIndex == GameManager_Menu.levelReached)
        {
            GameManager_Menu.levelReached += 1;
            Manager.sharedInstance.SaveData();
        }
        
    }

    //Funcion para agregar las estrellas a nuestro contador principal
    public void PlayedLevel()
    {
        for (int i = 0; i < GameManager_Menu.levelReached + 1; i++)
        {
          

            //Chequeamos que sea el nivel que estamos jugando y que todavia no lo hayamos pasado 
            if (GameManager_Menu.currentLevelIndex == i && GameController.PlayedLevels[i] == false )
            {
                if (CountingStars <= 0)
                      CountingStars = 1;

                //Marcamos que el nivel se pasó, se gano.
                GameController.PlayedLevels[i] = true;
                GameController.stars += CountingStars;

                GameManager_Menu.CountingReplays[i] += 1;
               // Debug.Log("replays"+GameManager_Menu.CountingReplays[i]);
                GameManager_Menu.playLevelAgain[i, GameManager_Menu.CountingReplays[i]] = true;

                PlayerPrefs.SetInt("CountingReplays" + i, GameManager_Menu.CountingReplays[i]);
                PlayerPrefs.SetInt("playLevelAgain" + i, Convert.ToInt32(GameManager_Menu.playLevelAgain[i, GameManager_Menu.CountingReplays[i]]));


               // Debug.Log("Replays" + GameManager_Menu.CountingReplays[i] + "Mapa ya jugado" + GameManager_Menu.playLevelAgain[i, GameManager_Menu.CountingReplays[i]]);

                PlayerPrefs.SetInt("playedLevels" + i, Convert.ToInt32(GameController.PlayedLevels[i]));

                //CollectCoins();

                Manager.sharedInstance.SaveData();
            }
            else if(GameManager_Menu.currentLevelIndex == i && GameController.PlayedLevels[i] == true)
            {


                switch (GameManager_Menu.CountingStarsPerLevel[i])
                {
                    case 0:
                        break;
                    case 1:
                        switch(CountingStars)
                        {
                            case 1:
                               
                                break;
                            case 2:
                                GameController.stars += CountingStars - 1;
                                Manager.sharedInstance.SaveData();
                                break;
                            case 3:
                                GameController.stars += CountingStars - 1;
                                Manager.sharedInstance.SaveData();
                                break;
                        }
                        break;
                    case 2:
                        switch (CountingStars)
                        {
                            case 1:
                                break;
                            case 2:
                                
                                break;
                            case 3:
                                GameController.stars += CountingStars - 2;
                                Manager.sharedInstance.SaveData();
                                break;
                        }
                        break;

                }
            }
            
        }
        
    }

   


    public void SaveData()
    {
     


        switch (GameManager_Menu.currentMundoIndex)
        {
            case 1:

                //----------------------DISTANCIA LOCAL-----------------------------

                if (GameController.distanciaRecorrida > ModeSelectorControlloer.recordMap)
                {
                    ModeSelectorControlloer.recordMap = GameController.distanciaRecorrida;
                }

                //----------------------DISTANCIA GLOBAL-----------------------------

                if (GameController.distanciaRecorrida > GameController.globalDistanciaRecorrida3)
                {
                    GameController.globalDistanciaRecorrida3 = GameController.distanciaRecorrida;

                    if (GameController.isConnectedToGooglePlayServices)
                    {
                        Social.ReportScore(GameController.globalDistanciaRecorrida3, GPGSIds.leaderboard_los_mejores_jugadores, (succes) =>
                        {
                            if (!succes)
                                Debug.Log("unable to set highscore");
                        });

                    }
                    else
                        Debug.Log("not signed in");

                   
              
                }

                break;
            case 2:

                //----------------------DISTANCIA LOCAL-----------------------------

                if (GameController.distanciaRecorrida1 > ModeSelectorControlloer.recordMap1)
                {
                    ModeSelectorControlloer.recordMap1 = GameController.distanciaRecorrida1;

               
                }

                //----------------------DISTANCIA GLOBAL-----------------------------

                if (GameController.distanciaRecorrida1 > GameController.globalDistanciaRecorrida3)
                {
                    GameController.globalDistanciaRecorrida3 = GameController.distanciaRecorrida1;

                    if (GameController.isConnectedToGooglePlayServices)
                    {
                        Social.ReportScore(GameController.globalDistanciaRecorrida3, GPGSIds.leaderboard_los_mejores_jugadores, (succes) =>
                        {
                            if (!succes)
                             Debug.Log("unable to set highscore");
                        });

                    }
                    else
                        Debug.Log("not signed in");
                }

                break;
            case 3:
                //----------------------DISTANCIA LOCAL-----------------------------

                if (GameController.distanciaRecorrida2 > ModeSelectorControlloer.recordMap2)
                {
                    ModeSelectorControlloer.recordMap2 = GameController.distanciaRecorrida2;
              
                }

                //----------------------DISTANCIA GLOBAL-----------------------------
                if (GameController.distanciaRecorrida2 > GameController.globalDistanciaRecorrida3)
                {
                    GameController.globalDistanciaRecorrida3 = GameController.distanciaRecorrida2;

                    if (GameController.isConnectedToGooglePlayServices)
                    {
                        Social.ReportScore(GameController.globalDistanciaRecorrida3, GPGSIds.leaderboard_los_mejores_jugadores, (succes) =>
                        {
                            if (!succes)
                             Debug.Log("unable to set highscore");
                        });

                    }
                    else
                     Debug.Log("not signed in");

                }

                break;
            case 4:
                //----------------------DISTANCIA LOCAL-----------------------------

                if (GameController.distanciaRecorrida3 > ModeSelectorControlloer.recordMap3)
                {
                    ModeSelectorControlloer.recordMap3 = GameController.distanciaRecorrida3;

                  
                }

                //----------------------DISTANCIA GLOBAL-----------------------------

                if (GameController.distanciaRecorrida3 > GameController.globalDistanciaRecorrida3)
                {
                    GameController.globalDistanciaRecorrida3 = GameController.distanciaRecorrida3;
                    if (GameController.isConnectedToGooglePlayServices)
                    {
                        Social.ReportScore(GameController.globalDistanciaRecorrida3, GPGSIds.leaderboard_los_mejores_jugadores, (succes) =>
                        {
                            if (!succes)
                                Debug.Log("unable to set highscore");
                        });

                    }
                    else
                       Debug.Log("not signed in");
                }

                break;

        }

        Manager.sharedInstance.SaveData();

    }

    public void CollectCoins()
    {

        GameController.coins += GameController.coinsOnPlay;

        GameController.recolectedCoins += GameController.coinsOnPlay;
        PlayerPrefs.SetInt("recolectedCoins", GameController.recolectedCoins);



        GameController.diamonds += GameController.diamondsOnPlay;
        HuevosManager.eggsSavings += GameController.eggsOnPlay;

        GameController.diamondsOnPlay = 0;
        GameController.eggsOnPlay = 0;

        Manager.sharedInstance.SaveData();

    }


    //Transition state

    public void TransitionScenes()
    {
       //Guardar toda la data con la que venimos jugando

       //particulas de transicion

      
        rb2d.bodyType = RigidbodyType2D.Static;

    }

  public void DestroyPlayerTransition()
    {
        Destroy(gameObject);

        GameController.gStates = GameController.GamingStates.transition;
    }





}
