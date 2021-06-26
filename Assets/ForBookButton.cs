using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBookButton : MonoBehaviour
{
    public GameObject speciesTab;
    public GameObject links;
    public GameObject targetPages;
    GameObject nowOpenPage = null;

    public void smallButtonClick(int n)
    {
        if (nowOpenPage != null)
            nowOpenPage.SetActive(false); //기존 페이지 비활성화

        nowOpenPage = targetPages.transform.GetChild(n).gameObject; //새로운 페이지 생성
        nowOpenPage.SetActive(true); //새로운 페이지 활성화

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
    }

}
