using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerType2 : MonoBehaviour
{
     //Tiempo que demora en aparecer el obstaculo
    public float maxTime = .9f; 
    float timer = 0f;

    private float maxTimeMarker = 1.5f;
    float timerMarker = 0f;
    
    
    
   public static SpawnerType2 spawnerInstance;
    

    [SerializeField]
    public GameObject Obstaculo;
    public GameObject distanceMarker;

    public bool isSpace;
    //public GameObject[] meteors;



    //private GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnerInstance = this;

        Debug.Log("Loading obstacles..");
        ObjectPooling.PreLoad(distanceMarker, 3);
        ObjectPooling.PreLoad(Obstaculo, 25);
        /* if (isSpace)
         {
             ObjectPooling.PreLoad(meteors[0], 5);
             ObjectPooling.PreLoad(meteors[1], 5);
             ObjectPooling.PreLoad(meteors[2], 5);
             ObjectPooling.PreLoad(meteors[3], 5);
             ObjectPooling.PreLoad(meteors[4], 5);
         }*/




    }


    private void Update()
    {
        if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameOver)
        {
            if (GameManager_Menu.guiOneTAP)
                return;

            if (subLevelManager.portalIsOnScreen)
                return;

            var alto = 5.5f;
            var bajo = -5.5f;

            //GameController.gamecontroller.currentLevelInfinite = GameController.WorldsAndsLevels.World1Level1
            if(GameController.gamecontroller.currentLevelInfinite == GameController.WorldsAndsLevels.World1Level3)
            {

                if (timer >= maxTime)
                {


                    GameObject prefab = ObjectPooling.GetObject(Obstaculo);


                    prefab.transform.position = transform.position + new Vector3(0, Random.Range(bajo, alto), -5f);
                    timer = 0;
                    StartCoroutine(DeSpawn(Obstaculo, prefab, 10f));

                }

            }

            if (timerMarker >= maxTimeMarker)
            {

                GameObject t = ObjectPooling.GetObject(distanceMarker);
                t.transform.position = transform.position + new Vector3(0, 0, -5f);
                timerMarker = 0;
                StartCoroutine(DeSpawn(distanceMarker, t, 5f));

            }

            timer += Time.deltaTime;
            timerMarker += Time.deltaTime;

        }
    }

  

    IEnumerator DeSpawn(GameObject primitive, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPooling.RecicleObject(primitive, go);
    }

}
