using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJetpack : MonoBehaviour
{
    private Rigidbody2D rb2d;
    
    private Transform transform;
    private Animator animator;
    private Player player;
    private Sprite sp;
    private float rotationPlayer;
    float t;
    float n;

    public GameObject navePrefab;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip jumpSound;

    //Prefab jump particles
    private GameObject particleJump;
    private GameObject particleJump2;

    //Speeds ups and d
    private float speedUp = 9f; //7
    private float speedDown = 9f;//77

    private float rPropulsionU = GameController.rocketPropulsionU;
    private float rPropulsionD = GameController.rocketPropulsionD;

    //<>

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sp = GetComponent<Sprite>();
        player = GetComponent<Player>();

        

    }
    private void Start()
    {
        Debug.Log("the space ship are deactivated");
        Debug.Log("Player jetpack status" + GameController.gamecontroller.playerJetPack);


        if (GameController.gamecontroller.playerJetPack != true)
            return;
        Debug.Log("Creating the space ship");

        rPropulsionU = GameController.rocketPropulsionU;
        rPropulsionD = GameController.rocketPropulsionD;


        var nave = (GameObject)Instantiate(navePrefab, player.transform);
        nave.transform.localRotation = Quaternion.Euler(0, 0, -40);
        nave.transform.localScale = new Vector3(1f, 1f, 1f);
        nave.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.25f, gameObject.transform.position.z + -0.40f);
        particleJump = nave.transform.GetChild(0).gameObject;
        particleJump2 = nave.transform.GetChild(1).gameObject;

        StartCoroutine(test());


    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(0.3f);
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameController.gamecontroller.playerJetPack != true)
            return;

       


        if (GameController.gStates != GameController.GamingStates.alive)
            return;

      

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            if (mousePosition.y < Screen.height / 1.2)
            {

                if (GameManager_Menu.guiOneTAP)
                {
                    rb2d.bodyType = RigidbodyType2D.Dynamic;
                    GameManager_Menu.guiOneTAP = false;
                }

              
                particleJump.SetActive(true);
                particleJump2.SetActive(false);

                rb2d.AddForce(new Vector2(0, 1f) * rPropulsionU, ForceMode2D.Force);

                n = 0f;
                t += 2f * Time.deltaTime;

                rb2d.velocity = new Vector2(0, Mathf.Clamp(0, Mathf.Lerp(0, rPropulsionU, t), 100f));
            }

        }
        else 
        {
            if(!GameManager_Menu.guiOneTAP)
            {
                t = 0f;
                n -= 2f * -Time.deltaTime;

               particleJump.SetActive(false);
                particleJump2.SetActive(true);

                rb2d.AddForce(new Vector2(0, -1f) * rPropulsionD, ForceMode2D.Force);

                rb2d.velocity = new Vector2(0, Mathf.Clamp(rb2d.velocity.y, Mathf.Lerp(0, -rPropulsionD, n), 100f));

               
            }
            


        }

     
    }



}
