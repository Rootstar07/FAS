using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBook : MonoBehaviour
{
    public Animator animator;
    bool isUp = false;

    public void BookClick()
    {
        animator.SetBool("BookUp", !isUp);      
        isUp = !isUp;
    }

}
