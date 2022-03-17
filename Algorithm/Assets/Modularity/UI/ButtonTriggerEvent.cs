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
			//Ŭ���� �߻��ϴ� �̺�Ʈ
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
