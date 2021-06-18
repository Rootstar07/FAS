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
    }

    public void StopDragUI()
    {
        startDrag = false;
        transform.position = startPos;
    }

    public void StopDragUIButPosOk()
    {
        startDrag = false;
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PostitBorder")

        {
            Debug.Log("그만2");
            StopDragUI();
        }

        else if (collision.gameObject.tag == "SmallTab")
        {
            gameObject.GetComponent<Image>().sprite = small;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "SmallTab")
            gameObject.GetComponent<Image>().sprite = big;
    }




}
