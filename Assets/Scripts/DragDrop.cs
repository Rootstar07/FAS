using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 시작");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("드래그");
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("드롭");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("드롭 종료");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PostitBorder")

        {
            Debug.Log("그만2");
            transform.position = new Vector2(0, 0);
        }
    }
}
