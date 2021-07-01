using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;
using BayatGames.SaveGameFree;

public class GameManager : MonoBehaviour
{
    public Flowchart startFlowChart;

    public GameObject TalkCanV;
    public GameObject CookCanV;

    public GameObject sayDialog;
    public Animator barAnimator;

    public float Gold = 0;
    public TMP_Text goldText;
    public GameObject wallet;

    private void Start()
    {
        
    }


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

    public void IndexAlocation(string index) // 시작할때 스토리 인덱스 분배
    {
        startFlowChart.SetStringVariable("storyIndex", index);
        startFlowChart.SendFungusMessage("allocated");
    }

    public void Save()
    {
        SaveGame.Save<string>("_storyIndex", startFlowChart.GetStringVariable("storyIndex"));
        SaveGame.Save<float>("_gold", Gold);
    }

    public void Load()
    {
        if (SaveGame.Load<string>("_storyIndex") != null)
            startFlowChart.SetStringVariable("storyIndex", SaveGame.Load<string>("_storyIndex"));
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

    public void CoinEnter(ForCoin x)
    {
        Gold = Gold + x.gold;
        goldText.text = Gold.ToString();
        iTween.MoveBy(x.gameObject, wallet.transform.position, 1f);

    }
}
