using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private float deltaTime = 0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        // ũ�� ������ ����
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        // ��ġ ����
        style.alignment = TextAnchor.UpperLeft;
        // ��Ʈũ������
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1, 1, 1, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.}fps))", msec, fps);
        GUI.Label(rect, text, style);
    }
}
