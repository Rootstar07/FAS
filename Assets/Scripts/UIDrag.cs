using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public enum ObjKinds { Coin, Postit, SecretPosit, SpeicalObj };


public class UIDrag : MonoBehaviour
{
    bool startDrag;
    public Vector2 startPos;

    public ForPosit forPosit;
    public GameManager GM;

    public ObjKinds kind;
    public int howCoin;

    public Ingredients ingredients;
    public int thisSpeicalCode;

    public MovableManager movableManager;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Cursor.SetCursor(movableManager.normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (startDrag)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objPosition.z = 0;
            transform.position = objPosition;

            //transform.position = Input.mousePosition;
        }
    }

    public void StartDragUI()
    {
        startDrag = true;
        UpdateCol(startDrag);
        gameObject.transform.SetAsLastSibling();
        
    }

    public void StopDragUIButPosOk()
    {
        startDrag = false;
        UpdateCol(startDrag);
    }

    void UpdateCol(bool x)
    {
        movableManager.plusCol.SetActive(!x);
        //plusCol.SetActive(!x);
        movableManager.deskCol.SetActive(!x);
        movableManager.rightCol.SetActive(!x);

    }

    public void ReversePostit()
    {
        if (forPosit.reversed == false)
        {
            gameObject.GetComponent<Image>().sprite = forPosit.Reverse;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = forPosit.R_text;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = forPosit.big;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = forPosit.N_text;
        }
        forPosit.reversed = !forPosit.reversed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallTab")
        {
            //gameObject.GetComponent<Image>().sprite = small;
            //gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, smallSize);
            //gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, smallSize);
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //커서관리
        if (other.gameObject.tag == "cursorChecker")
        {
            Debug.Log("진입 성공");
            if (ingredients.speicalAvilable == thisSpeicalCode && (int)kind == 3) //스페셜코드와 스페셜 열거형이 일치해야만 마우스커서가 다운로드표시로 바뀜

            Cursor.SetCursor(movableManager.yesCursor, Vector2.zero, CursorMode.ForceSoftware);

            else if (ingredients.speicalAvilable != thisSpeicalCode || (int)kind != 3) //스페셜코드가 다르거나 스페셜 열거형이 아니면 x표시
            {
                Cursor.SetCursor(movableManager.noCursor, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
      
        //---------------------------
        //enum이 SpecialObj일때만 작동
        if (other.gameObject.tag == "plusHere" && ((int)kind == 3))
        {
            if (ingredients.speicalAvilable == thisSpeicalCode)
            {
                ingredients.GetSpeicalIngredient(thisSpeicalCode, gameObject);
            }
        }

        //오브젝트 공통: 위치업데이트
        else if (other.gameObject.tag == "PostitBorder")
        {
            transform.position = startPos; //내려놨을때, 오른쪽 경계면 위치를 초기화
        }
        else if (other.gameObject.tag == "desk")
        {
            startPos = transform.position; //내려놨을때, 책상이면 초기위치 업데이트
        }
    }

    public void FixBugwhenCanelButton()
    {
        startPos = new Vector2(0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "SmallTab")
        {
            //포스트잇일때 변화
            if ((int)kind == 1)
            {
                ChangePosit_big();
            }

        }
        if (collision.gameObject.tag == "cursorChecker")
            Cursor.SetCursor(movableManager.normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ChangePosit_big()
    {
        gameObject.GetComponent<Image>().sprite = forPosit.big; //큰 스프라이트로 변경
        gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, forPosit.BigSize);
        gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, forPosit.BigSize);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(250, 250);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        forPosit.reverseButton.SetActive(true);
    }

    public void ChangePosit_small()
    {
        gameObject.GetComponent<Image>().sprite = forPosit.small;
        gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 75);
        gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 75);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(75, 75);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        forPosit.reverseButton.SetActive(false);
    }
}
