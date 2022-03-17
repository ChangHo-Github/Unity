using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidToastPopup : MonoBehaviour
{
#if UNITY_ANDROID
    public void ToastPopup(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 3);
                toastObject.Call("show");
            }));
        }
    }
#endif
}
