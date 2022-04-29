using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using WebSocketSharp;

[Serializable]
public struct Message
{
    public Transform transform;
    public string regionNo;
    public string channelNo;
    public string userCodeNo;
}

[Serializable]
public struct ReceiveData
{
    public string type;
    public string regionNo;
    public string channelNo;
    public string userCodeNo;
    public string sender;
    public string message;
    public Location userLocation;

    [Serializable]
    public struct Location
    {
        public string userLocationNo;
        public string userPosX;
        public string userPosY;
        public string userPosZ;
        public string userRotY;
        public string motionStatus;
    }
}

// TestID : test1user / TestPassword : test1user
// 애월 1;
// 채널 1;
public class MetaLiveNetwork : MonoBehaviour
{
    [SerializeField]
    private Text debug;

    private ReceiveData receivce;

    [SerializeField]
    private GameObject obj;
    private WebSocket ws;
    private StompMessageSerializer _serializer = new StompMessageSerializer();

    void Start()
    {
        ws = new WebSocket("wss://172.30.1.18:8443/ingame-world", "v10.stomp");
        ws.AddUserHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMDQwNCIsInJvbGUiOiJVU0VSIiwiZXhwIjoxNjUxMTA2Njg3fQ.P8ZMNrlYqwNdB9SINTFt2aWBT1SdS7hBIKHB8wDuUiM");
        ws.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
        ws.OnOpen += (o, e) =>
        {
            Debug.Log(e);
        };
        ws.OnClose += (o, e) =>
        {
            Debug.Log(e);
        };
        ws.OnMessage += (o, e) =>
        {
            Debug.Log(e.Data);
            StompMessage message = _serializer.Deserialize(e.Data);
            Debug.Log(message.Headers);
            Debug.Log(message.Body);
        };

        ws.OnError += (o, e) =>
        {
            Debug.Log(e.Exception);
        };
        ws.Connect();
        Thread.Sleep(1000);
        var connect = new StompMessage("CONNECT");
        connect["accept-version"] = "1.1";
        connect["host"] = "";
        ws.Send(_serializer.Serialize(connect));

        Thread.Sleep(1000);
        var sub = new StompMessage("SUBSCRIBE");
        sub["id"] = "1-1";
        sub["destination"] = "/sub/world/channel/1-1";
        ws.Send(_serializer.Serialize(sub));
    }

    public void Send(string data)
    {
        receivce = JsonConvert.DeserializeObject<ReceiveData>(data);
        Debug.Log(receivce);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMsg(obj.transform, "1", "1", "1111");
            Debug.Log("1");
        }
    }

    private void SendMsg(Transform tr, string regionNo, string channelNo, string userCodeNo)
    {
        //보내기
        if (_serializer == null)
            _serializer = new StompMessageSerializer();

        UserLocation userLocation = new UserLocation(10, (int)tr.position.x, (int)tr.position.y, (int)tr.position.z, (int)tr.rotation.y, 0);
        SendMessage sendMessage = new SendMessage("LOCATION", regionNo, channelNo, userCodeNo, "", "", "", userLocation);

        string json = JsonConvert.SerializeObject(sendMessage);

        var broad = new StompMessage(StompFrame.SEND, json);
        //destination : 고정
        //pub/channel/message : 메시지가 가는 경로               
        broad["destination"] = "/pub/channel/message";        
        ws.Send(_serializer.Serialize(broad));
    }

    private void OnOpen(object sender, CloseEventArgs e)
    {
        Debug.Log(e);
    }

    private void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log(e);
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e);
    }
}
