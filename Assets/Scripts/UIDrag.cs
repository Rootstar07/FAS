using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public enum ObjKinds { Coin, Postit, SecretPosit, SpeicalObj };


public class UIDrag : MonoBehaviour
{
    bool startDrag;
    Vector2 startPos;
    public Sprite small, big;
    public int smallSize;
    public int BigSize;
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
            transform.position = Input.mousePosition;
        }
    }

    public void StartDragUI()
    {
        startDrag = true;
        UpdateCol(startDrag);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "SmallTab")
        {
            gameObject.GetComponent<Image>().sprite = big; //큰 스프라이트로 변경
            gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, BigSize);
            gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, BigSize);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(250, 250);


            if ((int)kind == 1 || (int)kind == 2)
                gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //----------------------------------------------------//
            //코인 제어 todo:클릭해서 그냥 넣기
            //----------------------------------------------------//
            if ((int)kind == 0)
            {
                GM.CoinEnter(howCoin);
                Debug.Log("성공");
                gameObject.SetActive(false);
            }
        }


        if (collision.gameObject.tag == "cursorChecker")
            Cursor.SetCursor(movableManager.normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
