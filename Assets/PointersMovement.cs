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
    private void Start()
    {
        AnimpointerUp = pointerUp.GetComponent<Animator>();
        AnimpointerDown = pointerDown.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      
        if(zonaMovement.transform.position.y >= 0)
        {
            
            AnimpointerUp.enabled = true;
            AnimpointerUp.Play(pointerAnimclip.name);
            AnimpointerDown.enabled = false;

        }
        else if (zonaMovement.transform.position.y <= -5)
        {
            
            AnimpointerDown.enabled = true;
            AnimpointerUp.enabled = false;
            AnimpointerDown.Play(pointerAnimclipDown.name);
        }

    }





}
