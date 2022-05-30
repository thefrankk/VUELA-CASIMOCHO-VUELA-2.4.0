using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMarker : MonoBehaviour
{

    public static float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager_Menu.guiOneTAP)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            switch (GameManager_Menu.currentMundoIndex)
            {
                case 1:
                    //Agregamos la distancia
                    GameController.distanciaRecorrida += 1;
                    break;
                case 2:
                    GameController.distanciaRecorrida1 += 1;
                    break;
                case 3:
                    GameController.distanciaRecorrida2 += 1;
                    break;
                case 4:
                    GameController.distanciaRecorrida3 += 1;
                    break;
            }

            GameController.GLOBALsuperatedObstacles += 1;
        }


    }

}
