using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeInteractables : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonRestartInfinite;
    public Button buttonMenu;
    public Button buttonMenuInfinite;
    public Button buttonMenuWin;
    public Button buttonRestartWin;
    public Button buttonGotoLevels;
    public Button buttonRevive;




   public void offButtons()
    {
        buttonRestart.interactable = false;
        buttonRestartInfinite.interactable = false;
        buttonMenu.interactable = false;
        buttonMenuInfinite.interactable = false;
        buttonRevive.interactable = false;
        StartCoroutine(onButtonsCo());

    }

    public void onButtons()
    {
        buttonRestartInfinite.interactable = true;
        buttonRestart.interactable = true;
        buttonMenu.interactable = true;
        buttonMenuInfinite.interactable = true;
        buttonRevive.interactable = true;
    }

    IEnumerator onButtonsCo()
    {
        yield return new WaitForSeconds(5f);
        onButtons();
    }
}
