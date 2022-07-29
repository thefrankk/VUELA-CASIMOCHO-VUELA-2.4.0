using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisRecords : MonoBehaviour
{

    public Text[] recordsText;
    private int[] recordsInt;

    


    // Start is called before the first frame update
    void Start()
    {
        recordsInt = new int[4];
        recordsInt[0] = GameController.globalDistanciaRecorrida;
        recordsInt[1] = GameController.globalDistanciaRecorrida1;
        recordsInt[2] = GameController.globalDistanciaRecorrida2;
        recordsInt[3] = GameController.globalDistanciaRecorrida3;
        recordsInt[4] = GameController.globalDistanciaRecorrida4;



    }

    // Update is called once per frame
    void Update()
    {
        recordsText[0].text = recordsInt[0].ToString();
        recordsText[1].text = recordsInt[1].ToString();
        recordsText[2].text = recordsInt[2].ToString();
        recordsText[3].text = recordsInt[3].ToString();
        recordsText[4].text = recordsInt[4].ToString();


    }


   
}
