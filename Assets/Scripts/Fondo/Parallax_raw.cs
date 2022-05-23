using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax_raw : MonoBehaviour
{

    //Bloquear el 3 si la persona asi lo decide y en el mundo 4 sacar el 3 - 
    public RawImage pos0_0;
    public RawImage pos0;
    public RawImage pos1;
    public RawImage pos2;
    public RawImage pos3;
    public RawImage pos4;
    public static float parallaxSpeed = 0.02f;
    public float pos0_MULTIPLICATOR, pos1_MULTIPLICATOR, pos2_MULTIPLICATOR, pos3_MULTIPLICATOR, pos4_MULTIPLICATOR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Options.betterPerformance)
        {
            pos3.enabled = false;

            if(GameManager_Menu.currentMundoIndex == 4)
            {
                pos1.enabled = false;
                pos0_0.enabled = false;
            }
        }

        
        float finalSpeed = parallaxSpeed * Time.deltaTime;

       // if (!GameManager_Menu.guiOneTAP)
        //{

            pos0.uvRect = new Rect(pos0.uvRect.x + finalSpeed * pos0_MULTIPLICATOR, 0f, 1f, 1f);
            pos1.uvRect = new Rect(pos1.uvRect.x + finalSpeed * pos1_MULTIPLICATOR, 0f, 1f, 1f);
            pos2.uvRect = new Rect(pos2.uvRect.x + finalSpeed * pos2_MULTIPLICATOR, 0f, 1f, 1f);
            pos3.uvRect = new Rect(pos3.uvRect.x + finalSpeed * pos3_MULTIPLICATOR, 0f, 1f, 1f);
            pos4.uvRect = new Rect(pos4.uvRect.x + finalSpeed * pos4_MULTIPLICATOR, 0f, 1f, 1f);
       // }
    }
}
