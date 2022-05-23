using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator_INFINITE : MonoBehaviour
{

    //Maximo de altura donde puede aparecer
    float alto = 5f;
    float bajo = 5.5f;
    float horizontal = 1f;
    //Tiempo 
    float time = 0f;
    //Tiempo maximo de demora en aparicion
    public static float maxTime = 10f;

    //Numeros que vamos a utilizar para los randomrange de cada uno de los niveles
    int value;
   

    [SerializeField]
    public GameObject[] objects;
    // <>
    // Start is called before the first frame update
    void Start()
    {

        ObjectPooling.PreLoad(objects[0], 10); // lifes
        ObjectPooling.PreLoad(objects[1], 10); // diamonds
        ObjectPooling.PreLoad(objects[2], 10); // huevos



        switch (GameManager_Menu.currentMundoIndex)
        {
            case 1:
                maxTime = 30f;
                 value = 49;
                break;
            case 2:
                maxTime = 26f;
                 value = 59;
                break;
            case 3:
                maxTime = 23f;
                value = 70;
                break;
            case 4:
                maxTime = 20f;
                value = 90;
                break;

        }



    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameOver)
        {
            if (!GameManager_Menu.guiOneTAP)
            {
                if (time > maxTime)
                {
                    var p = Random.Range(0, 100);
                    var n = 0;
                    if (p <= 60)
                    {
                        n = 0;
                    }
                    else if (p >= 60 && p <= 85)
                    {
                        n = 1;
                    }
                    else
                        n = 2;

                    if(GameController.distanciaRecorrida >= 45 || GameController.distanciaRecorrida1 >= 55 || GameController.distanciaRecorrida2 >= 40 || GameController.distanciaRecorrida3 >= 45)
                    {
                        switch (GameManager_Menu.currentMundoIndex)
                        {
                            case 1:
                                //Aparicion de vidas
                                CreateObject(0, value);
                                break;
                            case 2:
                                var t = Random.Range(0, 2);
                                //Aparicion de vidas y dmianates
                                CreateObject(t, value);
                                break;
                            case 3:
                                //Aparicion de todos los objetos
                                CreateObject(n, value);
                                break;
                            case 4:
                                //Aparicion de todos los objetos
                                CreateObject(n, value);
                                break;

                        }
                    }

                            

                    
                   
                }

                time += Time.deltaTime;
            }

        }
    }

    IEnumerator DeSpawn(GameObject primitive, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPooling.RecicleObject(primitive, go);
    }


    public void CreateObject(int d, int value)
    {
        //Debug.Log("CREATE OBJECT");
        var t = Random.Range(0, 120);
        
        if(t <= value)
        {
            GameObject c = ObjectPooling.GetObject(objects[d]);
            c.transform.position = new Vector3(transform.position.x + Random.Range(-horizontal, horizontal), Random.Range(alto, -bajo), -5f);
            time = 0f;

            StartCoroutine(DeSpawn(objects[d], c, 10f));
        }
        else
        {
            time = 0f;
           //Debug.Log("no hay objeto para tirar");
        }
           

       
    }

}
