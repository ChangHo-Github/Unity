using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTriggerEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	bool clickEnable = false;

	void Update()
	{
		if (clickEnable == true)
		{
			//클릭시 발생하는 이벤트
		}
	}

	// IPointerDownHandler
	public void OnPointerDown(PointerEventData eventData)
	{
		clickEnable = true;
	}

	// IPointerUpHandlder
	public void OnPointerUp(PointerEventData eventData)
	{
		clickEnable = false;
	}
}
