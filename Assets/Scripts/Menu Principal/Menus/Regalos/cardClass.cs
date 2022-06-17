using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cardClass
{
   
    private string[] playerName = {"MOMMY", "Proximamente"};
    private string playerType = "TIPO LEGENDARIO";

    public cardClass()
    {

    }


    public string getPlayerType() => playerType;

    public string getPlayerName(int i) => playerName[i];
   
    



}
