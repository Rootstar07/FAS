using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ingredients : MonoBehaviour
{
    public GameObject[] ingredients;
    public int[] ingredNums;
    public TMP_Text targetText;
    public GameObject SugarObj;
    public Sprite[] Sugar;

    public GameObject smellObj;
    public Sprite[] smell;
    public string[] smellText;
    public TMP_Text targetSmellText;

    public int speicalAvilable;
    public int nowSpecialCode;

    int sugarcode = 0;
    int smellcode = 0;

    [TextArea]
    public string[] ingredientData;

    public void Click(int code)
    {

        targetText.text = ingredientData[code];

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

    public void SugarClick()
    {
        if (sugarcode < 2)
        {
            sugarcode++;
            SugarObj.GetComponent<Image>().sprite = Sugar[sugarcode];
        }
        else
        {
            sugarcode = 0;
            SugarObj.GetComponent<Image>().sprite = Sugar[sugarcode];
        }

    }

    public void SmellClick()
    {
        if (smellcode < 3)
        {
            smellcode++;
            smellObj.GetComponent<Image>().sprite = smell[smellcode];
            targetSmellText.text = smellText[smellcode];
        }
        else
        {
            smellcode = 0;
            smellObj.GetComponent<Image>().sprite = smell[smellcode];
            targetSmellText.text = smellText[smellcode].ToString();
        }

    }

    public void GetSpeicalIngredient(int x)
    {
        nowSpecialCode = x;
    }

}
