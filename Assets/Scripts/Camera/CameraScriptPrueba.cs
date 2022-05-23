using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScriptPrueba : MonoBehaviour
{
    public enum TypeCamera
    {
        Perspective = 0,
        Orthograhics = 1
    }

    public TypeCamera typeCamera = TypeCamera.Perspective;
    public float cameraPerspectiveFovdefault = 70F;
    float cameraOrthograhicsFovdefault = 15F;

   

    Camera mainCamera;

    private void Awake()
    {
        float division = (float)Screen.height / (float)Screen.width;
        

        switch(Screen.height)
        {
            case 800:
                cameraOrthograhicsFovdefault = 7.5f;
                break;

            case 1280:
                cameraOrthograhicsFovdefault = 7f;
                break;
            case 1920:
                cameraOrthograhicsFovdefault = 7f;
                break;
            case 2160:
                cameraOrthograhicsFovdefault = 6.25f;
                break;
            case 2560:
                cameraOrthograhicsFovdefault = 6.25f;
                break;
            case 1600:
                cameraOrthograhicsFovdefault = 5.74f;
                break;

        }
    }
    void Start() => mainCamera = Camera.main;

    void Update()
    {
        
/*#if !UNITY_EDITOR
        if (isFirstStart) return;
        isFirstStart = true;
#endif*/

        float num = (float)Screen.height / (float)Screen.width;
        float ratio = Screen.height / 1920f / (Screen.width / 1080f);

        //if (num > 1.8f)
        //{
        switch (typeCamera)
        {
            case TypeCamera.Perspective: mainCamera.fieldOfView = cameraPerspectiveFovdefault * ratio; break;
            case TypeCamera.Orthograhics: mainCamera.orthographicSize = cameraOrthograhicsFovdefault * ratio; break;
        }
        //}
    }
}
