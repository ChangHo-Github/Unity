using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeShareExample : MonoBehaviour
{
    public Texture2D texture;
    public string filePath;
    public string url;

    public void Share()
    {
        new NativeShare().AddFile(texture).SetTitle("")
        .SetSubject("").SetText("").SetUrl(url)
        .SetCallback((result, shareTarget) =>
        {

            switch (result)
            {
                case NativeShare.ShareResult.Shared:
                    // 공유성공
                    break;
                case NativeShare.ShareResult.NotShared:
                    // 공유취소
                    break;
                case NativeShare.ShareResult.Unknown:
                    // 공유실패
                    break;
            }

        }).Share();
    }

    public void DestoryTexture()
    {
        DestroyImmediate(texture);
    }
}
