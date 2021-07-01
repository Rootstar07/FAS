using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EventManager : MonoBehaviour
{
    //Fungus로부터 이벤트 실행 명령을 받으면 활성화까지 이후 사라지는 건 EM에서 처리
    public GameObject[] eventList;

    public void CallEvent(string y)
    {
        Debug.Log("이벤트 " + y);
        eventList[int.Parse(y)].SetActive(true);
    }

}
