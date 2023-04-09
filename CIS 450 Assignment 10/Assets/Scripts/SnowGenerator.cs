using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    public static SnowGenerator instance = null;
    public GameObject snowPrefab;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public SnowPool sp;

    private SnowGenerator()
    {

    }

    public static SnowGenerator getInstance()
    {
        if(instance == null)
        {
            instance = new SnowGenerator();
        }
        return instance;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


    private void Start()
    {
        sp = GetComponent<SnowPool>();
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for(int i = 0; i < sp.poolSize; i++)
        {
            GameObject temp = Instantiate(sp.snowObject);
            objectPool.Enqueue(temp);
        }

        poolDictionary.Add(sp.tag, objectPool);
    }

    private void Awake()
    {
        
    }
}
