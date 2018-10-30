using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed; // Movement speed of character
    public float jumpForce; // Jump height of character
    public bool grounded; // Ground check 
    private bool FacingRight; // Facing Right or not
    public LayerMask whatIsGround; // Setting Ground Layer to check
    private Collider2D myCollider; // Player's Collider
    private Rigidbody2D myRidgidBody; // Player's RidgidBody
    private Animator myAnimator; // Calling Animator on Player
    private Transform myTransform; // Tansform Component
    public bool Attacking = false;
    public bool JumpAttacking = false;
    public static bool isAttacking;
    public LevelManager levelManager;

    public Transform firepoint;
    public GameObject NinjaStar;

    // Use this for initialization
    void Start () {

        FacingRight = true; // Settting bool to true since player starts in game facing right

        // Getting Components

        myRidgidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        levelManager = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); // Layer Check to see if player is grounded or not

        float horizontal = Input.GetAxis("Horizontal"); // Calling Movement Controls

        GetInput();

        
        HandleMovement(horizontal); // Player Movement 
        Flip(horizontal); // Flip Character Left and Right
        ResetValues(); // Reset Values after Use
    }

    private void HandleMovement(float horizontal) // Players Movement on the X Axis and with pre set controls are Left & Right Arrows and A & D
    {
        if(!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) // Makes player not walk during attack
        {
             myRidgidBody.velocity = new Vector2(horizontal * moveSpeed, myRidgidBody.velocity.y); // Movement Speed
        }

        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal)); // Moving Animation
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !FacingRight || horizontal < 0 && FacingRight)
        {
            FacingRight = !FacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            myTransform.localScale = theScale;
        }
    }

    void GetInput()
    {

        // Jump
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.Space)))
        {
            if (grounded)
            {
                myRidgidBody.velocity = new Vector2(myRidgidBody.velocity.x, jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (grounded && !Attacking && !myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                myAnimator.SetTrigger("Attack");// Attack 1 animation
                moveSpeed = 0;
            }

            if (!grounded)
            {
                JumpAttacking = true;
                myRidgidBody.velocity = new Vector3(0, 0, 0);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(NinjaStar, firepoint.position, firepoint.rotation);
        }

            // Animator Setting


            myAnimator.SetBool("Grounded", grounded);// Jump Animation
        myAnimator.SetBool("JumpAttack", JumpAttacking); // Jump Attack animation
    }
  
    void ResetValues()
    {
        JumpAttacking = false;
        moveSpeed = 10;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Attack") || (collision.gameObject.layer == 11) || (collision.tag == "Enemy"))
        {
            //levelManager.RespawnPlayer();
            SceneManager.LoadScene("DeathMenu");
        }
    }
}

