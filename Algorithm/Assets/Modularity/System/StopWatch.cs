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
        Debug.Log(sw.Elapsed.ToString() + "ms"); // 나노초까지 전부 반환
        Debug.Log(sw.ElapsedMilliseconds.ToString() + "ms"); // 단기반환
    }
}
