using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour {

    public float starSpeed;
    public float rotationSpeed;

    public PlayerController thePlayer;

    private Rigidbody2D starRidgidBody; // Player's RidgidBody

    // Use this for initialization
    void Start () {

        thePlayer = FindObjectOfType<PlayerController>();
        starRidgidBody = GetComponent<Rigidbody2D>();
    

        if(thePlayer.transform.localScale.x < 0)
        {
            starSpeed = -starSpeed;
            rotationSpeed = -rotationSpeed;
        }
    }
	
	// Update is called once per frame
	void Update () {

        starRidgidBody.velocity = new Vector2(starSpeed, starRidgidBody.velocity.y);

        starRidgidBody.angularVelocity = rotationSpeed;

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
