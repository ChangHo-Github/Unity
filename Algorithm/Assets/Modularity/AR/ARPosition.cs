using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPosition : MonoBehaviour
{
    void Update()
    {
        Transform cameraTransform = Camera.main.transform;
        transform.position = cameraTransform.position + new Vector3(0, 0.25f, 0) + cameraTransform.forward * 1;
        transform.rotation = cameraTransform.rotation;
    }

    // AR카메라 시점에서 적용하기
    public void TargetInstantiate()
    {
        GameObject target = new GameObject();
        target.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * 1) + (Vector3.up * 0.25f);
        target.transform.rotation = Camera.main.transform.rotation;
        target.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }
}
