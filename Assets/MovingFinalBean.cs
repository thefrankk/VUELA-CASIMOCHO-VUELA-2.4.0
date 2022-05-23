using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFinalBean : MonoBehaviour
{

    [Header("Make the object movement in X axis")]
    public bool isMoving;
    public int speedMoving;



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
}
