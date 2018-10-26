using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform EdgeCheck;
    private Rigidbody2D myRidgidBody; // Player's RidgidBody



    // Use this for initialization
    void Start () {

        myRidgidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        notAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-0.64f, 0.5f, transform.localScale.z);
            myRidgidBody.velocity = new Vector2(moveSpeed, myRidgidBody.velocity.y);

        } else
        {
            transform.localScale = new Vector3(0.64f, 0.5f, transform.localScale.z);
            myRidgidBody.velocity = new Vector2(-moveSpeed, myRidgidBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Sword"))
        {
            Destroy(gameObject);
        }
    }
}
