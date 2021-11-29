using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerHandler : NetworkManager
{
    




    //commmands/requests
    //used to validate user inputs on the server (i.e   if(dir > maxDir){error and disconnect})
    //[Command]
    static public void moveRequest(Vector3 dir, uint id) { 
        
    }//

    //[Command]
    static public void jumpRequest(uint id) { }
    //[Command]
    static public void crouchRequest(uint id) { }


}
