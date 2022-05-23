using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleType2 : MonoBehaviour
{

    public float additionalSpeed = 0f;

    Rigidbody2D r2bd;

    // <>
    SpriteRenderer[] renderers;
    Color childrenColor;
    SpriteRenderer rend;
    BoxCollider2D collider;


    public int damage;

    
    private void Awake()
    {
        RefreshRenderersList();

    }

    // Start is called before the first frame update
    void Start()
    {
        r2bd = GetComponent<Rigidbody2D>();


    }

    void Update()
    {

        rend = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        if (!GameManager_Menu.guiOneTAP)
        {
            transform.position += Vector3.left * (Obstaculos_logica.speed + additionalSpeed) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detectamos que sea el player que esta colisionando
        if (collision.gameObject.tag == "Player")
        {
            //Chequeamos cuantas vidas tiene nuestro player
            if (Player.vidas >= 1)
            {


                //Reproducimos el sonido
                SoundManager.sharedInstance.HitSound();
                //Cambiamos el trigger


                //Si tiene 1 vida o mas, Cambiamos de color el choque 
                rend.color = Color.red;
                ChangeColor(Color.red);


                collider.enabled = false;

                //Devolvemos su estado pasados unos segundos
                Invoke("BackStateObstaculo", 3f);
                GameController.GLOBALloosedLifesObstacles += 1;
                Player.vidas -= 1 + damage;

                if(Player.vidas <= 0)
                {
                    SoundManager.sharedInstance.HitSound();
                    collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                    //Matamos al player, en base a esta variable, se activiaran otros mecanismos.
                    GameController.gStates = GameController.GamingStates.youLoose;

                    Player.vidas = 0;
                }
            }
            else
            {
                if (Player.vidas <= 0)
                    return;


                GameController.GLOBALloosedLifesObstacles += 1;

                GameController.loosedLifesObstacles += GameController.GLOBALloosedLifesObstacles;
                PlayerPrefs.SetInt("loosedLifesObstacles", GameController.loosedLifesObstacles);

                Player.vidas -= 1 + damage; 
                SoundManager.sharedInstance.HitSound();
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                //Matamos al player, en base a esta variable, se activiaran otros mecanismos.
                GameController.gStates = GameController.GamingStates.youLoose;


            }
            //Va a tener vidas, las cuales se van a descontar.

        }
    }


    private void BackStateObstaculo()
    {
        rend.color = Color.white;
        ChangeColor(Color.white);
        collider.enabled = true;

    }
    public void RefreshRenderersList()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        childrenColor = color;
        ChangeColor();
    }
    void ChangeColor()
    {
        foreach (Renderer r in renderers)
            r.material.color = childrenColor;
    }



}
