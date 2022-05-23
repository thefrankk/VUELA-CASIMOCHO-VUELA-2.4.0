using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDiamondsFree : MonoBehaviour
{

    public void GetCoins()
    {
        GameController.coins += 100;
        Manager.sharedInstance.SaveData();
    }
    public void GetDiamonds()
    {
        GameController.diamonds += 100;
        Manager.sharedInstance.SaveData();
    }
}
