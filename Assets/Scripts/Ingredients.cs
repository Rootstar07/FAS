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
    public TMP_Text specialText;
    public string[] specialList;

    public Slider TD;
    public float TDValue;

    public GameObject specialCancelButton;
    public GameObject makeButton;
    public GameObject noTouchPanel;

    int sugarcode = 0;
    int smellcode = 0;

    GameObject temp_special;

    [TextArea]
    public string[] ingredientData;

    private void Start()
    {
        noTouchPanel.SetActive(false);
    }

    private void Update()
    {
        TDValue = TD.value;

        if ((ingredNums[0] != 0 || ingredNums[1] != 0 || ingredNums[2] != 0) && (ingredNums[3] != 0 || ingredNums[4] != 0 || ingredNums[5] != 0))
        {
            makeButton.SetActive(true);
        }else
        {
            makeButton.SetActive(false);
        }
    }


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

    public void GetSpeicalIngredient(int x, GameObject y)
    {
        nowSpecialCode = x;
        temp_special = y;

        specialText.text = specialList[x];
        y.SetActive(false);
        specialCancelButton.SetActive(true);

        //취소기능
    }

    public void CanelSpecial()
    {
        temp_special.SetActive(true);
        specialCancelButton.SetActive(false);

        nowSpecialCode = 0;
        specialText.text = specialList[0];
    }

    public void LetsMake()
    {
        //코드 생성
        string code = "";

        int _TD = 0;

        foreach (int x in ingredNums)
        {
            code = code + x.ToString();
        }

        if (TDValue < 0.4)
            _TD = 0;
        else if (TDValue < 0.8)
            _TD = 1;
        else
            _TD = 2;

        code = code + _TD.ToString() + sugarcode.ToString() + smellcode.ToString() + nowSpecialCode.ToString();

        Debug.Log(code);

        noTouchPanel.SetActive(true);
        makeButton.SetActive(false);

    }


    //TOdo
    //제작완성
    //버튼 누를때 애니메이션
}
