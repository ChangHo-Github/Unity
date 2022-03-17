using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static string systemLanguage;

    public void Localization(string language)
    {
        systemLanguage = language;

        foreach (LocalizationText localization in FindObjectsOfType<LocalizationText>())
        {
            localization.Localization();
        }
    }
}
