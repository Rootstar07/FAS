using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ingredients : MonoBehaviour
{
    public GameManager GM;
    public JsonReader jsonfile;
    public ForPosit posit;
    public Text positFirst;
    public UIDrag posit_UIDrag;
    public CoinAdmin coin;
    public ForSpecialThing special;
    public CharacterClick characterClick;

    public GameObject movableObject;

    public string cookCode;

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
    public Animator CompleteAnimator;

    int sugarcode = 0;
    int smellcode = 0;

    GameObject temp_special;


    private void Start()
    {
        noTouchPanel.SetActive(false);
    }

    private void Update()
    {
        TDValue = TD.value;

        if ((ingredNums[0] != 0 || ingredNums[1] != 0 || ingredNums[2] != 0) && (ingredNums[3] != 0 || ingredNums[4] != 0 || ingredNums[5] != 0))
            makeButton.SetActive(true);
        else
            makeButton.SetActive(false);
    }


    public void Click(int code)
    {
        targetText.text = jsonfile.myingredientList.IngredientData[code].textdata;

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
        //향 첨가
        //Todo 설명 넣을것 by json
        

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

        targetText.text = jsonfile.myingredientList.IngredientData[smellcode].scentdata;

    }

    public void GetSpeicalIngredient(int x, GameObject y)
    {
        nowSpecialCode = x;
        temp_special = y;
        temp_special.GetComponent<UIDrag>().startPos = new Vector2(-2, -3);

        specialText.text = specialList[x];
        y.SetActive(false);
        specialCancelButton.SetActive(true);
    }

    public void CanelSpecial()
    {
        temp_special.SetActive(true); //이전에 넣은 재료 생성
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


        cookCode = code;

        GM.movableObject.SetActive(false); //무버블 오브젝트 비활성화

        CompleteAnimator.SetBool("PanelOff", false);
        CompleteAnimator.SetBool("PanelOn", true);

    }

    public void MakeCanelButtonPressed()
    {
        //취소 버튼 누를때
        CompleteAnimator.SetBool("PanelOff", true);
        CompleteAnimator.SetBool("PanelOn", false);
    }

    public void MakeConfirmButtonPressed()
    {
        ResetCook();

        //최종완성 승인
        GM.CookCodeCome(cookCode);
        Debug.Log(cookCode);
    }

    public void ResetCook()
    {
        //설탕 초기화
        sugarcode = 0;
        SugarObj.GetComponent<Image>().sprite = Sugar[sugarcode];

        //향 초기화
        smellcode = 0;
        smellObj.GetComponent<Image>().sprite = smell[smellcode];
        targetSmellText.text = smellText[smellcode].ToString();

        //재료, 부재료 초기화
        for (int i = 0; i < 6; i++)
        {
            ingredients[i].transform.GetChild(0).gameObject.SetActive(false);
            ingredients[i].transform.GetChild(1).gameObject.SetActive(false);
            ingredients[i].transform.GetChild(2).gameObject.SetActive(false);
            ingredNums[i] = 0;
        }

        //온도 초기화
        TDValue = 0;

        //스페셜 재료 초기화
        temp_special = null;
        specialCancelButton.SetActive(false);

        nowSpecialCode = 0;
        specialText.text = specialList[0];

        characterClick.count = 0; //캐릭터 클릭 수 초기화
    }

    public void ChangeIngredients(int index)
    {
        Debug.Log("현재 인덱스: " + index);
        //포스트잇 변경
        posit.N_text = jsonfile.myIndexList.cookIndex[index].firstPage;
        posit.R_text = jsonfile.myIndexList.cookIndex[index].secondPage;

        //위의 방식으로는 버튼을 눌러야 변경되므로 최초 한번 변경
        positFirst.text = jsonfile.myIndexList.cookIndex[index].firstPage;

        //포스트잇 사이즈 변경
        posit_UIDrag.ChangePosit_small();


        //돈 변경
        //Debug.Log("예상 골드: " + jsonfile.myIndexList.cookIndex[index].gold);
        coin.CoinSet(jsonfile.myIndexList.cookIndex[index].gold);

        //특수재료 변경
        special.ChangeSpecialObject(index);

        //생성하기
        movableObject.SetActive(true);
    }

}
