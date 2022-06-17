using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giftClass
{

    //Sector regalos mensuales, por cada variable activada, quiere decir que el jugador ya recibio su regalo
    private List<bool> gifts = new List<bool>();
    private List<int> giftsID = new List<int>();

    private int giftNumbers;
    private static bool avaliableGifts = false;



    public giftClass(int giftNumbers)
    {
        this.giftNumbers = giftNumbers;

        for (int i = 0; i < giftNumbers; i++)
        {

        }

    }

    public void checkGifts()
    {
        // Debug.Log("check avaliabilty" + gifts[0] + gifts.Count);
        avaliableGifts = false;

        for (int i = 0; i < gifts.Count; i++)
        {
            if(avaliableGifts != true)
            {
                avaliableGifts = false;
            }
                        
            if (gifts[i] == true)
                return;

            avaliableGifts = true;
            //DisplayGift(); unlock gift(); encender animacion de que hay un regalo disponible..
        }
    }

    public int GET_giftId() => giftsID[0];


    public int GET_GiftCount() => gifts.Count - 1;


    public int GET_GiftNumbers() => giftNumbers;


    public void SET_List(int indice, bool a)
    {
        for (int i = 0; i <= indice; i++)
        {
            gifts.Add(a);
        }
    }

    public bool GET_List(int indice)
    {

        return gifts[indice];
    }

    public void modifyList(int indice, bool a)
    {
        gifts[indice] = a;
    }

    public static bool CheckAvaliableGifts()
    { 
      
        
        return avaliableGifts;
    }
   
}
