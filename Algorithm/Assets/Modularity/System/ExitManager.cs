using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    private float timer = 0f;
    private bool timerEnable = false;
    private int click = 0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR_WIN
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
            timerEnable = true;
            click++;
#endif
        }

        if(timerEnable == true)
        {
            timer += Time.deltaTime;

            if(click == 2 && timer <= 2f)
            {
                Application.Quit();
            }

            if(click == 2 && timer > 2f)
            {
                click = 1;
                timer = 0;
            }
        }
    }
}
