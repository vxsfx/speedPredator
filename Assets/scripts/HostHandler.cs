using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class HostHandler : NetworkManager
{
    //need initialise???>
    public static List<Player> players = new List<Player>();
    int id;

    uint maxPLayers = 6;
    public static int PlayerCount = 0;


    //overloaded
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform startPos = GetStartPosition();
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        players.Add(player.GetComponent<Player>());
        PlayerCount++;

        Debug.Log("player added");
        Debug.Log(PlayerCount);
        NetworkServer.AddPlayerForConnection(conn, player);
    }


    #region commands

    //[Command]
    static public void moveRequest(int id, Vector3 dir)
    {
        
        Debug.Log("move");
        Debug.Log(id);

        players[id].move(dir);
    }

    //[Command]
    static public void jumpRequest(int id) {
        Debug.Log("jumpR");
    }
    
    //[Command]
    static public void crouchRequest(int id) {
        Debug.Log("crouchR");
    }

    static public void setSpeed(int id, float speed) {
        Debug.Log("speed");
        players[id].setSpeed(speed);
    }
    static public void setRotation(int id, float x, float y) {
        Debug.Log("rot");
        players[id].setRotation(x, y);
    }
    #endregion
}
