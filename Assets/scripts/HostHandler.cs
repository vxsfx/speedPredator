using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class HostHandler : NetworkManager
{
    List<GameObject> players;
    int id;

    int maxPLayers = 6;
    public static int PlayerCount = 1;

    #region overloads
    //overloaded copy from Network Manager
    public void OnServerAddPLayer(NetworkConnection conn)
    {
        Transform startPos = GetStartPosition();
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";

        NetworkServer.AddPlayerForConnection(conn, player);

        //add append to list
        players.Add(player);

        PlayerCount++;
    }
    public void OnServerDisconnect(NetworkConnection conn)
    {
        NetworkServer.DestroyPlayerForConnection(conn);
        PlayerCount--;
    }
    #endregion



#region commands

    //[Command]
    static public void moveRequest(Vector3 dir, uint id)
    {
        Debug.Log("moved");    
    }

    //[Command]
    static public void jumpRequest(uint id) { }
    
    //[Command]
    static public void crouchRequest(uint id) { }
    #endregion
}
