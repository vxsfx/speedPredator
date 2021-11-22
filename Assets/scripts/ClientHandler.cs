using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandler : MonoBehaviour
{
    //class to handle client input

    Camera camera;
    ServerHandler server;

    uint clientID;

    void connect() {
        camera = Camera.main;
    }


    //jump input
    void checkJump() {
        if (Input.GetButton("Jump")) { 
            //request jump
        }
    }

    //movement
    void checkMovement() {
        //get axis

        //request move
    }

    void checkCrouch() {
        if (Input.GetButton("")) { 
        
        }
    }

    void checkSprint() {
        if (Input.GetButton("")) {
        
        }
    }


}
