using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ingredients : MonoBehaviour
{
    public GameObject[] ingredients;
    public int[] ingredNums;

    public void Click(int code)
    {
        if (ingredNums[code] < 3)
        {
            ingredNums[code]++;
            ingredients[code].transform.GetChild(0).gameObject.SetActive(true); //outline 활성화
            ingredients[code].transform.GetChild(1).gameObject.SetActive(true); //N 활성화
            ingredients[code].transform.GetChild(2).gameObject.SetActive(true); //x 활성화
            ingredients[code].transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = ingredNums[code].ToString();

        }else if (ingredNums[code] == 3)
        {
            ingredients[code].transform.GetChild(0).gameObject.SetActive(false);
            ingredients[code].transform.GetChild(1).gameObject.SetActive(false);
            ingredients[code].transform.GetChild(2).gameObject.SetActive(false);
            ingredNums[code] = 0;
        }

        //ingredNums[code]++;
    }
}
