using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelObstacles : MonoBehaviour
{

  

    public GameObject obstaclesLevel1;
    public GameObject obstaclesLevel2;
    public GameObject obstaclesLevel3;
    public GameObject obstaclesLevel4;
    public GameObject obstaclesLevel5;

    public GameObject finalObstacleLevel1;
    public GameObject finalObstacleLevel2;
    public GameObject finalObstacleLevel3;
    public GameObject finalObstacleLevel4;
    public GameObject finalObstacleLevel5;

    public GameObject DeactivateObstacle;

    private GameObject player;

    public enum stateForObstacles
    {
        obstacles1,
        obstacles2,
        obstacles3,
        obstacles4,
        obstacles5
    }

    public stateForObstacles currentLevelObstacle;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = finalObstacleLevel1.transform.position;
        gameObject.transform.position = startPosition;
        
        currentLevelObstacle = stateForObstacles.obstacles1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");

        }
        else
        {
            
        }
       

    }


    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        switch (currentLevelObstacle)
        {
            case stateForObstacles.obstacles1:

                if (collision.gameObject.GetInstanceID() == player.GetInstanceID())
                {

                    Vector3 startSecondPosition = finalObstacleLevel2.transform.position;
                    gameObject.transform.position = startSecondPosition;

                    StartCoroutine(ActivateObstacle());

                    obstaclesLevel2.SetActive(true);
                    

                }

                break;

            case stateForObstacles.obstacles2:

                if (collision.gameObject.GetInstanceID() == player.GetInstanceID())
                {
                    Vector3 startThirdPosition = finalObstacleLevel3.transform.position;
                    gameObject.transform.position = startThirdPosition;

                    StartCoroutine(ActivateObstacle());
                    obstaclesLevel3.SetActive(true);
                    

                }
                break;

            case stateForObstacles.obstacles3:

                if (collision.gameObject.GetInstanceID() == player.GetInstanceID())
                {
                    Vector3 startFourPosition = finalObstacleLevel4.transform.position;
                    gameObject.transform.position = startFourPosition;

                    StartCoroutine(ActivateObstacle());
                    obstaclesLevel4.SetActive(true);
                    

                }
                break;
            case stateForObstacles.obstacles4:
                if (collision.gameObject.GetInstanceID() == player.GetInstanceID())
                {
                    obstaclesLevel5.SetActive(true);
                    StartCoroutine(ActivateObstacle());
                    currentLevelObstacle = stateForObstacles.obstacles4;

                }
                break;

            case stateForObstacles.obstacles5:
                if (collision.gameObject.GetInstanceID() == player.GetInstanceID())
                {
                    obstaclesLevel4.SetActive(false);
                    // obstaclesLevel4.SetActive(true);
                    currentLevelObstacle = stateForObstacles.obstacles5;

                }
                break;

        }
         
    }


    IEnumerator ActivateObstacle()
    {
        yield return new WaitForSeconds(2f);
        switch (currentLevelObstacle)
        {
            case stateForObstacles.obstacles1:
                obstaclesLevel1.SetActive(false);
                currentLevelObstacle = stateForObstacles.obstacles2;
                break;

            case stateForObstacles.obstacles2:
                obstaclesLevel2.SetActive(false);
                currentLevelObstacle = stateForObstacles.obstacles3;
                break;

            case stateForObstacles.obstacles3:
                obstaclesLevel3.SetActive(false);
                currentLevelObstacle = stateForObstacles.obstacles4;
                break;
            case stateForObstacles.obstacles4:
                obstaclesLevel4.SetActive(false);
                currentLevelObstacle = stateForObstacles.obstacles4;
                break;


        }
    }
        
}
