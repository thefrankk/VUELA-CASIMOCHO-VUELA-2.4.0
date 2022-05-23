using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;


public class Ranking : MonoBehaviour
{

   

    public void ShowLeaderboard()
    {
        if(Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            
            SSTools.ShowMessage("Not signed in.", SSTools.Position.bottom, SSTools.Time.twoSecond);

        }

    }

}
