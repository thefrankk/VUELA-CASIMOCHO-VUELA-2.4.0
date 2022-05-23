using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class subPortal : MonoBehaviour
{

    // <>
    //Speed
    

    public Player player;

    [Header("NextLevel")]
    public string[] levels;
    [SerializeField]
    string nextLevel;

    private bool onTransition;
    private float counter = 0;


   
    void Start()
    {
        player = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement 
        if (GameManager_Menu.guiOneTAP)
            return;

        transform.position += Vector3.left * ObjectINFINITE_logic.speedObjects * Time.deltaTime;

        if(onTransition)
        {
           
            if (counter > 1.0f)
            {
                Loader(subLevelManager.instance.nextLevel);

               

               
                    if (GameController.gamecontroller.levelType == GameController.typesOfLevels.level)
                    {
                        GameController.playerHabs = GameController.CheckHabilitiesPlayer.withHabilities;
                    }
                    else
                    {
                        GameController.playerHabs = GameController.CheckHabilitiesPlayer.outHabilities;
                    }

                    GameManager_Menu.guiOneTAP = true;
                    GameController.gStates = GameController.GamingStates.pendingAlive;

                    counter = 0;
                    onTransition = false;
              
            }
            
            counter += Time.deltaTime;

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (GameController.portal_word[(long)GameController.CurrentInfiniteWorld] != 1)
                return;

            if (GameController.gStates == GameController.GamingStates.youLoose)
                return;

                player.TransitionScenes();



            SoundManager.sharedInstance.PortalEnter();

            //Cambiamos el stado del personaje a transicion
            GameController.gStates = GameController.GamingStates.dead;


            //desactivamos el portal||11
            subLevelManager.portalIsOnScreen = false;
            subLevelManager.portalWasActivated = 0;
            GameController.gamecontroller.playerJetPack = false;



            //avanzar al siguiente nivel
            //StartCoroutine(TransitionNextLevel(subLevelManager.instance.nextLevel));
            // Loader(subLevelManager.instance.nextLevel);
            GameController.gamecontroller.GetParameters();
            onTransition = true;
        }
    }

   private void Loader(string nextLevel)
    {
       
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);

        GameController.gamecontroller.TransicionLevels();

    }
       public IEnumerator TransitionNextLevel(string nextlevel)
        {
            //guardamos configuraciones
            GameController.gamecontroller.GetParameters();

        Debug.Log("Hola me ejecutire primero en la coruotuines");
            yield return new WaitForSeconds(.1f);


        Debug.Log("Hola me ejecutire seguundo en la coruotuines");
        //avanzar al siguiente nivel
        SceneManager.LoadScene(nextlevel, LoadSceneMode.Single);

            GameController.gamecontroller.TransicionLevels();
            

           new WaitForSeconds(0.5f);

        Debug.Log("Hola me ejecutire tercero en la coruotuines");

        if (GameController.gamecontroller.levelType == GameController.typesOfLevels.level)
                {
                    GameController.playerHabs = GameController.CheckHabilitiesPlayer.withHabilities;
                }
                else
                {
                    GameController.playerHabs = GameController.CheckHabilitiesPlayer.outHabilities;
                }

                GameManager_Menu.guiOneTAP = true;
                GameController.gStates = GameController.GamingStates.pendingAlive;
        }

    
      

}