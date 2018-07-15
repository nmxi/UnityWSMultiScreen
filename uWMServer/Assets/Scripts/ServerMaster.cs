using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp.Server;

public class ServerMaster : MonoBehaviour {

    [SerializeField] private RenderTexture _renderTextureRef;

    private WebSocketServer wss;
    private byte[] _pngBinaryData;

    private void Awake() {
        wss = new WebSocketServer(8080);   //Create Server on 8080 port
        wss.AddWebSocketService<uWMServer>("/");
        wss.Start();
        Debug.Log("Start Server");
    }

    private void Update() {
        Texture2D tex = new Texture2D(_renderTextureRef.width, _renderTextureRef.height, TextureFormat.RGB24, false);
        RenderTexture.active = _renderTextureRef;
        tex.ReadPixels(new Rect(0, 0, _renderTextureRef.width, _renderTextureRef.height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        UnityEngine.Object.Destroy(tex);

        SenderBuffer.pngBinaryb64StrBuffer = Convert.ToBase64String(bytes);

        //Write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
    }
}