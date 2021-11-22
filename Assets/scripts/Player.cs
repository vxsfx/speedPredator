using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    public CapsuleCollider collider;

    private float speed = 1.0f;


    //States
    bool grounded; //allows jump


    //methods
    void move(Vector3 dir) {
        rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.z);
    }
    void Jump() {
        rb.AddForce(0, 50, 0);
    }
    void crouch() {
        
    }


    //collisions
    void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("wall")) { 
            //disable Gravity
        }
    }
    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("wall"))
        {
            //allow gravity
        }
    }
}
