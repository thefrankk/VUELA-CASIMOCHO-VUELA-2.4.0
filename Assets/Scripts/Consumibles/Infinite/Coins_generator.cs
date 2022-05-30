using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Coins_generator : MonoBehaviour
{

    /// <summary>
    /// APARICION DE MONEDAS DENTRO DEL MODO INFINITO
    /// </summary>


    //Maximo de altura donde puede aparecer
    float alto = 5f;
    float bajo = 5.5f;
    float horizontal = 1f;
    //Tiempo 
    float time = 0f;
    float qr = 3;
    float altura = 0f;
    int alturaVariable = 0;
    int objectPosition;
    bool isSpawning = false; 
    //Tiempo maximo de demora en aparicion

    public static float maxTime = 1f;

    //test
   
    [SerializeField]
    public GameObject coin;

    //public GameObject[] gameObjetToPooling;

    public List<GameObject> gameObjectPooling = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        switch (GameManager_Menu.currentMundoIndex)
        {
            case 1:
                maxTime = 0.3f; //0.3 //1f;
               
                break;
            case 2:
                maxTime = .25f;//0.32 //0.33 // 0.9f;
               
                break;
            case 3:
                maxTime = .20f;//0.29 // 0.85f;
                
                break;
            case 4:
                maxTime = .15f;////0.26 //0.75f;
               
                break;

        }

        ObjectPooling.PreLoad(coin, 100);


        
    }

  
    // Update is called once per frame
    void Update()
    {
        if (subLevelManager.portalIsOnScreen)
            return;

        


        //Spawner.spawnerInstance.Obstaculo.transform.position = new Vector2(10f, 10f);

        if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameOver)
            {
                if (!GameManager_Menu.guiOneTAP)
                {

                  

                        if (GameController.gamecontroller.levelType == GameController.typesOfLevels.subLevel)
                        {
                            

                                if (qr >= 1.8f)
                                {
                                    var t = Random.Range(0, 21);

                                        if (t >= 0 && t <= 4)
                                        {
                                            altura = 3;
                                        }
                                        else if (t > 4 && t <= 8)
                                        {
                                            altura = 1;
                                        }
                                        else if (t > 8 && t <= 12)
                                        {
                                            altura = -1;
                                        }
                                        else if (t > 12 && t <= 16)
                                        {
                                            altura = -3;
                                        }
                                        else if (t > 16 && t <= 20)
                                        {
                                            var x = Random.Range(0, 101);
                                            if (x >= 50)
                                            {
                                                altura = -5;
                                            }
                                            else
                                            {
                                                altura = 5;
                                            }

                                        }
                                qr = 0;
                                }

                                qr += Time.deltaTime;

                           
                                if (time > maxTime)
                                {                             
                                            
                                        switch(GameController.gamecontroller.currentLevelInfinite)
                                        {
                                            case GameController.WorldsAndsLevels.World1SubLevel1:
                                                 SpawnCoins(2, 50);
                                                break;
                                            case GameController.WorldsAndsLevels.World1SubLevel2:
                                                 SpawnCoins(3, 50);
                                                break;
                                            case GameController.WorldsAndsLevels.World1Sublevel3:
                                                  SpawnCoins(5, 100);
                                                break;

                                        }   

                                    time = 0f;


                                }

                            
                                 time += Time.deltaTime;
                        }   
                        else
                        {
                            if (time > maxTime)
                            {

                                GameObject c = ObjectPooling.GetObject(coin);
                                c.transform.position = new Vector3(transform.position.x, Random.Range(alto, -bajo), -5f);
                                time = 0f;

                                StartCoroutine(DeSpawn(coin, c, 5f));
                            }

                            time += Time.deltaTime;
                        }

                        
                }

            }
        
      
    }

  

    


    private void SpawnCoins(int a, int objectsMaxToSpawn)
    {

        do
        {

            gameObjectPooling.Add(ObjectPooling.GetObject(coin));
            gameObjectPooling[objectPosition].transform.position = new Vector3(transform.position.x + Random.Range(-horizontal, horizontal), (altura + alturaVariable), -5f);


            StartCoroutine(DeSpawn(coin, gameObjectPooling[objectPosition], 4f));

            ++objectPosition;
            if(a > 3)
            {
                alturaVariable += 3;
            }
            else
                ++alturaVariable;

            --a;
        }
        while (a != 0);

        alturaVariable = 0;
        if(objectPosition > objectsMaxToSpawn)
        {
            objectPosition = 0;
        }


    }


    IEnumerator DeSpawn(GameObject primitive, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPooling.RecicleObject(primitive, go);
    }
}
