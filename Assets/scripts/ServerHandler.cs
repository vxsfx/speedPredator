using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerHandler : NetworkManager
{
    //server address
    private const string serverAddress = "localhost";
    //address to main server
    //server stores host addresses//
    public struct host {
        public string Address;
        public int maxPlayers;
    }

    //need Time to hostlist(remove from list when time up)
    public static List<host> hostList;

    public static void addHost(string Address, int maxPlayers) {
        host h;
        h.Address = Address;
        h.maxPlayers = maxPlayers;
        hostList.Add(h);
    }

    
    
}
