using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsLevel_logic : MonoBehaviour
{
    public static float speedObjects = 3f;
    SpriteRenderer rend; public bool levelPlayed;

    [Header("Make the object movement in X axis")]
    public bool isMoving;
    public int speedMoving;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip coinPick;
    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<SpriteRenderer>();
        for (int i = 0; i < GameController.PlayedLevels.Length; i++)
        {
            if (GameManager_Menu.currentLevelIndex == i)
            {
                if (GameController.PlayedLevels[i] == true)
                {
                    levelPlayed = true;
                    rend.color = new Color(1f, 1f, 1f, 0.5f);
                }
            }
        }
    }


    private void Update()
    {
        if (!GameManager_Menu.guiOneTAP)
        {
            if (!isMoving)
                return;

            transform.position += Vector3.left * speedMoving * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (!levelPlayed)
            {

                if (Options.sound)
                {

                    audioSource.PlayOneShot(coinPick);
                }


                switch(gameObject.tag)
                {
                    case "diamondsLevel":

                        GameController.diamondsOnPlay += 1;
                        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                       
                       

                        break;
                    case "LifesLevel":

                        Player.vidas += 1;
                        gameObject.GetComponent<CircleCollider2D>().enabled = false;
                       


                        break;

                    case "HuevosLevel":

                        GameController.eggsOnPlay += 1;
                        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                      
                        break;

                }

                //Opacamos el color del objeto
                rend.color = new Color(1f, 1f, 1f, 0.5f);
            }

        }

    }



}
