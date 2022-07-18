using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EggSystemClass
{
    //Definimos la lista de cartas normales
    //Para poder adoptar el mismo algortimo q venimos utilizando, debemos utilizar si o si diccionarios para
    //mantener siempre el mismo index.

    //carta index, cantidad de subcartas
    private Dictionary<int, int> cards = new Dictionary<int, int>();
    private List<int> unlockedCardsNormal = new List<int>();
    private List<int> unlockedCardsMedium = new List<int>();
    private List<int> unlockedCardsHard = new List<int>();

    //cantidad de cartas
    private int normalCardsQuantity = 50;//50 
    private int mediumCardsQuantity = 30;//30
    private int hardCardsQuantity = 33; //33

    private int firstUnlocked { get { if (unlockedCardsNormal.Count >= (normalCardsQuantity)) return 0; else { return 1; }; } }
    private int secondUnlocked { get { if (unlockedCardsMedium.Count >= (mediumCardsQuantity)) return 0; else { return 1; }; } }
    //Dificultad para el azar de las cartas
    private int normalDifficult = 135;//135 //total 150 
    private int mediumDifficult = 10; //10
    private int hardDifficult = 5;


    private int first_Index = 0;
    private int second_Index = 0;

    //Array que va a recibir todos las subcartas disponibles
    private int[] oldCards;
    //Agregamos todas las cartas al diccionario

    public void AddCards()
    {
        for (int i = 0; i < oldCards.Length; i++)
        {
            //if (oldCards[i] != 0)
            cards.Add(i, oldCards[i]);
        }

        for (int i = 0; i < normalCardsQuantity; i++)
        {
            if (cards[i] <= 0)
                unlockedCardsNormal.Add(i);
        }
        for (int i = normalCardsQuantity; i < (normalCardsQuantity + mediumCardsQuantity); i++)
        {
            if (cards[i] <= 0)
                unlockedCardsMedium.Add(i);
        }
        for (int i = (normalCardsQuantity + mediumCardsQuantity); i < (normalCardsQuantity + mediumCardsQuantity + hardCardsQuantity); i++)
        {
            if (cards[i] <= 0)
                unlockedCardsHard.Add(i);
        }
    }

    public void PickaCard()
    {

        Validador();


        int temp = Random.Range(0, 151); //151


        int normal = Random.Range(0, (normalCardsQuantity));
        int medium = Random.Range(normalCardsQuantity, (normalCardsQuantity + mediumCardsQuantity));
        int hard = Random.Range((normalCardsQuantity + mediumCardsQuantity), 113);

        //bad
        if (temp == 0 && firstUnlocked == 0 || secondUnlocked == 0)
            ++temp;

            Debug.Log(temp);
            if (temp <= normalDifficult && firstUnlocked != 0)
            {
                UnlockCard(unlockedCardsNormal, normalCardsQuantity, "NORMAL CARDS", normal, 0);
                  Debug.LogWarning("my bebito fiu fiu putoo");
        
             }
            else if (temp > (normalDifficult * firstUnlocked) && temp <= (mediumDifficult + normalDifficult) && secondUnlocked != 0)
            {
                Debug.Log(normalDifficult + " " + mediumDifficult + " "  + temp);
                Debug.LogWarning("my bebito fiu fiu second");

                UnlockCard(unlockedCardsMedium, mediumCardsQuantity, "MEDIUM CARDS", medium, (50));
            }
            else if(temp > ((normalDifficult * firstUnlocked) + (mediumDifficult * secondUnlocked)) && temp <= 150)
            {
                Debug.LogError("first unlocked");
                Debug.LogWarning("my bebito fiu fiu");
                UnlockCard(unlockedCardsHard, hardCardsQuantity, "HARD CARDS", hard, (50 + 30));
            }


        }


        bool Validador()
        {

            if (unlockedCardsNormal.Count >= normalCardsQuantity + 1 || unlockedCardsMedium.Count >= mediumCardsQuantity + 1 || unlockedCardsHard.Count >= hardCardsQuantity + 1)
            {
                Debug.LogError("ERRORRRRR");
                return true;
            }
            else
                return false;
        }

        void UnlockCard(List<int> listByDifficult, int quantityCards, string typeCard, int randomN, int start)
        {
            int FIRST_INDEX;
            int SECOND_INDEX = 0;

            if (listByDifficult.Count >= quantityCards)
            {
                Debug.LogError("Todas las cartas " + typeCard + " han sido desbloqueadas -- second unklock " + secondUnlocked);
                return;
            }

            Debug.Log("Cartas " + listByDifficult.Count + " otras crtas " + (quantityCards));

            int randomNumber = randomN;

            FIRST_INDEX = randomNumber;

            //Chequeamos si la carta ya fue completamente desbloqueada
            if (cards[FIRST_INDEX] <= 0)
            {
                    Debug.Log(cards[FIRST_INDEX] + " mmm watafak" + " " + FIRST_INDEX);
              
                    for (int i = start; i < (start + quantityCards); i++)
                    {
                        randomNumber = i;

                            if (!listByDifficult.Contains(randomNumber))
                            {

                               Debug.Log(cards[randomNumber] + " mmm watafak " + i);


                                    FIRST_INDEX = randomNumber;
                                    SECOND_INDEX = cards[FIRST_INDEX];
                                    cards[FIRST_INDEX]--;

                                break;
                            }
                          
                    }

            }
            else
            {

                SECOND_INDEX = cards[FIRST_INDEX];
                cards[FIRST_INDEX]--;
            }

            if (cards[FIRST_INDEX] <= 0)
            {
                listByDifficult.Add(FIRST_INDEX);
                 Debug.Log("agregado a la lista " + FIRST_INDEX);
            }


            first_Index = FIRST_INDEX;
            second_Index = SECOND_INDEX;

            Debug.Log(typeCard + " " + "el numero de carta desbloqueado es " + FIRST_INDEX);
            Debug.Log("Aun quedan para desbloquear " + cards[FIRST_INDEX] + " sub personajes");

            if (listByDifficult.Count >= quantityCards)
            {
                Debug.Log("Todas las cartas " + typeCard + " han sido desbloqueadas -- second unklock " + secondUnlocked);

            }

        }

        public void Set_oldCards(int[] cards)
        {
             this.oldCards = cards;
        }

        public int GET_FirstIndex()
        {
            return first_Index;
        }

        public int GET_SecondIndex()
        {
            return second_Index;
        }


        public void GET_Quantitys()
        {
            Debug.Log(unlockedCardsNormal.Count + " cartas normales nmero de desbloqueadas");
            Debug.Log(unlockedCardsMedium.Count + " cartas medium nmero de desbloqueadas");
            Debug.Log(unlockedCardsHard.Count + " cartas hard nmero de desbloqueadas");


            Debug.Log(normalDifficult + " dificultad normal");
            Debug.Log(mediumDifficult + " dificultad medium ");
            Debug.Log(hardDifficult + " dificultad hard");
        }
    }
