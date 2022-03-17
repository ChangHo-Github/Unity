using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectScreenShot : MonoBehaviour
{
    [SerializeField]
    private Camera captureCamera;

    public void ScreenShot()
    {
        // �����˻� �� �ʱ���ý� ����
        string directoryPath = Application.persistentDataPath + "/" + "ScreenShot";
        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
        if (!directoryInfo.Exists)
        {
            Directory.CreateDirectory(directoryPath);
        }

        // UI����
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 30);
        captureCamera.targetTexture = renderTexture;
        captureCamera.Render();
        RenderTexture.active = renderTexture;

        // �������
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.name = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        texture.Apply();

        // ����
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(directoryPath + "/" + texture.name, bytes);

        // �޸� ����
        Destroy(renderTexture);
        captureCamera.targetTexture = null;
        RenderTexture.active = null;
    }
}
