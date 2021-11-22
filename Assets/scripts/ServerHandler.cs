using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHandler : MonoBehaviour
{
    //class to handle movement requests from clients, and game states to sync to clients


    //game States
    //-- lock player positions and count down
    //end-- fade
    enum gameState {
        starting,
        ongoing,
        end,
        chaserWin,
        chaserLose
    };
    uint caught = 0;

    //all players
    private List<GameObject> players;



    //commmands/requests
    //used to validate user inputs on the server (i.e   if(dir > maxDir){error and disconnect})
    public void moveRequest(Vector3 dir, uint id) { }//
    public void jumpRequest(uint id) { }
    public void crouchRequest(uint id) { }


}
