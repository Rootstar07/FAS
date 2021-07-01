using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForBookButton : MonoBehaviour
{
    public GameObject speciesTab;
    public GameObject targetPages;
    public int linkNum = 2;
    GameObject nowOpenPage = null;
    public int nowPageCode = 0;
    public GameObject pageText;
    public GameObject pageNextButton;

    public void smallButtonClick(int n)
    {
        if (nowOpenPage != null)
            nowOpenPage.SetActive(false); //기존 페이지 비활성화

        nowPageCode = n;
        nowOpenPage = targetPages.transform.GetChild(nowPageCode).gameObject; //새로운 페이지 생성
        nowOpenPage.SetActive(true); //새로운 페이지 활성화

        pageText.SetActive(true);
        pageNextButton.SetActive(true);
        PageUpdate();

    }

    private void Start()
    {
        PageUpdate();
    }

    public void PageUpdate()
    {
        pageText.transform.GetChild(2).GetComponent<Text>().text = linkNum.ToString();
        pageText.transform.GetChild(0).GetComponent<Text>().text = (nowPageCode+1).ToString();
    }

    public void smallButtonNextClick(int n)
    {
        if (n==1 && nowPageCode > linkNum - 2)
            smallButtonClick(0);

        else if (n == -1 && nowPageCode + n < 0)
            smallButtonClick(linkNum - 1);

        else
            smallButtonClick(nowPageCode + n);

        PageUpdate();

    }

    public void bigButtonClick(int n)
    {
        if (n == 0) //메뉴 탭 누르면
        {
            if (nowOpenPage != null)
                nowOpenPage.SetActive(false); //현재 열린페이지 비활성화

            speciesTab.SetActive(false); //종족 페이지 비활성화
        }

        if (n == 1) //종족 탭 누르면
        {
            speciesTab.SetActive(true); //종족 페이지 활성화
        }

        pageText.SetActive(false);
        pageNextButton.SetActive(false);
    }

}
