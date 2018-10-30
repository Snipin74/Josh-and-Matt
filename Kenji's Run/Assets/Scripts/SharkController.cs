using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {

    // [SerializeField] private float speed;

    //public Transform target;
    // public Transform target1;

    public LayerMask enemyMask;
    public float speed;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

    // Use this for initialization
    void Start () {

        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //check for the ground infront of the shark
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }
        //always move forward 
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
}
