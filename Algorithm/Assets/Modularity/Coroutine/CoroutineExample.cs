using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CoroutineExample : MonoBehaviour
{
    // Json
    public static IEnumerator PostRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    // File download
    public static IEnumerator DownloadRequest(string url, string filePath, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.downloadHandler = new DownloadHandlerFile(filePath);
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    // Texture download or load
    public static IEnumerator TextureRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    // Data upload server
    public static IEnumerator UploadRequest(string url, string data, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, data))
        {
            yield return request.SendWebRequest();
        }
    }

    public static void RequestError(UnityWebRequest.Result result)
    {

        switch (result)
        {
            case UnityWebRequest.Result.ConnectionError:
                // 인터넷 에러
                break;
            case UnityWebRequest.Result.DataProcessingError:
                // 데이터 전송 에러
                break;
            case UnityWebRequest.Result.ProtocolError:
                // 서버연결 에러
                break;
        }

    }

    public static void NetworkReachablility()
    {
        switch (Application.internetReachability)
        {
            case NetworkReachability.NotReachable:
                // Popup => NetworkReachablilty(); 재시도
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                // 핸드폰 데이터
                break;
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                // 로컬 데이터 (wifi)
                break;
        }
    }
}
