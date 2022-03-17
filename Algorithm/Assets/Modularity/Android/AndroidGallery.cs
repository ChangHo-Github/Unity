using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidGallery : MonoBehaviour
{
#if UNITY_ANDROID
    public void AndroidGalleryOpen()
    {
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        var intent = new AndroidJavaObject("android.content.Intent", "android.intent.action.MAIN");
        intent.Call<AndroidJavaObject>("addCategory", "android.intent.category.LAUNCHER");
        intent.Call<AndroidJavaObject>("addCategory", "android.intent.category.APP_GALLERY");
        activity.Call("startActivity", intent);
    }
#endif
}
