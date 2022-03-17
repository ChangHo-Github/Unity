using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    private float distance;
    private WaitForSeconds second;
    private Gyroscope gyro;
    private LocationInfo location;
    private bool gpsEnable = false;
    private float trueHeading; // 지리적 북극을 기준으로 각도를 나타낸다.

    private float targetLatitude;
    private float targetLongitude;

    void Start()
    {
        second = new WaitForSeconds(1.0f);
        Input.compass.enabled = true;
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        if (gyro.gravity.z > 0.1f || gyro.gravity.z < -0.1f)
        {
            if (gyro.gravity.z > 0)
            {
                trueHeading = Input.compass.trueHeading + 180;

                if (trueHeading >= 360f)
                {
                    trueHeading = trueHeading - 360f;
                }
            }
            else
            {
                trueHeading = Input.compass.trueHeading;
            }
        }
    }

    private IEnumerator Action()
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        Input.location.Start(5f, 5f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return second;
            maxWait -= 1;
        }

        if (maxWait < 1)
        {
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;

        }
        else
        {
            location = Input.location.lastData;
            gpsEnable = true;

            while (gpsEnable)
            {
                // GPS만 업데이트
                GPSUpdate();

                // GPS 북쪽기준 사물위치 찾기
                //SearchTargetGPS();

                yield return second;
            }
        }
    }

    private void GPSUpdate()
    {
        location = Input.location.lastData;
    }

    private void SearchTargetGPS()
    {
        location = Input.location.lastData;

        // 임시코드 변수 빼서사용
        float latitude = location.latitude;
        float longitude = location.longitude;
        float radintrueHeading = trueHeading * 0.017f; // 라디안을 곱한 수치

        // 임시 측정값
        if (trueHeading >= 0 && trueHeading < 90f)
        {
            targetLatitude = (float)(latitude + Math.Abs(Math.Cos(radintrueHeading) * distance) * 0.000009f);
            targetLongitude = (float)(longitude + Math.Abs(Math.Sin(radintrueHeading) * distance) * 0.0000115f);
        }
        else if (trueHeading >= 90 && trueHeading < 180f)
        {
            targetLatitude = (float)(latitude - Math.Abs(Math.Cos(3.14f - radintrueHeading) * distance) * 0.000009f);
            targetLongitude = (float)(longitude + Math.Abs(Math.Sin(3.14f - radintrueHeading) * distance) * 0.0000115f);
        }
        else if (trueHeading >= 180 && trueHeading < 270)
        {
            targetLatitude = (float)(latitude - Math.Abs(Math.Cos(radintrueHeading - 3.14f) * distance) * 0.000009f);
            targetLongitude = (float)(longitude - Math.Abs(Math.Sin(radintrueHeading - 3.14f) * distance) * 0.0000115f);
        }
        else
        {
            targetLatitude = (float)(latitude + Math.Abs(Math.Cos(6.28f - radintrueHeading) * distance) * 0.000009f);
            targetLongitude = (float)(longitude - Math.Abs(Math.Sin(6.28f - radintrueHeading) * distance) * 0.0000115f);
        }
    }

    private void GPSStop()
    {
        if (Input.location.isEnabledByUser)
        {
            gpsEnable = false;
            Input.location.Stop();
        }
    }
}
