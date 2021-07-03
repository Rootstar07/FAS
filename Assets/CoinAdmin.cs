using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdmin : MonoBehaviour
{
    public GameObject[] coinList;

    public void CoinSet(int num)
    {
        for (int i = 0; i < 5; i++)
        {
            coinList[i].SetActive(false);
        }


        for (int i =0; i< num; i++)
        {
            coinList[i].SetActive(true);
        }
    }
}
