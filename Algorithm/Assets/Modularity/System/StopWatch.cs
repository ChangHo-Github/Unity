using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    void Start()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        // Source code

        sw.Stop();
        Debug.Log(sw.Elapsed.ToString() + "ms"); // �����ʱ��� ���� ��ȯ
        Debug.Log(sw.ElapsedMilliseconds.ToString() + "ms"); // �ܱ��ȯ
    }
}
