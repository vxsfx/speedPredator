using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror.Discovery;

//client ONLY
public class menu : NetworkDiscovery
{
    ServerHandler server;
    
    public void startHost() {
        server.StartHost();
        //POST Address to server
    }

    //discoveredServers;
    public void findGame() {
        //server.findServer();
        //manager.StartDiscovery();
    }


}
