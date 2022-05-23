using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Camera))]
public class AnotherCameraScript : MonoBehaviour
{

    // Set this to your target aspect ratio, eg. (16, 9) or (4, 3).
    public Vector2 targetAspect = new Vector2(9, 16);
    Camera _camera;

    public float width = 9f;
    public float height = 16f;

    //<>
    void Awake()
    {
        float division = (float)Screen.height / (float)Screen.width;
        //Camera.main.aspect = width / height;
        if (division > 2)
        {
          
        }
        else
        {
            
       
        }
        
    }

    void Start()
    {
        _camera = GetComponent<Camera>();
       // UpdateCrop();
    }

    // Call this method if your window size or target aspect change.
    public void UpdateCrop()
    {
        // Determine ratios of screen/window & target, respectively.
        float screenRatio = Screen.width / (float)Screen.height;
        float targetRatio = targetAspect.x / targetAspect.y;

        if (Mathf.Approximately(screenRatio, targetRatio))
        {
            // Screen or window is the target aspect ratio: use the whole area.
            _camera.rect = new Rect(0, 0, 1, 1);
        }
        else if (screenRatio > targetRatio)
        {
            // Screen or window is wider than the target: pillarbox.
            float normalizedWidth = targetRatio / screenRatio;
            float barThickness = (1f - normalizedWidth) / 2f;
            _camera.rect = new Rect(barThickness, 0, normalizedWidth, 1);
        }
        else
        {
            // Screen or window is narrower than the target: letterbox.
            float normalizedHeight = screenRatio / targetRatio;
            float barThickness = (1f - normalizedHeight) / 2f;
            _camera.rect = new Rect(0, barThickness, 1, normalizedHeight);
        }
    }
}

   

