using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class subLevelManager : MonoBehaviour
{

    [Header("Objects")]
    public GameObject greenPortal;
    public GameObject redPortal;
    private GameObject prefabToBuild;
    private GameObject portalPrefab;


    [Header("CurrentLevel")]
    [SerializeField]
    public GameController.WorldsAndsLevels levels;
    [Header("isSublevel or level?")]
    [SerializeField]
    public GameController.typesOfLevels typeLevel;

    public string nextLevel;
    private string[] subAndLevels;

    float maxTime = 10f; //10f
    float time = 0f;

    int a;
    int b;
    int c;
    int d;
    int e;
    int f;


    [HideInInspector]
    public static bool portalIsOnScreen;


    public static int portalWasActivated;

    public static subLevelManager instance;
    // <>

    // Start is called before the first frame update
    void Start()
    {
        nextLevelsString();

        SetNames();
        //Set();

        RandomNumbers();

        instance = this;
    }

    public async void Set()
    {
        await Task.Delay(2);
        SetNames();
    }

    private void SetNames()
    {
        GameController.gamecontroller.currentLevelInfinite = levels;
        GameController.gamecontroller.levelType = typeLevel;

    }

    private void nextLevelsString()
    {
        subAndLevels = new string[6];

        subAndLevels[0] = "Game_subNivel1";
        subAndLevels[1] = "Game_nivel2";
        subAndLevels[2] = "Game_subNivel2";
        subAndLevels[3] = "Game_nivel3";
        subAndLevels[4] = "Game_SubNivel3";
        subAndLevels[5] = "Game_nivel4";
    }

    // Update is called once per frame
    void Update()
    {

       // Debug.Log("leveltype" + GameController.gamecontroller.levelType);


        if (GameManager_Menu.guiOneTAP)
            return;

        if ( time > maxTime )
        {

            if (portalWasActivated < 4)
            {
                DetectWordAndLevel();
            }
           

            time = 0;
        }

        time += Time.deltaTime;


    }


    public void CreatePortal()
    {

        var x = 20f;
        var y = Random.Range(-4, 3);
        var z = 14f;

        portalPrefab = (GameObject)Instantiate(PrefabToBuild());
        portalPrefab.transform.position = new Vector3(transform.position.x, y, z);

        if(GameController.gamecontroller.levelType == GameController.typesOfLevels.subLevel)
        {
            portalPrefab.transform.localScale = new Vector3(4.83f, 4.09f, 1);
            portalPrefab.transform.position = new Vector3(transform.position.x, -0.14f, z);
        }
        


        portalIsOnScreen = true;

        portalWasActivated += 1;

        for (int i = 0; i < portalWasActivated; i++)
        {
            maxTime += 10;
        }
        

        StartCoroutine(DespawnObject(portalPrefab));
    }


    IEnumerator DespawnObject(GameObject go)
    {
        yield return new WaitForSeconds(10f);

        portalIsOnScreen = false;
        Destroy(go);
    }

   void RandomNumbers()
    {
        a = Random.Range(45, 50); //nivel 1  30 - 50
        b = Random.Range(49, 55); //sub 1 60 - 65 
        c = Random.Range(75, 95); //n 2 85 - 105
        d = Random.Range(94, 115); //s 2 110 - 120  
        e = Random.Range(138, 155);//n 3 135 - 145
        f = Random.Range(155, 167); // s 3 160 - 175

    }

 
        void DetectWordAndLevel()
    {

        if (GameController.portal_word[0] != 1 && portalWasActivated >= 1)
            return;

        if (portalIsOnScreen)
            return;

        switch (GameController.CurrentInfiniteWorld)
        {
            case GameController.Worlds.World1:

                switch (GameController.gamecontroller.currentLevelInfinite)
                {
                    case GameController.WorldsAndsLevels.World1Level1:

                        nextLevel = subAndLevels[0];

                            if (GameController.distanciaRecorrida >= a)
                        {
                            if(portalWasActivated < 20)
                            {
                                CreatePortal();
                            }
                            
                        }                      

                        break;

                    case GameController.WorldsAndsLevels.World1SubLevel1:

                            nextLevel = subAndLevels[1];


                            if (GameController.distanciaRecorrida >= b)
                        {
                            CreatePortal();
                        }

                        break;

                    case GameController.WorldsAndsLevels.World1Level2:

                            nextLevel = subAndLevels[2];


                            if (GameController.distanciaRecorrida >= c)
                        {
                            if (portalWasActivated < 20)
                            {
                                CreatePortal();
                            }

                        }

                        break;

                    case GameController.WorldsAndsLevels.World1SubLevel2:

                            nextLevel = subAndLevels[3];

                            if (GameController.distanciaRecorrida >= d)
                        {
                            CreatePortal();
                        }


                        break;

                    case GameController.WorldsAndsLevels.World1Level3:

                            nextLevel = subAndLevels[4];

                            if (GameController.distanciaRecorrida >= e)
                        {
                            if (portalWasActivated < 20)
                            {
                                CreatePortal();
                            }

                        }

                        break;

                    case GameController.WorldsAndsLevels.World1Sublevel3:

                            nextLevel = subAndLevels[5];

                            if (GameController.distanciaRecorrida >= f)
                        {
                            CreatePortal();
                        }

                        break;
                    case GameController.WorldsAndsLevels.World1Level4:

                        GameController.gamecontroller.levelType = GameController.typesOfLevels.level;


                        break;
                }

                break;
        }

    }

   


    GameObject PrefabToBuild()
    {

        if (GameController.portal_word[0] == 1)
        {
            prefabToBuild = greenPortal;
        }
        else
        {
            prefabToBuild = redPortal;
        }


        return prefabToBuild;
    }

}