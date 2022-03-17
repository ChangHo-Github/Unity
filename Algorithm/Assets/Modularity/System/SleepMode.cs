using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepMode : MonoBehaviour
{
    // ������� �������
    public void NeverSleep()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // �ڵ��� ������� �ð��� ���� ������� ����
    public void SystemSleep()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }
}
