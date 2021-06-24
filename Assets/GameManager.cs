using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject TalkCanV;
    public GameObject CookCanV;

    public GameObject sayDialog;
    public Animator barAnimator;

    public float Gold = 0;
    public TMP_Text goldText;

    void Update()
    {

        if (TalkCanV.activeSelf == true)
        {
            if (sayDialog.activeSelf == true)
            {
                barAnimator.SetBool("Say", true);
            }
            else
            {
                barAnimator.SetBool("Say", false);
            }
        }

    }

    public void TalkAndCook()
    {
        if (TalkCanV.activeSelf == true)
        {
            TalkCanV.SetActive(false);
            CookCanV.SetActive(true);
        }
        else
        {
            TalkCanV.SetActive(true);
            CookCanV.SetActive(false);
        }

    }

    public void CoinEnter(int money)
    {
        Gold = Gold + money;
        goldText.text = Gold.ToString();
    }
}
