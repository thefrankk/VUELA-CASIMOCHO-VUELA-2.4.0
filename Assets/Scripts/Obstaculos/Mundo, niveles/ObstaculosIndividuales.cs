using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculosIndividuales : MonoBehaviour
{
    SpriteRenderer rend;

 
        [Header("Make the object movement in X axis")]
        public bool isMoving;
        public int speedMoving;
   
   
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!GameManager_Menu.guiOneTAP)
        {
            if (!isMoving)
                return;

            transform.position += Vector3.left * speedMoving * Time.deltaTime;
        }

    }

    // <>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "DeactivateObject" )
        {
            if(gameObject.tag == "obstacle_1x")
            {
                gameObject.SetActive(false);
            }
        }


        if (collision.gameObject.tag == "Player")
        {
            if (Player.vidas >= 2)
            {
                if(gameObject.tag == "obstacle_oneHit")
                {
                    Player.vidas = 1;
                    //Reproducimos el sonido
                    SoundManager.sharedInstance.LoseSound();


                    GameController.gamecontroller.GameOverLevel();

                    //Matamos al player, en base a esta variable, se activiaran otros mecanismos.
                    GameController.gStates = GameController.GamingStates.youLoose;
                    
                }

               
                //Reproducimos el sonido 
                SoundManager.sharedInstance.HitSound();
                
                //Cambiamos el trigger
                if(Player.CountingStars >= 1)
                    Player.CountingStars -= 1;

                //Si tiene 1 vida o mas, Cambiamos de color el choque 
                rend.color = Color.red;

                foreach (Collider2D col in GetComponents<BoxCollider2D>())
                {
                    col.enabled = false;
                }

                GameController.GLOBALloosedLifesObstacles += 1;
                
                Player.vidas--;
            }
            else
            {
                if (Player.vidas == 0)
                    return;

                Player.vidas--;

                GameController.GLOBALloosedLifesObstacles += 1;

                GameController.loosedLifesObstacles += GameController.GLOBALloosedLifesObstacles;
                PlayerPrefs.SetInt("loosedLifesObstacles", GameController.loosedLifesObstacles);


                foreach (Collider2D col in GetComponents<BoxCollider2D>())
                {
                    col.enabled = false;
                }


                SoundManager.sharedInstance.HitSound();

                GameController.gamecontroller.GameOverLevel();

                //Matamos al player, en base a esta variable, se activiaran otros mecanismos.
                GameController.gStates = GameController.GamingStates.youLoose;

                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                rend.color = Color.red;
            }


           

        }
    }

}
