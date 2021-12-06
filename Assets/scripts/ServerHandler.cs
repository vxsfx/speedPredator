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
    struct host {
        int playerCount;
        string Address;
    }
    public Dictionary<int, host> hostList;

    
    void addHost(string Address) {
        //id

    }

    string findHost() {
        foreach (host h in hostList) {
            if (h.playerCount < maxPlayers) {
                return h.Address;
            }
        }
        return "none found"
    }

    void Count(int id, int count) {
        hostList[id].playerCount = count;
    }




}
