using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using WebSocketSharp;

public class NetworkManager : MonoBehaviour
{
    private string address = "ws://dev.auth.awesomeserver.kr/ingame-world:8443";

    private WebSocket webSocket;

    void Start()
    {
        webSocket = new WebSocket(address);
        webSocket.Connect();
        webSocket.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
        };

        webSocket.OnOpen += (sender, e) =>
        {
            Debug.Log("Server open");
        };

        webSocket.OnClose += (sender, e) =>
        {
            Debug.Log("Server close");
        };
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            webSocket.Send("Hello");
        }
    }

    public void Connect()
    {
        try
        {
            if (webSocket == null || !webSocket.IsAlive)
                webSocket.Connect();
        }
        catch
        {

        }
    }

    public void DisConnect()
    {
        try
        {
            if (webSocket == null)
                return;

            if (webSocket.IsAlive)
                webSocket.Close();
        }
        catch
        {

        }
    }

    
}
