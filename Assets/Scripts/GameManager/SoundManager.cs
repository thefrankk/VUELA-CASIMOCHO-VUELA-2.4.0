using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{



    public static SoundManager sharedInstance;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip loseSound;
    public AudioClip loseSound2;
    public AudioClip winSound;
    public AudioClip obstacle_succes;
    public AudioClip portalEnter;

    private void Start()
    {
        sharedInstance = this;
    }

    public void HitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    public void LoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }

    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void LoseSound2()
    {
        audioSource.PlayOneShot(loseSound2);
    } 
    public void ObstacleSucces()
    {
        audioSource.PlayOneShot(obstacle_succes);
    }

    public void PortalEnter()
    {
        audioSource.PlayOneShot(portalEnter);
    }

    private void Update()
    {
        //Music
        if (Options.sound)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }

}
