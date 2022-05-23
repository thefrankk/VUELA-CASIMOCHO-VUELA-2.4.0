using System.Collections;
using UnityEngine;


public class ButtonsInteractables : MonoBehaviour
{
    public static ButtonsInteractables buttonsInteractables;
    // <>
    private void Awake()
    {
        buttonsInteractables = this;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void InteractableMenuOFF()
    {
        MenusManager.MenusManagerInstance.PANEL_PRINCIPAL.SetActive(true);
        MenusManager.MenusManagerInstance.PANEL_CHOOSEMODE.SetActive(true);
        MenusManager.MenusManagerInstance.PANEL_LEVELSELECTOR.SetActive(true);



        StartCoroutine(InteractableMenusON());
    }

    IEnumerator InteractableMenusON()
    {
        yield return new WaitForSeconds(.5f);
        MenusManager.MenusManagerInstance.PANEL_PRINCIPAL.SetActive(false);
        MenusManager.MenusManagerInstance.PANEL_CHOOSEMODE.SetActive(false);
        MenusManager.MenusManagerInstance.PANEL_LEVELSELECTOR.SetActive(false);
    }


    public void InteractableButtonOff()
    {
        GameManager_Menu.gameManagerMenu.panel_UI_GameOver.SetActive(true);
        GameManager_Menu.gameManagerMenu.panel_UI_YouWin.SetActive(true);

        



        StartCoroutine(InteractableButtonOn());
    }

    IEnumerator InteractableButtonOn()
    {
        yield return new WaitForSeconds(.1f);

        GameManager_Menu.gameManagerMenu.panel_UI_GameOver.SetActive(false);
        GameManager_Menu.gameManagerMenu.panel_UI_YouWin.SetActive(false);
    }

    public void InteractableButtonsLEVEL_SELECTOR()
    {
        MenusManager.MenusManagerInstance.PANEL_LEVELSELECTOR.SetActive(true);
        MenusManager.MenusManagerInstance.PANEL_PLAYERSELECTOR.SetActive(true);




        StartCoroutine(InteractableButtonOnLEVEL_SELECTOR());
    }

    IEnumerator InteractableButtonOnLEVEL_SELECTOR()
    {
        yield return new WaitForSeconds(0.2f);
        MenusManager.MenusManagerInstance.PANEL_LEVELSELECTOR.SetActive(false);
        MenusManager.MenusManagerInstance.PANEL_PLAYERSELECTOR.SetActive(false);
    }

   

 

}
