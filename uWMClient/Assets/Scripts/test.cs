using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    [SerializeField] private Material _testMat;

    // Update is called once per frame
    void Update () {
        byte[] data = System.Convert.FromBase64String(ReceiveBuffer.strBuffer);
        var tex = new Texture2D(1920, 1080);
        tex.LoadImage(data);
        _testMat.mainTexture = tex;
    }
}
