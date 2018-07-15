using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using WebSocketSharp.Server;

public class uWMServer : WebSocketBehavior {

    protected override void OnOpen() {
        while (true) {
            var str = SenderBuffer.pngBinaryb64StrBuffer;
            //Debug.Log(str);
            Send(str);
        }
    }

    protected override void OnMessage(MessageEventArgs e) {
        Debug.Log("Client msg : " + e.Data);
    }

    protected override void OnClose(CloseEventArgs e) {
        Debug.Log("Client Disconnected");
    }
}