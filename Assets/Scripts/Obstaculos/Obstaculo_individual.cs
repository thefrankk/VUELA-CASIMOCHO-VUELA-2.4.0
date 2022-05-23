using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo_individual : MonoBehaviour
{
    // <>

    SpriteRenderer[] renderers;
    Color childrenColor;
    SpriteRenderer rend;
    BoxCollider2D collider;
    // Start is called before the first frame update
    private void Awake()
    {
        RefreshRenderersList();
        
    }

    // Update is called once per frame
    void Update()
    {
        rend = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

    }

    //Cuando colisionamos con el obstaculo
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Detectamos que sea el player que esta colisionando
        if (col.gameObject.tag == "Player")
        {
            //Chequeamos cuantas vidas tiene nuestro player
           if (Player.vidas >= 2)
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
                Player.vidas--;
            }
           else
            {
               
                if (Player.vidas == 0)
                    return;

                GameController.GLOBALloosedLifesObstacles += 1;

                GameController.loosedLifesObstacles += GameController.GLOBALloosedLifesObstacles;
                PlayerPrefs.SetInt("loosedLifesObstacles", GameController.loosedLifesObstacles);

                Player.vidas--;
                SoundManager.sharedInstance.HitSound();
                col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                
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
