using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp.Server;

public class ServerMaster : MonoBehaviour {

    private WebSocketServer wssv;

    private void Awake() {
        wssv = new WebSocketServer(8080);   //Create Server on 8080 port
        wssv.AddWebSocketService<uWMServer>("/");

        wssv.Start();
        Debug.Log("Start Server");
    }
}