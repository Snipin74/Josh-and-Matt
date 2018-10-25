using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Enemy"))
        {
            PlayerController.isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Enemy"))
        {
            PlayerController.isAttacking = false;
        }
    }

    // Use this for initialization
    void Start () {

        PlayerController.isAttacking = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
