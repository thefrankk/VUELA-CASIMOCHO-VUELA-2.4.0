using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelector : MonoBehaviour
{


    public GameObject world1;
    public GameObject world2;
    public GameObject world3;
    public GameObject world4;



    GameObject currentWord;
    GameObject nextWorld;
    GameObject previusWorld;




    private void Update()
    {
        if(currentWord == world1)
        {
            
            nextWorld = world2;
            previusWorld = world1;


        }
        else if (currentWord == world2)
        {
            
            nextWorld = world3;
            previusWorld = world1;
        }
        else if (currentWord == world3)
        {
          
            nextWorld = world4;
            previusWorld = world2;
        }
        else if (currentWord == world4)
        {
          
            nextWorld = world4;
            previusWorld = world3;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWord = world1;
        nextWorld = world2;
        previusWorld = world1;
    }

   

    public void NextWorld()
    {
        currentWord.SetActive(false);
        currentWord = nextWorld;
        
        previusWorld.SetActive(false);
        nextWorld.SetActive(true);
       
    }

    public void PreviusWorld()
    {
        currentWord.SetActive(false);
        currentWord = previusWorld;
        
        nextWorld.SetActive(false);
        previusWorld.SetActive(true);
    }
}
