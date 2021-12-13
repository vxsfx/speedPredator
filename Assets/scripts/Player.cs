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

    [SerializeField]
    private Transform camerapos;


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
    public void sprint() {
        if (state == PlayerState.walk)
        {
            speed = 2.0f;
            state = PlayerState.sprint;
        }
    }
    //called 4th
    public void crouch() {
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
    public void move(Vector3 dir) {
        rb.velocity = new Vector3(dir.x * speed * Time.deltaTime, rb.velocity.y, dir.z * speed * Time.deltaTime);
        if ((state == PlayerState.walk || state == PlayerState.sprint) && dir.magnitude == 0) {
            state = PlayerState.idle;
        }
    }

    public void setSpeed(float speed) {
        if (!grounded) {
            return;
        }
        this.speed = speed;
    }

    public void setRotation(float x, float y) {
        camerapos.rotation = Quaternion.Euler(x, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, y, 0.0f);
    }
    #endregion

    void Update()
    {
        if (!grounded)
        {
            state = PlayerState.jump;
        }

    }

    private void Start()
    {
        Camera.main.transform.position = camerapos.position;
        Camera.main.transform.parent = camerapos;
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
