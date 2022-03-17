using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARAnchor : MonoBehaviour
{
	[SerializeField]
	private Transform pivot;
	[SerializeField]
	private ARRaycastManager arRaycastManager;
	private List<ARRaycastHit> hits = new List<ARRaycastHit>();
	private Vector3 center;

	void Start()
	{
		center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
	}

	void Update()
	{
		if (arRaycastManager.Raycast(center, hits, TrackableType.PlaneWithinPolygon))
		{
			Pose pose = hits[0].pose;
			float distance = hits[0].distance;
			pivot.localScale = new Vector3(distance, distance, distance);
			pivot.position = Vector3.Lerp(pivot.position, pose.position, 0.2f);
			pivot.rotation = Quaternion.Lerp(pivot.rotation, pose.rotation, 0.2f);
		}
	}
}
