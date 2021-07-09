using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForBook : MonoBehaviour
{
    public Animator animator;
    public Button bookButton;
    public ForBookButton forBookButton;
    //bool isUp = false;

    public void BookClick()
    {
        //animator.SetBool("BookUp", !isUp);      
        //isUp = !isUp;
        if (animator.GetBool("BookOn") == false)
            animator.SetBool("BookOn", true);
        else
            animator.SetBool("BookOn", false);

        //bookButton.interactable = false;
        //isUp = true;
    }

    public void CloseBookButtonClick()
    {
        animator.SetBool("BookOn", false);
        //isUp = false;
        bookButton.interactable = true;
        forBookButton.bigButtonClick(0);
    }

}
