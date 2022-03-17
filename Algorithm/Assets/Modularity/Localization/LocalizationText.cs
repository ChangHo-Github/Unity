using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizationText : MonoBehaviour
{
    [SerializeField]
    private string kor, eng;

    private Text text;

    void OnEnable()
    {
        text = GetComponent<Text>();

        Localization();
    }

    public void Localization()
    {
        switch (LocalizationManager.systemLanguage)
        {
            case "Kor":
                text.text = kor;
                break;
            case "Eng":
                text.text = eng;
                break;
        }
    }
}
