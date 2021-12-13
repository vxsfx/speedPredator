using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//client ONLY
public class menu : MonoBehaviour
{
    [SerializeField]
    HostHandler hostHandle;

    string address = "localhost";

    public void startClient() {
        hostHandle.networkAddress = address;
        hostHandle.StartClient();
    }
    public void host() {
        hostHandle.networkAddress = address;
        hostHandle.StartHost();
    }
}   
