using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class uWMServer : WebSocketBehavior {
    protected override void OnMessage(MessageEventArgs e) {
        Send(e.Data);   //Echo
    }
}