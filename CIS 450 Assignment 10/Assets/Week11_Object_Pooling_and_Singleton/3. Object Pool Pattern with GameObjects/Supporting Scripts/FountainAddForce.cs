//Object Pooling Example
//Typed up by Owen Schaffer
//Code for this example from https://www.youtube.com/watch?v=tdSmKaJvCoA

using UnityEngine;
using System.Collections;

//  This class is attached to the prefab that will be instantiated
//  so the object will be launched from its spawn position in
//  a fountain pattern.

// Adding this class attribute requires 
// the GameObject to have a Rigidbody component
// and will attach one if it is missing.
[RequireComponent(typeof(Rigidbody))]
public class FountainAddForce : MonoBehaviour
{
    public float upForce = 1f;
    public float sideForce = .1f;

    private void Start()
    {
        //generate random force
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        //add random force to the RigidBody
        GetComponent<Rigidbody>().velocity = force;
    }


}
