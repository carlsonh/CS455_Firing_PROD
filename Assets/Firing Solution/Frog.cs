using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ///////All code from bslease
/// https://github.com/bslease/Dynamic_Steering
/// https://github.com/bslease/Dynamic_Steering/blob/master/Dynamic%20Steering%20Basics/Assets/Scripts/FiringSolution.cs
/// </summary>

public class Frog : MonoBehaviour
{
    public float myTimeScale = 1.0f;
    public GameObject target;
    public float launchForce = 10f;

    public bool bUseAltTime = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Throw", UnityEngine.Random.Range(0f,4f), 5f);
    }
    void Throw()
    {
        Time.timeScale = myTimeScale; // allow for slowing time to see what's happening
        rb = GetComponent<Rigidbody>();

        Firing_Solution fs = new Firing_Solution();
        fs.bUseAltTime = bUseAltTime;
        Nullable<Vector3> aimVector = fs.Calculate(transform.position, target.transform.position, launchForce, Physics.gravity);
        if (aimVector.HasValue)
        {
            rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
        }
        else
        {
            launchForce +=2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}