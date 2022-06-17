using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointersMovement : MonoBehaviour
{



    public GameObject pointerUp;
    public GameObject pointerDown;

    public AnimationClip pointerAnimclip;
    public AnimationClip pointerAnimclipDown;


    private Animator AnimpointerUp;
    private Animator AnimpointerDown;

    public Transform zonaMovement;
    //<>

    private bool isPointing = false;
    private void Start()
    {
        AnimpointerUp = pointerUp.GetComponent<Animator>();
        AnimpointerDown = pointerDown.GetComponent<Animator>();


        PointDown();

    }

    private void OnEnable()
    {
        //PointDown();
    }
    // Update is called once per frame
    void Update()
    {

        if (zonaMovement.transform.position.y >= 0)
        {
            if (!isPointing)
                PointUp();
        }
        else if (zonaMovement.transform.position.y <= -5)
        {
            if (isPointing)
                 PointDown();
        }

    }


    private void PointUp()
    {
        AnimpointerUp.enabled = true;
        AnimpointerUp.Play(pointerAnimclip.name);
        AnimpointerDown.enabled = false;
        isPointing = true;
    }
    
    private void PointDown()
    {
        AnimpointerDown.enabled = true;
        AnimpointerUp.enabled = false;
        AnimpointerDown.Play(pointerAnimclipDown.name);
        isPointing = false;
    }



}
