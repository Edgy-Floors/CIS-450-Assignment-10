/*
* EJ Flores
* Spawner.cs
* Assignment 10
* This script is the "client" spawner of the object pool.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    SnowGenerator sg;

    private void Start()
    {
        sg = SnowGenerator.instance;
    }

    private void FixedUpdate()
    {
        sg.SpawnFromPool("Snow", transform.position, Quaternion.identity);
    }
}
