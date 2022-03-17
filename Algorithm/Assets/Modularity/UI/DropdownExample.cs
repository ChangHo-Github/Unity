using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownExample : MonoBehaviour
{
    private Dropdown dropdown;
    private Texture2D texture;

    // 옵션추가
    public void AddValue()
    {
        Dropdown.OptionData option = new Dropdown.OptionData();
        option.text = "";
        option.image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        dropdown.options.Add(option);
    }

    // 옵션제거
    public void ClearValue()
    {
        dropdown.options.Clear();
    }

    // 옵션에 이벤트 붙이기
    public void ValueEvent()
    {
        dropdown.onValueChanged.AddListener(delegate { OnValueChangedEvent(dropdown); });
    }

    public void OnValueChangedEvent(Dropdown select)
    {
        int selectNum = select.value;
        string selectString = select.options[select.value].text;
    }
}
