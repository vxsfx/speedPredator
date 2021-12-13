using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandler : MonoBehaviour
{
    //class to handle client input
    private int clientID;

    void Start() {
        //am working
        clientID = HostHandler.PlayerCount;
    }

    //jump input
    void checkJump() {
        if (Input.GetButton("Jump")) {
            
        }
    }

    //movement
    void checkMovement() {
        Vector3 dir = new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
        HostHandler.moveRequest(clientID, dir);
    }

    void checkCrouch() {
        if (Input.GetButton("Crouch")) {
            HostHandler.crouchRequest(clientID);
        }
    }

    void checkSprint() {
        Debug.Log(clientID);
        if (Input.GetButton("Sprint"))
        {
            HostHandler.setSpeed(clientID, 1.5f);
        }
        else {
            HostHandler.setSpeed(clientID, 1.0f);
        }
    }

    void checkCamera() {
        HostHandler.setRotation(clientID, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    void Update()
    {
        checkCamera();
        checkJump();
        checkSprint();
        checkMovement();
        checkCrouch();
    }


}
