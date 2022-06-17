using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveCards
{

    public static List<bool> regalos = new List<bool>();

    private static int countListSaved;

    public static void SET_giftList(int indice, bool a)
    {
        for (int i = 0; i <= indice; i++)
        {
            regalos.Add(a);
            SaveRegalos(indice);

        }
    }

    private static void ModifyList(int a, bool b)
    {
        regalos[a] = b;
        SaveRegalos(a);
    }
    public static bool GET_giftList(int indice)
    {
        return regalos[indice];
    }

    public static int GET_countList()
    {
       
        return regalos.Count;
    }


    public static void SaveRegalos(int a)
    {
            PlayerPrefs.SetInt("regalos" + a, boolToInt(regalos[a]));
    }

    public static void Load()
    {
        for (int i = 0; i < GameController.giftclass.GET_GiftNumbers(); i++)
        {
            if(GetCountListSaved() != 0)
            {
                regalos.Add(intToBool(PlayerPrefs.GetInt("regalos" + i, 0)));
            }
                //regalos[i] = intToBool(PlayerPrefs.GetInt("regalos" + i, boolToInt(regalos[i])));

        }

        for (int i = 0; i < GameController.giftclass.GET_GiftNumbers(); i++)
        {
           
            if (GET_countList() < GameController.giftclass.GET_GiftNumbers())
            {
                SET_giftList(i, false);

                countListSaved++;
                PlayerPrefs.SetInt("countListSaved", countListSaved);
            }

            GameController.giftclass.SET_List(i, GET_giftList(i));
        }


    }

   
    private static int GetCountListSaved()
    {
        countListSaved = PlayerPrefs.GetInt("countListSaved", 0);

        return countListSaved;
    }

    public static void Save(int index)
    {
            ModifyList((index - 1), true);
            GameController.giftclass.modifyList(index - 1, GET_giftList(index - 1));
    }

    public static  bool intToBool(int a)
    {
        if (a == 0)
        {
            return false;
        }
        else
            return true;
        
    } 

    public static int boolToInt(bool a)
    {
        if(!a)
        {
            return 0;
        }
        else
        return 1;
    }

    //Int to bool
    //Bool to int


   
    /*
    public void Load()
    {
        for (int i = 0; i < GameController.giftclass.GET_GiftNumbers(); i++)
        {
            if (data.GET_countList() < GameController.giftclass.GET_GiftNumbers())
            {
                data.SET_giftList(i, false);
            }
            GameController.giftclass.SET_List(i, data.GET_giftList(i));
        }
    }*/
}
