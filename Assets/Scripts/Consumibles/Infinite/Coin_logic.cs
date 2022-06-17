using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_logic : MonoBehaviour
{
    /// <summary>
    /// LOGICA DE LA MONEDA PROPIA, INDISTINTO SI ES MODO INFINITO O MODO SURVIVAL
    /// </summary>


    //Speed a la que se mueven las monedas
    public static float speed = 3f;
    //Traemos componente renderer para acceder a el
    SpriteRenderer rend;
   
    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip coinPick;

    //prefab coinpicker
    public Transform coinParticle;
    // <>
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        
    }

    private void OnEnable()
    {
        if (subLevelManager.portalIsOnScreen)
        {
            Destroy(this);
        }
       
    }


    // Update is called once per frame
    void Update()
    {

        //Movement 
        if (!GameManager_Menu.guiOneTAP)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

    }

    //Codigo para agregar monedas

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (Options.sound)
            {
                audioSource.PlayOneShot(coinPick);
            }



            //Opacamos el color de la moneda
            rend.color = new Color(1f, 1, 1f, 0.5f);
            //Sumamos la moneda a nuestra variable
            GameController.coinsOnPlay++;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //Invocamos la funcion para volver todo a la normalidad a los 5s
            Invoke("BackToState", 2f);
        }

        if(collision.tag == "Obstaculos_palos")
        {
            
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.SetActive(false);
            rend.color = new Color(1f, 1f, 1f, 0f);
            Invoke("BackToState", 10f);


        }
    

    }

    void BackToState()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.SetActive(true);
        rend.color = new Color(1f, 1, 1f, 255f);
        
    }

 
  
}
