/*
* EJ Flores
* SnowGenerator.cs
* Assignment 10
* The SnowGenerator script takes in a reference to a specific pool, in this case the snow pool. It creates a pool of inactive GameObjects based on the tag supplied, and it handles
* its Singleton functionality.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    public static SnowGenerator instance = null;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public SnowPool sp;

    private SnowGenerator()
    {

    }

    private void Awake()
    {
        getInstance();
    }

    public SnowGenerator getInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
        return instance;
    }

    private void Start()
    {
        sp = gameObject.GetComponent<SnowPool>();
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for(int i = 0; i < sp.poolSize; i++)
        {
            GameObject temp = Instantiate(sp.snowObject);
            temp.SetActive(false);
            objectPool.Enqueue(temp);
        }

        poolDictionary.Add(sp.tag, objectPool);
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
