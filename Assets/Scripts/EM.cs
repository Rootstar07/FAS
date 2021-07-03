using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EM : MonoBehaviour
{
    public GameManager gameManager;
    public string nextIndex;

    //이벤트의 애니메이션에서 호출하면 해당 이벤트 끝내고 Fungus에 연락(예정)
    public void StopEvent()
    {
        gameObject.SetActive(false);
        gameManager.IndexAlocation(nextIndex);
    }
}
