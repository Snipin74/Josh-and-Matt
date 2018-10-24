using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Public Variables
    public PlayerController thePlayer; // Player Controller


    // Private Variables
    private Vector3 lastPlayerPosition; // Players last postion
    private float distanceToMove; // Distance to move Camera

	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<PlayerController>(); // Get Player Controller Script;
        lastPlayerPosition = thePlayer.transform.position; // Players Starting Position
	}
	
	// Update is called once per frame
	void Update () {

        // Distance to move camrea when player moves
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = thePlayer.transform.position;

	}
}
