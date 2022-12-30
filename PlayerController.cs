using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //I created the Varaibles first, the rigidbody first so the player can move around
    //created the velocity to add movement with the up/down/left/right arrow keys
    //created a movement speed 
    //setup the moveY and moveX

    public Rigidbody2D theRB;
    public float moveSpeed;
    public Animator myAnimator;

    public static PlayerController instance;

    public string areaTransitionName;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;


    void Start()
    {
        //to keep only one player and not more than one when moving from scene to scene
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        //to keep the player so he can move from one area to the next and show up in the new scene
        //its done in the start area since we dont want to declare it every time but just once, if placed in update instead, it would need to be declared each time instead of just being there from...the start...
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        myAnimator.SetFloat("moveX", theRB.velocity.x);
        myAnimator.SetFloat("moveY", theRB.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(1f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-.5f, -.5f, 0f);
    }
}



//mistakes were that i kept doing = instead of == for things with the if/ else statements
