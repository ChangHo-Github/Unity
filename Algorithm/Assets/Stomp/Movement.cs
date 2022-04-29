using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float speed = 5.0f;
    private bool isMove = false;

    //private ChatController chat;
    //public InputField inputRegionNo;
    //public InputField inputChannelNo;
    //public InputField inputUserCodeNo;

    //private void Start()
    //{
    //    if (chat == null)
    //        chat = gameObject.AddComponent<ChatController>();
    //}

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0.0f, 0.0f, 1.0f) * speed * Time.deltaTime;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0.0f, 0.0f, 1.0f) * speed * Time.deltaTime;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
            isMove = true;
        }

        if (isMove == true)
        {
            //if (Mgr.Socket._ws.IsAlive == false)
            //{
            //    //chat.UpdateChat("연결이 끊겨있습니다.");
            //    return;
            //}

            //Socket socket = new Socket();

            try
            {
                Debug.Log(tmp._ws.IsAlive);

                tmp.SendMsg(this.transform, "1", "1", "1111");
                //Mgr.Socket.SendMsg(this.transform, inputRegionNo.text, inputChannelNo.text, inputUserCodeNo.text);
            }
            catch (Exception e)
            {
                //chat.UpdateChat(e.Message);
            }

            isMove = false;
        }
    }
}
