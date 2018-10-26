using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    //Public Variables
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public Transform generationPoint;
    public GameObject theGround;

    public TheObjectPooler[] theGroundPools;
    //public ObjectPooler[] theObstaclesPools;
    // public ObjectPooler[] thePowerupPools;
    // public ObjectPooler[] theDecorationPools;


    // Private Variables
    private float floorWidth;

    private int groundPicker;
    private int obstaclePicker;
    private int decorationPicker;
    private int powerupPicker;
    private float[] groundWidths;


    public Transform maxHeightPoint;
    public float maxHeightChange;

    private float minHeight;
    private float maxHeight;
    private float heightChange;

    // private CoinGenerator thePumpkinGenerator;
    //public float randomPumpkinThreshold;
    // public float randomHeadstoneThreshold;
    //public float randomDecorationThreshold;
    // public float powerupThreshold;

    // public float powerupHeight;



    // Use this for initialization
    void Start()
    {
        // Get Width by BoxCollider2D Component
        groundWidths = new float[theGroundPools.Length];

        for (int i = 0; i < theGroundPools.Length; i++)
        {
            groundWidths[i] = theGroundPools[i].pooledObj.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        // thePumpkinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Transform Position < GenerationPoint Position
        if (transform.position.x < generationPoint.position.x)
        {
            // Random Space Between Floors
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            groundPicker = Random.Range(0, theGroundPools.Length);
            //obstaclePicker = Random.Range(0, theObstaclesPools.Length);
            //decorationPicker = Random.Range(0, theDecorationPools.Length);
            //powerupPicker = Random.Range(0, thePowerupPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }



            // Ground Spawning Location
            transform.position = new Vector3(transform.position.x + (groundWidths[groundPicker] / 2) + distanceBetween, heightChange, transform.position.z);

            // Object Pool Spawning
            GameObject newGround = theGroundPools[groundPicker].GetPooledObject();
            newGround.transform.position = transform.position;
            newGround.transform.rotation = transform.rotation;
            newGround.SetActive(true);
            if (groundPicker > 5)
            {
                newGround.SetActive(false);
            }

            /*if (Random.Range(0f, 100f) < randomPumpkinThreshold)
            {
               thePumpkinGenerator.spawnPumpkins(new Vector3(transform.position.x, transform.position.y + 1.95f, transform.position.z));
            }
            if (Random.Range(0f, 100f) < randomHeadstoneThreshold)
            {
                GameObject newHeadstone = theObstaclesPools[obstaclePicker].GetPooledObject();

                float headstoneXPosition = Random.Range(-groundWidths[groundPicker] / 2f + 1f, groundWidths[groundPicker] / 2f - 1f);

                Vector3 headstonePosition = new Vector3(headstoneXPosition, 0.5f, 1f);

                newHeadstone.transform.position = transform.position + headstonePosition;
                newHeadstone.transform.rotation = transform.rotation;
                newHeadstone.SetActive(true);

            }
            if (Random.Range(0f, 100f) < randomDecorationThreshold)
            {
                GameObject newDecoration = theDecorationPools[decorationPicker].GetPooledObject();

                float headstoneXPosition = Random.Range(-groundWidths[groundPicker] / 2f + 1f, groundWidths[groundPicker] / 2f - 1f);

                Vector3 headstonePosition = new Vector3(headstoneXPosition, 0.49f, 2f);

                newDecoration.transform.position = transform.position + headstonePosition;
                newDecoration.transform.rotation = transform.rotation;
                newDecoration.SetActive(true);

            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newPowerup = thePowerupPools[powerupPicker].GetPooledObject();

                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range(powerupHeight / 2f, powerupHeight), 0f);

                newPowerup.SetActive(true);
            }
            transform.position = new Vector3(transform.position.x + (groundWidths[groundPicker] / 2), transform.position.y, transform.position.z);*/
        }

    }
}
