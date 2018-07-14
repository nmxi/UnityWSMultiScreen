using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

/// <summary>
/// multi screenを可能にするコンポーネント
/// </summary>
public class ClientMaster : MonoBehaviour {

    [SerializeField] private SyncPhase _nowPhase;

    [SerializeField] private string _serverAddress;
    [SerializeField] private int _port;

    private WebSocket ws;

    public enum SyncPhase {
        Idling,
        Syncing
    }

    private void Awake() {
        //_nowPhase = SyncPhase.Idling;

        var ca = "ws://" + _serverAddress + ":" + _port.ToString();
        Debug.Log("Connect to " + ca);
        ws = new WebSocket(ca);

        //Add Events
        //On catch message event
        ws.OnMessage += (object sender, MessageEventArgs e) => {
            print(e.Data);
        };

        //On error event
        ws.OnError += (sender, e) => {
            Debug.Log("WebSocket Error Message: " + e.Message);
            _nowPhase = SyncPhase.Idling;
        };

        //On WebSocket close event
        ws.OnClose += (sender, e) => {
            Debug.Log("Disconnected Server");
        };

        ws.Connect();

        ws.Send("Hello");
    }
}
