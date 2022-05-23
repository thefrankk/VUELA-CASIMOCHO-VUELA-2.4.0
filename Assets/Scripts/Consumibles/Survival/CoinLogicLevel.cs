using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogicLevel : MonoBehaviour
{
 
    public static float speedCoins = 3f;
    SpriteRenderer rend;

    public bool levelPlayed;


    [Header("Make the object movement in X axis")]
    public bool isMoving;
    public int speedMoving;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip coinPick;
    //prefab coinpicker
    public Transform coinParticle;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        for (int i = 0; i < GameController.PlayedLevels.Length; i++)
        {
            if(GameManager_Menu.currentLevelIndex == i)
            {
                if(GameController.PlayedLevels[i] == true)
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
            
            if(!levelPlayed)
            {

                if (Options.sound)
                 {
                    
                    audioSource.PlayOneShot(coinPick);
                 }

                
                //Sumamos la moneda a nuestra variable
                GameController.coinsOnPlay++;


                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                

                //Invocamos la funcion para volver todo a la normalidad a los 5s
                Invoke("BackToState", 5f);

                //Opacamos el color de la moneda
                rend.color = new Color(1f, 1f, 1f, 0.5f);
            }
          
        }

    }


    void BackToState()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
       
        rend.color = new Color(1f, 1, 1f, 255f);

    }


}
