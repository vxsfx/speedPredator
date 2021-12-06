using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//server ONLY
public class Player : MonoBehaviour
{
    #region Components
    [SerializeField]
    private Rigidbody rb;
    #endregion


    private float speed = 1.0f;

    #region States
    bool grounded; //allows jump

    //state ++
    enum PlayerState {
        idle,
        walk,
        sprint,

        jump,
        crouch,
        slide,

        wallidle,
        wallwalk,
        wallrun,

    }

    PlayerState state;
    #endregion

    #region Methods
    #region clientcall
    //methods called when client request validated

    //call last as needs last check
    void jump() {
        if (grounded) {
            rb.AddForce(0, 50, 0);
            state = PlayerState.jump;
        }
    }
    //called 3rd
    void sprint() {
        if (state == PlayerState.walk)
        {
            speed = 2.0f;
            state = PlayerState.sprint;
        }
    }
    //called 4th
    void crouch() {
        if (state == PlayerState.sprint)
        {
            state = PlayerState.slide;
        }
        else {
            state = PlayerState.crouch;
        }
    }
    //always called (client default sends 0,0,0)
    //called 2nd
    void move(Vector3 dir) {
        rb.velocity = new Vector3(dir.x * speed * Time.deltaTime, rb.velocity.y, dir.z * speed * Time.deltaTime);
        if ((state == PlayerState.walk || state == PlayerState.sprint) && dir.magnitude == 0) {
            state = PlayerState.idle;
        }
    }
    #endregion

    void Update()
    {
        if (!grounded)
        {
            state = PlayerState.jump;
        }

    }


    #region Collsiions
    void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("wall")) { 
            //when players stays on wall
            
            //disable Gravity
        }
    }
    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("wall"))
        {
            //when player jumps of wall

            //allow gravity
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //when player tags another
        if (CompareTag("blue") && other.gameObject.CompareTag("red")) {
            //caught = true;
            tag = "red";
            //swap colours

            //redScore++
        }
    }
    #endregion
    #endregion
}
