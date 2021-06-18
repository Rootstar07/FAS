using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDND : MonoBehaviour
{
    bool isDragging;
    Vector2 startPos;
    public Sprite small, big;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePoisition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePoisition);
        }
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        startPos = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PostitBorder")

        {
            isDragging = false;
            transform.position = startPos;
        }

        else if (collision.gameObject.tag == "SmallTab")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = small;
            //gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallTab")
            gameObject.GetComponent<SpriteRenderer>().sprite = big;
        //gameObject.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
    }
}
