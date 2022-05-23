using UnityEngine;

public class ObstaculosLogic_Levels : MonoBehaviour
{
 
   
    Vector3 pointA = new Vector3(0, 0, 100);
    Vector3 pointB = new Vector3(0, 0, 0);

    //Velocidad de los objectos
    public static float speedObject = 3f;
    // <>
  
    // Start is called before the first frame update
    void Start()
    {
       

        pointA = new Vector3(transform.position.x, -5f, transform.position.z);
        pointB = new Vector3(transform.position.x, 5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager_Menu.guiOneTAP)
        {
                if (gameObject.tag == "static_obstacle")
                 {
                        
                 }
                 else if (gameObject.tag == "Horizontal_Move")
                 {
                    //Smooth movement on lerp
                    pointA = new Vector3(-2, transform.position.y, transform.position.z);
                    pointB = new Vector3(2, transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(pointA, pointB, (Mathf.Sin(1f * Time.time) + 1.0f) / 2.0f);

                 }
                else
                 {
                    //Smooth movement on lerp
                    pointA = new Vector3(transform.position.x, -4f, transform.position.z);
                    pointB = new Vector3(transform.position.x, 4f, transform.position.z);
                    transform.position = Vector3.Lerp(pointA, pointB, (Mathf.Sin(1f * Time.time) + 1.0f) / 2.0f);

                }

            transform.position += Vector3.left * speedObject * Time.deltaTime;

        }




    }



}
