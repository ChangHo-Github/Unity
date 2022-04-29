using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class tmp : MonoBehaviour
{
    static public WebSocket _ws;
    static public StompMessageSerializer _serializer;
    //private ChatController chat;

    private void Start()
    {
        //v10.stomp : 고정
        //wss://172.30.1.18:8443/ : 고정
        _ws = new WebSocket("wss://172.30.1.18:8443/ingame-world", "v10.stomp");
        _ws.AddUserHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMDM3MSIsInJvbGUiOiJVU0VSIiwiZXhwIjoxNjUwNjg2ODMyfQ.GBK-gZLEJNi3gJr_tqR1kosnKYz2SmQxcJiot89UGKk");
        //프로토콜 설정
        _ws.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
        _ws.Log.Level = LogLevel.Debug;

        _ws.OnMessage += OnMessage;
        _ws.OnClose += OnClose;

        //서버 연결하기
        _ws.Connect();

        //현재 연결중인지 확인하기
        Debug.Log(_ws.IsAlive);
    }

    private void OnClose(object sender, CloseEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        throw new NotImplementedException();
    }

    //서버로 데이터 전송할 함수
    static public void SendMsg(Transform tr, string regionNo, string channelNo, string userCodeNo)
    {
        //보내기
        if (_serializer == null)
            _serializer = new StompMessageSerializer();

        UserLocation userLocation = new UserLocation(10, (int)tr.position.x, (int)tr.position.y, (int)tr.position.z, (int)tr.rotation.y, 0);
        SendMessage sendMessage = new SendMessage("LOCATION", regionNo, channelNo, userCodeNo, "", "", "", userLocation);

        string json = JsonConvert.SerializeObject(sendMessage);

        //json 확인
        Debug.Log(json);

        var broad = new StompMessage(StompFrame.SEND, json);
        //destination : 고정
        //pub/channel/message : 메시지가 가는 경로
        broad["destination"] = "/pub/channel/message";
        _ws.Send(_serializer.Serialize(broad));
    }
}
