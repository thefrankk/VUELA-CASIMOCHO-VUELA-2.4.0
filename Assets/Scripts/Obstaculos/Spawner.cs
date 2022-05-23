using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Tiempo que demora en aparecer el obstaculo
    public static float maxTime = 1.50f;
    float timer = 0f;
    public GameObject obstacle;
    //Distancia en Y para que aparezca random.
    
   public static Spawner spawnerInstance;
    

    [SerializeField]
    public GameObject Obstaculo;
    // Start is called before the first frame update
    void Start()
    {
        spawnerInstance = this;
        ObjectPooling.PreLoad(Obstaculo, 15);


        
    }

    // Update is called once per frame
    void Update()
    {

       if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameOver)
        {
            if (!GameManager_Menu.guiOneTAP)
            {

                if (subLevelManager.portalIsOnScreen)
                    return;

                switch(GameManager_Menu.currentMundoIndex)
                {
                    case 1:
                        var alto = 3.8f;
                        var bajo = -3.7f;

                        if (timer >= maxTime)
                        {
                            GameObject c = ObjectPooling.GetObject(Obstaculo);
                            c.transform.position = transform.position + new Vector3(0, Random.Range(bajo, alto), -5f);
                            timer = 0;
                            StartCoroutine(DeSpawn(Obstaculo, c, 10f));

                        }

                        timer += Time.deltaTime;

                        break;
                    case 2:
                         alto = 3.5f;
                         bajo = -3.5f;

                        if (timer >= maxTime)
                        {
                            GameObject c = ObjectPooling.GetObject(Obstaculo);
                            c.transform.position = transform.position + new Vector3(0, Random.Range(alto, bajo), -5f);
                            timer = 0;
                            StartCoroutine(DeSpawn(Obstaculo, c, 10f));

                        }

                        timer += Time.deltaTime;

                        break;

                    case 3:
                        alto = 4.55f;
                        bajo = -3.3f;

                        if (timer >= maxTime)
                        {
                            GameObject c = ObjectPooling.GetObject(Obstaculo);
                            c.transform.position = transform.position + new Vector3(0, Random.Range(alto, bajo), -5f);
                            timer = 0;
                            StartCoroutine(DeSpawn(Obstaculo, c, 10f));

                        }

                        timer += Time.deltaTime;

                        break;

                    case 4:
                        alto = 4.70f;
                        bajo = -3.83f;

                        if (timer >= maxTime)
                        {
                            GameObject c = ObjectPooling.GetObject(Obstaculo);
                            c.transform.position = transform.position + new Vector3(0, Random.Range(alto, bajo), -5f);
                            timer = 0;
                            StartCoroutine(DeSpawn(Obstaculo, c, 10f));

                        }

                        timer += Time.deltaTime;

                        break;



                }
                    
            }
        }   

    }

    IEnumerator DeSpawn(GameObject primitive, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPooling.RecicleObject(primitive, go);
    }
}


