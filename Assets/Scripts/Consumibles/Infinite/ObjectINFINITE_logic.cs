using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectINFINITE_logic : MonoBehaviour
{

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip coinPick;

    public static float speedObjects = 3f;
    SpriteRenderer rend;


    
    // <>
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movement 
        if (!GameManager_Menu.guiOneTAP)
        {
            transform.position += Vector3.left * speedObjects * Time.deltaTime;
        }




    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (Options.sound)
            {


            }


            switch (gameObject.tag)
            {
                case "diamondsInfinite":

                    GameController.diamondsOnPlay += 1;
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;



                    break;
                case "LifesInfinite":

                    Player.vidas += 1;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;



                    break;

                case "HuevosInfinite":

                    GameController.eggsOnPlay += 1;
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

                    break;

            }

            //Opacamos el color de la moneda
            rend.color = new Color(1f, 1, 1f, 0.5f);
            //Invocamos la funcion para volver todo a la normalidad a los 5s
            Invoke("BackToState", 5f);
        }



        if (collision.tag == "Obstaculos_palos")
        {

            switch (gameObject.tag)
            {
                case "diamondsInfinite":

                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;



                    break;
                case "LifesInfinite":

                    gameObject.GetComponent<CircleCollider2D>().enabled = false;



                    break;

                case "HuevosInfinite":

                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

                    break;

            }

            gameObject.SetActive(false);
            rend.color = new Color(1f, 1f, 1f, 0f);
            Invoke("BackToState", 10f);


        }


    }

    void BackToState()
    {
        switch (gameObject.tag)
        {
            case "diamondsInfinite":

                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;



                break;
            case "LifesInfinite":

                gameObject.GetComponent<CircleCollider2D>().enabled = true;



                break;

            case "HuevosInfinite":

                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

                break;

        }
        gameObject.SetActive(true);
        rend.color = new Color(1f, 1, 1f, 255f);

    }

}
