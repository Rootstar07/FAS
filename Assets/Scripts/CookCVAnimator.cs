using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCVAnimator : MonoBehaviour
{

    public Animator cookCVAnimator;

    public void DisableAnimator()
    {
        cookCVAnimator.enabled = false;
    }

}
