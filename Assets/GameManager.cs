using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Flowchart startFlowChart;
    public GameObject mainScreen;
    public GameObject dayPanel;

    public GameObject TalkCanV;
    public GameObject CookCanV;

    public GameObject sayDialog;
    //public Animator barAnimator;

    public float Gold = 0;
    public TMP_Text goldText;
    public GameObject wallet;

    private void Start()
    {
        mainScreen.transform.GetChild(0).gameObject.SetActive(true); //배경판넬이 꺼져있을수도 있으니까 무조건 활성화
        mainScreen.transform.GetChild(1).gameObject.SetActive(false); //Day 판넬 겹치지 않게 비활성화
        mainScreen.GetComponent<Animator>().Play("StartAni"); //메인화면 애니메이션 재생
    }


    void Update()
    {
        //이건 뭔 함수일까요
        /*
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
        */

    }

    public void StartButtonPressed()
    {
        mainScreen.GetComponent<Animator>().Play("StartAni Reversed"); //메인화면 사라지는 애니메이션
        Load(); //세이브 파일 받아오고 flowchart 실행
    }

    public void Calender(string txt)
    {
        //txt를 ,을 기준으로 쪼개서 사용
        //다음으로 넘어갈 인덱스, 오늘 날짜, 오늘 일정
        string[] _txt = txt.Split(',');

        dayPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = _txt[1]; //Day text
        dayPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = _txt[2]; // 일정 text

        //캘린더 함수가 flowchart로부터 실행되면 우선 배경판넬 끄고 day판넬을 켠 다음 애니메이션 재생
        mainScreen.transform.GetChild(0).gameObject.SetActive(false);
        mainScreen.transform.GetChild(1).gameObject.SetActive(true);
        mainScreen.GetComponent<Animator>().Play("Calender");

    }

    public void IndexAlocation(string index)
    {
        //인덱스를 받아서 스토리인덱스를 변경
        startFlowChart.SetStringVariable("storyIndex", index);

        //allocate 메시지를 보내서 실행
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
            IndexAlocation(SaveGame.Load<string>("_storyIndex"));
        else
            IndexAlocation("0");
    }


    public void TalkAndCook()
    {
        //대화 전환 함수

        //조리탭 열기
        if (TalkCanV.activeSelf == true)
        {

            TalkCanV.SetActive(false);
            CookCanV.SetActive(true);
        }
        //대화 탭 열기
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
