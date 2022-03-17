using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextureLoad : MonoBehaviour
{
    IEnumerator Action()
    {
        // 파일 로드에 file:// 사용
        string filePath = "file://" + Application.persistentDataPath + "filePath";
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(filePath))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {

            }
            else
            {

            }
        }
    }
}
