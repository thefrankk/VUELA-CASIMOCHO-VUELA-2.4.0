using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TimeManager : MonoBehaviour
{

    public static TimeManager sharedInstance = null;
    private string _url = "http://leatonm.net/wp-content/uploads/2017/candlepin/getdate.php"; //change this to your own http://veinsofgames.infinityfreeapp.com/getdate.php
    private string _timeData;
    private string _currentTime;
    private string _currentDate;


    //make sure there is only one instance of this always.
   /* void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else if (sharedInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        


    }*/


    //time fether coroutine
    public IEnumerator getTime()
    {

        Debug.Log("connecting to php");
        UnityWebRequest www = UnityWebRequest.Get(_url);
        //  WWW www = new WWW(_url);
       

       

        yield return www.SendWebRequest();
        if (www.isNetworkError)
        {
              Debug.Log("Error");



        }
        else
        {
              Debug.Log("got the php information" + www.downloadHandler.text);
           
        }
        _timeData = www.downloadHandler.text;
        string[] words = _timeData.Split('/');

        //timerTestLabel.text = www.text;
        // Debug.Log("The date is : " + words[0]);
        //  Debug.Log("The time is : " + words[1]);

        //setting current time
        _currentDate = words[0];
        _currentTime = words[1];

    }

    public void clear()
    {
        
    }
  
   
    //get the current time at startup
    void Start()
    {
        //  Debug.Log("TimeManager script is Ready.");
       // StartCoroutine("getTime");

    }

    //get the current date - also converting from string to int.
    //where 12-4-2017 is 1242017
    public int getCurrentDateNow()
    {
        string[] words = _currentDate.Split('-');
        int x = int.Parse(words[0] + words[1] + words[2]);
        return x;
    }




    //get the current Time
    public string getCurrentTimeNow()
    {
        return _currentTime;
    }


}
