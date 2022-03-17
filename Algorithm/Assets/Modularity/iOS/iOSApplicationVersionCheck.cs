using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class iOSApplicationVersionCheck : MonoBehaviour
{
    IEnumerator Action()
    {
        string url = "http://itunes.apple.com/lookup?bundleId={Package Name}";
        using(UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {

            }
            else
            {
                int index = request.downloadHandler.text.IndexOf("\"version\":");
                string[] version = request.downloadHandler.text.Substring(index, 30).Split('"');

                // 업데이트 체크
                if(version[3] == Application.version)
                {

                }
                else
                {

                }
            }
        }
    }
}
