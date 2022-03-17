using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepMode : MonoBehaviour
{
    // 슬립모드 실행안함
    public void NeverSleep()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // 핸드폰 슬립모드 시간에 맞춰 슬립모드 실행
    public void SystemSleep()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }
}
