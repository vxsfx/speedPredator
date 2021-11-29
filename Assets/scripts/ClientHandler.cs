using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandler : MonoBehaviour
{
    //class to handle client input

    Camera camera;
    
    
    public ServerHandler server;

    uint clientID;

    void Start() {
        camera = Camera.main;

    }


    //jump input
    void checkJump() {
        if (Input.GetButton("Jump")) {
            //request jump
            //server.networkAddress = "localhost";

            //server.StartHost();
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

    public void Update()
    {
        checkJump();
    }


}
