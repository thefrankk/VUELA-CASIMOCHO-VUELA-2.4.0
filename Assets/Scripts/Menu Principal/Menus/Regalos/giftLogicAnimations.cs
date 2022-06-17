using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class giftLogicAnimations : MonoBehaviour
{
    //Panel de los regalos
    public GameObject panel;
    public Animator anim;
    public GameObject cardObject;
    public Animator cardAnimator;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        FirstAnimation();

        cardAnimator = cardObject.GetComponent<Animator>();
    }

    public async void FirstAnimation()
    {
        await Task.Delay(5);

        if (giftClass.CheckAvaliableGifts())
        {
            anim.SetBool("notificationActivated", true);
        }
        else
            anim.SetBool("notificationActivated", false);

        SetTransform();
    }



    public void Open()
    {
        MenusManager.MenusManagerInstance.BackSound();

        anim.SetBool("notificationActivated", false);
        anim.SetBool("openChest", true);

        SetTransform();
        OpenGift();
    }

    public async void OpenGift()
    {
        MenusManager.MenusManagerInstance.BackSound();

        anim.SetBool("closeChest", false);
        await Task.Delay(1500);

        panel.SetActive(true);
    }


    public void Close()
    {
        MenusManager.MenusManagerInstance.BackSound();

        anim.SetBool("notificationActivated", false);
        anim.SetBool("openChest", false);
        anim.SetBool("closeChest", true);

        chestLogic.Close();

        float zRotation = this.GetComponent<RectTransform>().eulerAngles.z;
        zRotation = 0f;


        panel.SetActive(false);

        FirstAnimation();
        SetTransform();
    }

    private async void SetTransform()
    {
        await Task.Delay(1);

        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        
    }
}
