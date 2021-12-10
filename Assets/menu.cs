using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//client ONLY
public class menu : MonoBehaviour
{
    [SerializeField]
    HostHandler host;

    [SerializeField]
    ServerHandler server;

    public void startHost() {

        server.StartClient();
        //get Address
        string Address = "localhost";

        ServerHandler.addHost(Address, 6);
        server.StopClient();

        host.StartHost();   
    }

    //discoveredServers;
    public void findGame() {
        foreach (ServerHandler.host h in ServerHandler.hostList)
        {
            host.networkAddress = h.Address;
            host.StartClient();
            if (HostHandler.PlayerCount < h.maxPlayers)
            {
                return;
            }
            host.StopClient();
        }
    }
}   
