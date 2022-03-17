using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class AndroidVersionCheck : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Action());
    }

    IEnumerator Action()
    {
        string url = "https://play.google.com/store/apps/details?id={PackageName}";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success)
            {

            }
            else
            {
                string pattern = @"<span class=""htlgb"">[0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}<";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                Match match = regex.Match(request.downloadHandler.text);

                match = Regex.Match(match.Value, "[0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}");
                string version = match.ToString();
            }
        }
    }
}
