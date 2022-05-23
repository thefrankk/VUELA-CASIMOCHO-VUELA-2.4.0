using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevelManager : MonoBehaviour
{

    public static MusicLevelManager sharedInstance;
    [Header("AUDIO Y SONIDOS")]
    public AudioSource audioSource;
    public AudioClip word1_level1;
    public AudioClip word2_level2;


    [Header("Music")]
    public AudioClip word1_infite;
    public AudioClip word1_sub1;
    public AudioClip word1_level2;
    public AudioClip word1_sub2;
    public AudioClip word1_level3;
    public AudioClip word1_sub3;
    public AudioClip word1_level4;
    public AudioClip word2_infite;
    public AudioClip word3_infite;
    public AudioClip word4_infite;

    // Start is called before the first frame update
    void Start()
    {
        sharedInstance = this;

        StartCoroutine(PlayTheMusic());
    }
    IEnumerator PlayTheMusic()
    {
        yield return new WaitForSeconds(.5f);

        PlayMusic();
    }

    void PlayMusic()
    {
        switch (GameController.CurrentInfiniteWorld)
        {
            case GameController.Worlds.World1:


                switch (GameController.gamecontroller.currentLevelInfinite)
                {
                    case GameController.WorldsAndsLevels.World1Level1:

                        GenericPlaySound(word1_infite); // word1_infite

                        break;


                    case GameController.WorldsAndsLevels.World1SubLevel1:
                        GenericPlaySound(word1_sub1);

                        break;
                    case GameController.WorldsAndsLevels.World1Level2:
                        
                        GenericPlaySound(word1_level2);
                        break;
                    case GameController.WorldsAndsLevels.World1SubLevel2:
                        GenericPlaySound(word1_sub2);
                        break;
                    case GameController.WorldsAndsLevels.World1Level3:
                        GenericPlaySound(word1_level3);
                        break;
                    case GameController.WorldsAndsLevels.World1Sublevel3:
                        GenericPlaySound(word1_sub3);
                        break;
                    case GameController.WorldsAndsLevels.World1Level4:
                        GenericPlaySound(word1_level4);
                        break;
                }

                break;

            case GameController.Worlds.World2:

                GenericPlaySound(word2_infite);
                break;
            case GameController.Worlds.World3:

                GenericPlaySound(word3_infite);
                break;
            case GameController.Worlds.World4:

                GenericPlaySound(word4_infite);
                break;

        }

        if (GameManager_Menu.currentScene != GameManager_Menu.stateForScene.GameInfinite)
        {
            switch (GameManager_Menu.currentLevelIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 10:
                case 11:
                case 12:

                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    GenericPlaySound(word1_level1);
                    break;

                case 9:
                    GenericPlaySound(word2_level2);
                    break;

                case 13:
                    GenericPlaySound(word2_level2);
                    break;

                case 20:
                    GenericPlaySound(word2_level2);
                    break;


            }
        }
    }


    void GenericPlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
    private void Update()
    {
        //Music
        if (Options.music)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }
}
