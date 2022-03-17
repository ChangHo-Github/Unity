using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIScrollEvent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 targetPos;
    private Vector2 startPos;
    private Vector2 updatePos;
    private Vector2 endPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        updatePos = Input.mousePosition;

        // 이미지 이동 알고리즘
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endPos = Input.mousePosition;

        switch(targetPos.x)
        {
            case float num when (num >= endPos.x - startPos.x && num <= endPos.x - startPos.x):
                // return
                break;
            case float num when (num < endPos.x - startPos.x):
                // plus;
                break;
            case float num when (num > endPos.x - startPos.x):
                // minus;
                break;          
        }
    }
}
