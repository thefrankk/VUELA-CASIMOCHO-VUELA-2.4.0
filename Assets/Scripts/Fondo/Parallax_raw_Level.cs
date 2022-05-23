using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax_raw_Level : MonoBehaviour
{
    public static float parallaxSpeed = 0.04f;
    public float pos0_MULTIPLICATOR, pos1_MULTIPLICATOR, pos2_MULTIPLICATOR, pos3_MULTIPLICATOR, pos4_MULTIPLICATOR;
   

    public RawImage pos0;
    public RawImage pos1;
    public RawImage pos2;
    public RawImage pos3;
    public RawImage pos4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float finalSpeed = parallaxSpeed * Time.smoothDeltaTime;

        if (Options.betterPerformance)
        {
            pos3.enabled = false;

           
        }
        if (!GameManager_Menu.guiOneTAP)
        {

        pos0.uvRect = new Rect(pos0.uvRect.x + finalSpeed * pos0_MULTIPLICATOR, 0f, 1f, 1f);
        pos1.uvRect = new Rect(pos1.uvRect.x + finalSpeed * pos1_MULTIPLICATOR, 0f, 1f, 1f);
        pos2.uvRect = new Rect(pos2.uvRect.x + finalSpeed * pos2_MULTIPLICATOR, 0f, 1f, 1f);
        pos3.uvRect = new Rect(pos3.uvRect.x + finalSpeed * pos3_MULTIPLICATOR, 0f, 1f, 1f);
        }

    }
}
