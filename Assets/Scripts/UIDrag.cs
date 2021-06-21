using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDrag : MonoBehaviour
{
    bool startDrag;
    Vector2 startPos;
    public Sprite small, big;
    public int smallSize;
    public int BigSize;

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
            gameObject.GetComponent<Image>().sprite = small;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //커서관리
        if (other.gameObject.tag == "cursorChecker")
        {
            Debug.Log("진입 성공");
            if (ingredients.speicalAvilable == thisSpeicalCode)

            Cursor.SetCursor(movableManager.yesCursor, Vector2.zero, CursorMode.ForceSoftware);

            else if (ingredients.speicalAvilable != thisSpeicalCode)
            {
                Cursor.SetCursor(movableManager.noCursor, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
      
        //작동관리
        if (other.gameObject.tag == "plusHere")
        {
            if (ingredients.speicalAvilable == thisSpeicalCode)
            {
                ingredients.GetSpeicalIngredient(thisSpeicalCode, gameObject);
            }
        }
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
            gameObject.GetComponent<Image>().sprite = big;

        if (collision.gameObject.tag == "cursorChecker")
            Cursor.SetCursor(movableManager.normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
