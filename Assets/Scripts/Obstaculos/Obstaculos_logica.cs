using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos_logica : MonoBehaviour
{

    public static float speed = 3f;

    Rigidbody2D r2bd;


    // Start is called before the first frame update
    void Start()
    {
        r2bd = GetComponent<Rigidbody2D>();


    }
  
    void Update()
    {
        if (!GameManager_Menu.guiOneTAP)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }







}
