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
                // ���ͳ� ����
                break;
            case UnityWebRequest.Result.DataProcessingError:
                // ������ ���� ����
                break;
            case UnityWebRequest.Result.ProtocolError:
                // �������� ����
                break;
        }

    }

    public static void NetworkReachablility()
    {
        switch (Application.internetReachability)
        {
            case NetworkReachability.NotReachable:
                // Popup => NetworkReachablilty(); ��õ�
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                // �ڵ��� ������
                break;
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                // ���� ������ (wifi)
                break;
        }
    }
}
