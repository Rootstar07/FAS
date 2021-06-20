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
    public GameObject rightCol;
    public GameObject deskCol;
    public GameObject plusCol;
    public Ingredients ingredients;
    public int thisSpeicalCode;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
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
        plusCol.SetActive(!x);
        deskCol.SetActive(!x);
        rightCol.SetActive(!x);

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
        if (other.gameObject.tag == "plusHere")
        {
            if (ingredients.speicalAvilable == thisSpeicalCode)
            {
                ingredients.GetSpeicalIngredient(thisSpeicalCode);
                Destroy(gameObject); //내려놨을때, 첨가물 영역이면 결정하기

                //Todo
                //가능한 코드면 가능하다고 표시
                //불가능한 코드면 안된다고 피드백
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
    }
}
