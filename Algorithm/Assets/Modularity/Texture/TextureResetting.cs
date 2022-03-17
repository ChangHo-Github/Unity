using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureResetting : MonoBehaviour
{
    private Texture2D texture;

    // �б� ���� �ؽ�Ʈ�� �б� / ����� ����
    IEnumerator Action()
    {
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
        Graphics.Blit(texture, renderTexture);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTexture;
        Texture2D newTexture = new Texture2D(texture.width, texture.height);
        newTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        newTexture.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTexture);

        yield return new WaitForEndOfFrame();
    }
}
