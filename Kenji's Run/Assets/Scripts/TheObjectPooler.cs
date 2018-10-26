using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheObjectPooler : MonoBehaviour {

    // Public Variables
    public GameObject pooledObj;
    public int pooledAmt;

    // GameObject List
    List<GameObject> pooledObjects;

    // Use this for initialization
    void Start()
    {

        pooledObjects = new List<GameObject>();

        for (int i = 0; i > pooledAmt; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObj);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
