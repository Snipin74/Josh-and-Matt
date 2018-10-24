using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed; // Movement speed of character
    public float jumpForce; // Jump height of character
    private float horizontal = 0;
    public bool grounded; // Ground check 
    private bool FacingRight = true;
    public LayerMask whatIsGround; // Setting Ground Layer to check
    private Collider2D myCollider; // Player's Collider
    private Rigidbody2D myRidgidBody; // Player's RidgidBody
    private Animator myAnimator; // Calling Animator on Player
    private SpriteRenderer myRenderer;
    private Transform myTransform;
    public bool Attacking = false;
 
    // Use this for initialization
    void Start () {

        myRidgidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        myTransform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        horizontal = Input.GetAxis("Horizontal");

        GetInput();
	}

    void GetInput()
    {

        // Move Right 
        if (Input.GetKey(KeyCode.D))
        {
            myRenderer.flipX = false;
            myRidgidBody.velocity = new Vector2(moveSpeed, myRidgidBody.velocity.y);
            if (!FacingRight)
            {
                Flip();
            }
        }

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            //myRenderer.flipX = true;
            myRidgidBody.velocity = new Vector2(-moveSpeed, myRidgidBody.velocity.y);
            if (FacingRight)
            {
                Flip();
            }       
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                myRidgidBody.velocity = new Vector2(myRidgidBody.velocity.x, jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        // Animator Setting

        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal)); // Moving Animation
        myAnimator.SetBool("Grounded", grounded); // Jump Animation
    }

    void Attack()
    {
        Attacking = false;
        Debug.Log("LClick");
        myAnimator.SetTrigger("Attack");// Attack 1 animation
        myRidgidBody.velocity = new Vector3(0, 0, 0);
    }

    void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        myTransform.localScale = theScale;
    }
}
