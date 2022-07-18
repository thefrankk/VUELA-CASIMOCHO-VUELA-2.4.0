using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class TapsPopup : MonoBehaviour
{
    private TextMeshPro textNumbers;
    private Rigidbody2D rb2d;

    //<>
    // Start is called before the first frame update
    void Start()
    {
        MenusManager.MenusManagerInstance.CrackEggs(1);

        textNumbers = GetComponent<TextMeshPro>();
        textNumbers.SetText(HuevosManager.tapCounterNumber.ToString());

        rb2d = GetComponent<Rigidbody2D>();

        float speed = Random.Range(5f, 15f);
        Vector3 v = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * Vector3.up;
        rb2d.velocity = v * speed;

        float seconds = Random.Range(0.2f, 1f);
        Destroy(gameObject, seconds);
    }

   
   
}
