using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleZombieController : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform EdgeCheck;
    private Rigidbody2D myRidgidBody; // Player's RidgidBody
    private Animator myAnimator;

    public static bool IsAttacking = false;
    public GameObject ninjaStar;
    public SpriteRenderer sr;

    // Player Chasing AI

    private Transform myPlayer;
    public float stopDistance;


    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        myRidgidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, myPlayer.position) < stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, myPlayer.position, moveSpeed * Time.deltaTime);
            myAnimator.SetFloat("Speed", moveSpeed);


            sr.flipX = (myPlayer.transform.position.x < transform.position.x) ? true : false;
            //if (myPlayer.transform.position.x < transform.position.x)
            //{
            //    sr.flipX = true;
            //} else
            //{
            //    sr.flipX = false;

            //}
        }


       /* hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        notAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-0.64f, 0.5f, transform.localScale.z);
            myRidgidBody.velocity = new Vector2(moveSpeed, myRidgidBody.velocity.y);

        }
        else
        {
            transform.localScale = new Vector3(0.64f, 0.5f, transform.localScale.z);
            myRidgidBody.velocity = new Vector2(-moveSpeed, myRidgidBody.velocity.y);
        }

        if (IsAttacking)
        {
            myAnimator.SetBool("Attack", true);
            myRidgidBody.velocity = Vector2.zero;
        }
        else
            myAnimator.SetBool("Attack", false);*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            Destroy(gameObject);
        }

        if( collision.tag == "Ninja Star")
        {
            Destroy(gameObject);
        } 
    } 
}