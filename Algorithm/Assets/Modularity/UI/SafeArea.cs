using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    void Awake()
    {
        RectTransform rt = GetComponent<RectTransform>();

        Rect safeArae = Screen.safeArea;

        Vector2 anchorMin = safeArae.position;
        Vector2 anchorMax = safeArae.position + safeArae.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rt.anchorMin = anchorMin;
        rt.anchorMax = anchorMax;
    }
}
