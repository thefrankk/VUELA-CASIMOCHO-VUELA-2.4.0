using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_logic : MonoBehaviour
{
    public GameObject bkg_0;
    public GameObject bkg_1;
    public GameObject bkg_2;
    public GameObject bkg_3;
    public GameObject bkg_4;
    public GameObject bkg_5;
    public GameObject bkg_6;


    // <>
    public static float speedLayer0 = 6f;
    public static float speedLayer1 = 4f;
    public static float speedLayer2 = 1f;
    public static float speedLayer3 = 0.5f;
    public static float speedLayer4 = .5f;
    public static float speedLayer5 = .3f;
    public static float speedLayer6 = .1f;

    public static float scrollSpeed = .03f; //0.03f
    private float offset;

  

    Renderer rend5, rend4, rend3, rend2, rend1, rend0;

    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager_Menu.currentScene)
        {
            case GameManager_Menu.stateForScene.GameInfinite:

                //rend5 = bkg_5.GetComponent<Renderer>();
                //rend4 = bkg_4.GetComponent<Renderer>();
                rend3 = bkg_3.GetComponent<Renderer>();
                rend2 = bkg_2.GetComponent<Renderer>();
                rend1 = bkg_1.GetComponent<Renderer>();
                rend0 = bkg_0.GetComponent<Renderer>();

                break;

            case GameManager_Menu.stateForScene.GameLevel:

                
                rend3 = bkg_3.GetComponent<Renderer>();
                rend2 = bkg_2.GetComponent<Renderer>();
                rend1 = bkg_1.GetComponent<Renderer>();
                rend0 = bkg_0.GetComponent<Renderer>();

                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_Menu.guiOneTAP)
        {
            switch (GameManager_Menu.currentScene)
            {
                case GameManager_Menu.stateForScene.GameInfinite:

                    offset += scrollSpeed * Time.smoothDeltaTime;
                    offset = offset % 1.0f;


                    rend0.sharedMaterial.mainTextureOffset = new Vector2(offset * speedLayer0, 0);
                    rend1.sharedMaterial.mainTextureOffset = new Vector2(offset * speedLayer1, 0);
                    rend2.sharedMaterial.mainTextureOffset = new Vector2(offset * speedLayer2, 0);

                    break;

                case GameManager_Menu.stateForScene.GameLevel:

                    offset += scrollSpeed * Time.smoothDeltaTime;
                    offset = offset % 1.0f;


                    rend0.sharedMaterial.mainTextureOffset = new Vector2(offset * speedLayer0, 0);
                    rend1.sharedMaterial.mainTextureOffset = new Vector2(offset * speedLayer1, 0);
                    rend2.sharedMaterial.mainTextureOffset = new Vector2(offset * speedLayer0, 0);
                    rend3.sharedMaterial.mainTextureOffset = new Vector2(offset * speedLayer3, 0);

                    break;


            }
        }
        

    }

    private void FixedUpdate()
    {
        switch (GameManager_Menu.currentScene)
        {
            case GameManager_Menu.stateForScene.GameInfinite:
                break;
            case GameManager_Menu.stateForScene.GameLevel:
                
                break;
        }
    }
}