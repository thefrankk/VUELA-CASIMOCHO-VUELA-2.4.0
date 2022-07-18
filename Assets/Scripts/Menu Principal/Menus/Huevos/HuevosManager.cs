using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

//using System.Collections;
using Random = UnityEngine.Random;
using System;


    public class HuevosManager : MonoBehaviour
    {
        // <>

        public static HuevosManager sharedInstance;
        [SerializeField]
        private Transform tapsPopup;


    //new system
    EggSystemClass eggSystem = new EggSystemClass();
        


        public Text eggCounter;
        public Text eggSavingsText;



        public GameObject eggMovement;


        public Sprite[] eggs;

        public Sprite[] playerImage;
        public Text namePlayerWinner;
        public Text numberPlayerWinner;
        public Text numberOfCollection;
        public Image playerWinnerImage;
        string[] playerWinnerNames;


        public Text playerTypeName;
        string[] playerType;
        public Sprite[] playerBackgroundType;
        public Image PlayerBackgroundTypeImage;
        public Color[] playerNameColor;



        public Image eggObject;
        public GameObject eggObjectAnim;

        //Huevos abiertos in a row
        public static int eggsOpenedInARow = 0;

        /// Egg price  //Savings 

        public static int eggPrice = 10;
        public static int eggsSavings = 1;
        public static int eggsOpenCounter;

        //parts of the album
        public static int from0to49 = 0;
        public static int from49to79 = 0;


        public GameObject egg;
        public GameObject panel;
        public GameObject text;
        public GameObject winner_obj;
        public GameObject Reach100Eggs;

        public static int price = 0;

        //Textos de estados
        public Text StringsStates;
        string BuyMoreEggs;
        string GetMoreCoins;
        string Congratulatios;
        string Congratulations2;


        //Bool de cartas two dimensional 

        bool firstTap = false;
        int firstCount;
        int tapCounter = 0;
        public static int tapCounterNumber = 0;
        int tapsToOpen = 17;
        int i = 0;


        Image spriteIndex;
        Animator animIndex;
        Animator animCartWinner;
        public GameObject cartWinnerAnim;

        #region NOMBRES INDEX

        //CASIMOCHO 0
        //MESSIMOCHO 1
        //CASIFRIEND 2
        //CASIDUERME 3
        //CASIBOXEADOR 4
        //TODOMOCHO 5
        //ZOMBIMOCHO 6
        //CONSTRUCTOR 7
        //AMUNGOCHO 8
        //CASIMIKE 9
        //casimochoEXE 10
        //casirojo 11
        //timbamocho 12
        //trollmocho 13
        //spartamocho 14
        //minimocho 15
        //marinomocho 16
        //chuckymocho 17
        //casiviejo 18
        //casitortufan 19
        //casitor 20
        //casiprincesa 21
        //payamocho 22
        //casirobot 23
        //mayomocho 24
        //casirius 25
        //casictor 26
        //casinix 27
        //casidongo 28
        //supermocho 29
        //batmocno 30
        //ironmocho 31
        //casihulk 32
        //wolmocho 33
        //spidermocho 34
        //mikimocho 35
        //casiesponja 36
        //casisonic 37
        //mochosans 38
        //gokumocho 39
        //vegemocho 40
        //siremocho 41
        //submocho 42
        //casipion 43
        //pikamocho 44
        //marimocho 45
        //casit 46
        //casiangel 47
        //cactumocho 48
        //dracumocho 49
        //casimomia 50
        //casizombie 51
        //
        #endregion


        
        private void Awake()
        {
            sharedInstance = this;
            spriteIndex = eggObject.GetComponent<Image>();
            animIndex = eggObjectAnim.GetComponent<Animator>();
            animCartWinner = cartWinnerAnim.GetComponent<Animator>();
        }
        private void Start()
        {
            playerNameColor = new Color[3];

            playerNameColor[0] = Color.white;
            playerNameColor[1] = Color.white;
            playerNameColor[2] = Color.red;


            playerType = new string[3];

            playerType[0] = "TIPO NORMAL";
            playerType[1] = "TIPO EPICO";
            playerType[2] = "TIPO LEGENDARIO";

            BuyMoreEggs = "Compra mas huevos!";
            GetMoreCoins = "Consigue monedas!";
            Congratulatios = "Enhorabuena!";
            Congratulations2 = "Gran eleccion";


            eggsOpenCounter = PlayerPrefs.GetInt("eggCounter", 0);
            eggsOpenedInARow = PlayerPrefs.GetInt("eggsOpenedInARow", 0);

            from0to49 = PlayerPrefs.GetInt("from0to49", 0);
            from49to79 = PlayerPrefs.GetInt("from49to79", 0);



            Manager.sharedInstance.LoadData();

            playerWinnerNames = new string[113];

            #region // NOMBRES DE  LOS PERSONAJES GANADORES
            playerWinnerNames[0] = "CASIMOCHO";
            playerWinnerNames[1] = "MESSIMOCHO";
            playerWinnerNames[2] = "CASIFRIEND";
            playerWinnerNames[3] = "CASIDUERME";
            playerWinnerNames[4] = "CASIBOXEADOR";
            playerWinnerNames[5] = "TODOMOCHO";
            playerWinnerNames[6] = "ZOMBIMOCHO";
            playerWinnerNames[7] = "CONSTRUCTOR";
            playerWinnerNames[8] = "AMUNGOCHO";
            playerWinnerNames[9] = "PINOMOCHO";
            playerWinnerNames[10] = "CASIBOMBERO";
            playerWinnerNames[11] = "CASIROJO";
            playerWinnerNames[12] = "CASILOCO";
            playerWinnerNames[13] = "CASINOOB";
            playerWinnerNames[14] = "CASIMONO";
            playerWinnerNames[15] = "MINIMOCHO";
            playerWinnerNames[16] = "MARINOMOCHO";
            playerWinnerNames[17] = "CHUKYMOCHO";
            playerWinnerNames[18] = "CASIVIEJO";
            playerWinnerNames[19] = "CASITORTUFAN";
            playerWinnerNames[20] = "CASITOR";
            playerWinnerNames[21] = "CASIPRINCESA";
            playerWinnerNames[22] = "PAYAMOCHO";
            playerWinnerNames[23] = "CASIROBOT";
            playerWinnerNames[24] = "CASICHEF";
            playerWinnerNames[25] = "ESPANTAMOCHO";
            playerWinnerNames[26] = "CASICTOR";
            playerWinnerNames[27] = "WALLYMOCHO";
            playerWinnerNames[28] = "CASIPOBRE";
            playerWinnerNames[29] = "SUPERMOCHO";
            playerWinnerNames[30] = "BATMOCHO";
            playerWinnerNames[31] = "IRONMOCHO";
            playerWinnerNames[32] = "CASIHULK";
            playerWinnerNames[33] = "WOLMOCHO";
            playerWinnerNames[34] = "SPIDERMOCHO";
            playerWinnerNames[35] = "MIKIMOCHO";
            playerWinnerNames[36] = "CASIESPONJA";
            playerWinnerNames[37] = "CASISONIC";

            playerWinnerNames[38] = "MOCHOSANS";
            playerWinnerNames[39] = "GOKUMOCHO";
            playerWinnerNames[40] = "VEGEMOCHO";
            playerWinnerNames[41] = "SIREMOCHO";
            playerWinnerNames[42] = "SUBMOCHO";
            playerWinnerNames[43] = "CASIPION";
            playerWinnerNames[44] = "PIKAMOCHO";
            playerWinnerNames[45] = "MARIMOCHO";

            playerWinnerNames[46] = "CASIT";
            playerWinnerNames[47] = "CASIANGEL";
            playerWinnerNames[48] = "CACTUMOCHO";
            playerWinnerNames[49] = "DRACUMOCHO";
            playerWinnerNames[50] = "CASIMOMIA"; // EPICO
            playerWinnerNames[51] = "CASIZOMBIE";
            playerWinnerNames[52] = "CASIEMPANADA";
            playerWinnerNames[53] = "CASIGORDO";
            playerWinnerNames[54] = "BARMOCHO";
            playerWinnerNames[55] = "BEBEMOCHO";
            playerWinnerNames[56] = "CASIFLOR";
            playerWinnerNames[57] = "ELEGAMOCHO";
            playerWinnerNames[58] = "CASIRAPMOCHO";
            playerWinnerNames[59] = "CASIMAGO";
            playerWinnerNames[60] = "POPOMOCHO";
            playerWinnerNames[61] = "CASIFREDDY";
            playerWinnerNames[62] = "JASONMOCHO";

            playerWinnerNames[63] = "CASIAMOR";
            playerWinnerNames[64] = "CASICREEPER";
            playerWinnerNames[65] = "CASIDR";
            playerWinnerNames[66] = "CASIMORADO";
            playerWinnerNames[67] = "POLIMOCHO";
            playerWinnerNames[68] = "SLENDERMOCHO";
            playerWinnerNames[69] = "TERMINOMOCHO";

            playerWinnerNames[70] = "BAILAMOCHO";
            playerWinnerNames[71] = "PIRULETAMOCHO";
            playerWinnerNames[72] = "CASIENTRENANDO";
            playerWinnerNames[73] = "SUPERMOCHO";
            playerWinnerNames[74] = "CASIDIABLO";
            playerWinnerNames[75] = "RANAMOCHO";

            playerWinnerNames[76] = "HACKERMOCHO";
            playerWinnerNames[77] = "CASICERDO";
            playerWinnerNames[78] = "CAPERUMOCHO";
            playerWinnerNames[79] = "TARZAMOCHO";
            playerWinnerNames[80] = "CALAMARMOCHO"; //LEGENADRIO

            playerWinnerNames[81] = "TIMBAMOCHO";
            playerWinnerNames[82] = "TROLLMOCHO";
            playerWinnerNames[83] = "SPARTAMOCHO";

            playerWinnerNames[84] = "ASTROMOCHO";
            playerWinnerNames[85] = "CASIRIUS";

            playerWinnerNames[86] = "TOXIMOCHO";
            playerWinnerNames[87] = "CASIDONGO";
            playerWinnerNames[88] = "CASIMOCHO.EXE";
            playerWinnerNames[89] = "CASIMIKE";
            playerWinnerNames[90] = "CHAPUMOCHO";
            playerWinnerNames[91] = "CASIALIEN";
            playerWinnerNames[92] = "MAYOMOCHO";

            playerWinnerNames[93] = "ARMAMOCHO";
            playerWinnerNames[94] = "CASINIX";
            playerWinnerNames[95] = "CASILYNA";
            playerWinnerNames[96] = "CASIGOD";
            playerWinnerNames[97] = "PAPAMOCHO";
            playerWinnerNames[98] = "CASILUSION";
            playerWinnerNames[99] = "CASIFUERTE";
            playerWinnerNames[100] = "ANDREMOCHO";
            playerWinnerNames[101] = "CASISOLDADO";
            playerWinnerNames[102] = "GAUCHOMOCHO";
            playerWinnerNames[103] = "MIMOCHO";
            playerWinnerNames[104] = "CASIMOCHOTV";
            playerWinnerNames[105] = "CASINVISIBLE";
            playerWinnerNames[106] = "CASIMILLONARIO";
            playerWinnerNames[107] = "CASILOBO";
            playerWinnerNames[108] = "CASIREY";
            playerWinnerNames[109] = "CAVERMOCHO";
            playerWinnerNames[110] = "HUGGYMOCHO";
            playerWinnerNames[111] = "CASICHINO";
            playerWinnerNames[112] = "MOMMY";

        #endregion


            SendInfoToNewSystem();

            eggSystem.AddCards();


            OpenAllEggs();

        }

        private void Update()
        {
            eggCounter.text = eggsOpenCounter.ToString();
            eggSavingsText.text = eggsSavings.ToString();

        }
        // <>
        //Bring the EGG and the counter:
         public async void OpenAllEggs()
         {
             do 
             {
                 GetEgg();
                 await Task.Delay(400);
                 GetEgg();
                 await Task.Delay(200);
                 BreakEGG();
                 await Task.Delay(200);
                 AcceptEgg();
                 await Task.Delay(200);

             } while (eggsOpenCounter != 1000);
         }

        public void GetEgg()
        {
            if (eggsSavings >= 1)
            {

                if (!firstTap)
                {

                    MenusManager.MenusManagerInstance.BackSound();
                    firstCount = Random.Range(tapsToOpen, 17); //50
                    animIndex.SetBool("closing", false);
                    animIndex.SetBool("opening", true);
                    firstTap = true;
                    eggMovement.SetActive(false);
                }
                else
                {
                   //------data poco relevante y apartado grafico----------//
                    eggsSavings--;
                    Manager.sharedInstance.SaveData();
                    eggMovement.SetActive(true);
                    //Open Panel and EGG;
                    egg.SetActive(true);
                    panel.SetActive(true);
                    text.SetActive(true);

                    eggsOpenedInARow++;
                    PlayerPrefs.SetInt("eggsOpenedInARow", eggsOpenedInARow);
                    //------------------------------------------------------//

                }

            }
            else
            {
                StringsStates.text = BuyMoreEggs.ToString();

            }
        }

        public void BreakEGG() //Romper el huevo y eleccion.
        {
            //data irrelevante y apartado grafico
            animIndex.enabled = false;

            firstCount -= 17;  //--
            tapCounterNumber++;

            GameController.tapsOnEgg += 1;

            Instantiate(tapsPopup, Vector3.zero, Quaternion.identity);

             //--------------------------
            if (firstCount == 0)
            {

                //sonido
                MenusManager.MenusManagerInstance.CrackEggs(2);
                //buttons
                egg.GetComponent<Button>().interactable = false;

                //data irrelevante 
                eggsOpenCounter++;
                PlayerPrefs.SetInt("eggCounter", eggsOpenCounter);
                PlayerPrefs.SetInt("tapsOnEgg", GameController.tapsOnEgg);
                //----------------

                //Deshabilitar el huevo
                firstTap = false;
                text.SetActive(false);

                //Tiramos un random para verificar cual es el numero ganador:
                //RandomizeNumber();

                eggSystem.PickaCard();

                //funcion del objecto ganador
                EggPicker(eggSystem.GET_FirstIndex());


            }
            else
            {
                if (firstCount >= tapsToOpen)
                {


                    if (i == 0)
                    {
                        i = 1;
                    }
                    else if (i == 1)
                    {
                        i = 0;
                    }

                    //  Debug.Log("Quedan " + firstCount + " taps");


                    spriteIndex.sprite = eggs[i];

                }
                else
                {
                    tapCounter++;
                    spriteIndex.sprite = eggs[tapCounter];

                }

            }

        }

        // <>

        int q;
        void EggPicker(int theWinnerNumber)
        {

            if (eggsOpenCounter >= 1018) //1014
            {
                Reached100Eggs();
                return;
            }


                for (int i = 0; i < 9; i++)
                {
//                    Debug.Log(theWinnerNumber + " " + i );

                    PlayerManagerMenus.cart[theWinnerNumber, i] = Convert.ToBoolean(PlayerPrefs.GetInt("cart1" + theWinnerNumber + "carts2" + i, 0));

                    if (!PlayerManagerMenus.cart[theWinnerNumber, i])
                    {
                        PlayerManagerMenus.cart[theWinnerNumber, i] = true;
                        PlayerManagerMenus.playersLocked[(GameController.playersToPlay)theWinnerNumber] = true;

                        PlayerPrefs.SetInt("PlayerLock" + theWinnerNumber, Convert.ToInt32(PlayerManagerMenus.playersLocked[(GameController.playersToPlay)theWinnerNumber]));

                        PlayerPrefs.SetInt("cart1" + theWinnerNumber + "carts2" + i, Convert.ToInt32(PlayerManagerMenus.cart[theWinnerNumber, i] = true)); ;

                        break;
                    }
                }
        

                    //Aparece el huevo ganador:
                    winner_obj.SetActive(true);
                    animCartWinner.SetBool("opening", true);



                    namePlayerWinner.color = playerNameColor[CheckTypeCart(theWinnerNumber)];
                    playerTypeName.text = playerType[CheckTypeCart(theWinnerNumber)];
                    PlayerBackgroundTypeImage.sprite = playerBackgroundType[CheckTypeCart(theWinnerNumber)];

                    playerWinnerImage.sprite = playerImage[theWinnerNumber];
                    namePlayerWinner.text = playerWinnerNames[theWinnerNumber].ToString();
                    numberPlayerWinner.text = theWinnerNumber.ToString();


                    var p = 0;
                    for (int q = 0; q < 9; q++)
                    {
                        PlayerManagerMenus.cart[theWinnerNumber, q] = Convert.ToBoolean(PlayerPrefs.GetInt("cart1" + theWinnerNumber + "carts2" + q, 0));

                        if (PlayerManagerMenus.cart[theWinnerNumber, q] == true)
                        {
                            p++;


                            PlayerManagerMenus.repeatedCarts[theWinnerNumber] = p;
                            PlayerPrefs.SetInt("repeatedCarts" + theWinnerNumber, PlayerManagerMenus.repeatedCarts[theWinnerNumber] = p);

                            numberOfCollection.text = PlayerManagerMenus.repeatedCarts[theWinnerNumber].ToString();
                        }
                    }
                
            
           
        } //Funcion selectora de los huevos






        public void AcceptEgg() //aceptar y reiniciar huevo
        {

            //Publicidad
            if (eggsOpenedInARow >= 350)//6
            {
                ManagerAds.instance.showInterstitialAll();
                eggsOpenedInARow = 0;
                PlayerPrefs.SetInt("eggsOpenedInARow", eggsOpenedInARow);
            }

            MenusManager.MenusManagerInstance.BackSound();
            //Open Panel and EGG;
            egg.SetActive(false);
            panel.SetActive(false);
            text.SetActive(false);

            Reach100Eggs.SetActive(false);

            //apagamos el huevo ganador
            winner_obj.SetActive(false);

            //Volvemos todo a 0

            animIndex.enabled = true;
            tapsToOpen = 17;
            spriteIndex.sprite = eggs[0];
            tapCounter = 0;
            firstCount = 0;
            firstTap = false;
            tapCounterNumber = 0;
            animIndex.SetBool("opening", false);
            animIndex.SetBool("closing", true);


            animCartWinner.SetBool("opening", false);

            egg.GetComponent<Button>().interactable = true;
            StringsStates.text = Congratulatios.ToString();


        }

        //Conseguiste los 100 huevos

        public void Reached100Eggs()
        {

            eggsSavings += 1;
            eggsOpenCounter -= 1;
            Manager.sharedInstance.SaveData();

            Reach100Eggs.SetActive(true);
            panel.SetActive(true);


        }




     /// <summary>
     /// SECTOR DE COMPRA DE HUEVOS 
     /// </summary>
        public void BuyOneEgg()
        {
            if (GameController.diamonds >= eggPrice)
            {
                GameController.diamonds -= eggPrice;
                eggsSavings += 1;



                Manager.sharedInstance.SaveData();

                StringsStates.text = Congratulations2.ToString();
                MenusManager.MenusManagerInstance.BackSound();
            }
            else
            {
                StringsStates.text = GetMoreCoins.ToString();
                MenusManager.MenusManagerInstance.BackSound();
                Debug.Log("Consigue mas monedas!");

            }
        }

        public void BuyTwentyEggs()
        {
            if (GameController.diamonds >= 180)
            {
                MenusManager.MenusManagerInstance.BackSound();
                GameController.diamonds -= 180;


                eggsSavings += 20;


                Manager.sharedInstance.SaveData();
                StringsStates.text = Congratulations2.ToString();
            }
            else
            {
                MenusManager.MenusManagerInstance.BackSound();
                StringsStates.text = GetMoreCoins.ToString();


            }
        }


        public void BuyFiveThousandEggs()
        {
            MenusManager.MenusManagerInstance.BackSound();

            eggsSavings += 1000;

            Manager.sharedInstance.SaveData();
            StringsStates.text = Congratulations2.ToString();
        }

        public void PURCHASEEGGS()
        {
            IAPurchase.instace.BuyEggsConsumable();
        }

<<<<<<< Updated upstream
    
    public void BuyFiveThousandEggs()
    {

        MenusManager.MenusManagerInstance.BackSound();
=======
        public int CheckTypeCart(int cartValue)
        {
            var p = 0;
            // <>
            if (cartValue <= 49)
            {
                //Es tipo comun
                p = 0;

            }
            else if (cartValue >= 50 && cartValue <= 80)
            {
                //tipo epico
                p = 1;
            }
            else
            {
                //tipo legenadrio 
                p = 2;
            }
>>>>>>> Stashed changes



            return p;
        }


        void SendInfoToNewSystem()
        {

            bool checker;
            int[] infoSender = new int[113];

            for (int i = 0; i < infoSender.Length; i++)
            {
                for (int q = 0; q < 9; q++)
                {
                    checker = Convert.ToBoolean(PlayerPrefs.GetInt("cart1" + i + "carts2" + q, 0));

                    if(!checker)
                    {
                         infoSender[i]++;
                    }
                    else
                    {
                         infoSender[i] += 0;
                    }

                }
            }

            eggSystem.Set_oldCards(infoSender);
         }

}

