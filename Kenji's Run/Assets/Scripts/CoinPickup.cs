using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int pointsToGive;

    private ScoreManager scoreHandler;

    //private AudioSource coinSound;



    // Use this for initialization
    void Start()
    {

        scoreHandler = FindObjectOfType<ScoreManager>();
        //coinSound = GameObject.Find("Coin").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            scoreHandler.AddPoints(pointsToGive);
            gameObject.SetActive(false);

            //if (coinSound.isPlaying)
           // {
               // coinSound.Stop();
               // coinSound.Play();
           // }
           // else
           // {
               // coinSound.Play();
           // }
        }
    }
}
