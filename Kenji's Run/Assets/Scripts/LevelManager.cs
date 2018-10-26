using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        thePlayer.transform.position = currentCheckpoint.transform.position;
    }
}
