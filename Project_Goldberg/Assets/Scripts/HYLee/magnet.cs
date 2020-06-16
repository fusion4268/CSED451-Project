using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{

    public float magnetStrength = 5f;
    public float distanceS = 10f;
    public int magnetDir = 1;

    private Transform trans;
    private Rigidbody thisRb;
    private Transform magnetTrans;
    private bool magnetZone;
    private Rigidbody magnetRb;

    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
        thisRb = trans.GetComponent<Rigidbody>();
        magnetZone = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (magnetZone) {
            
            float distance = Vector3.Distance(magnetTrans.position, trans.position);
            float strength = (distanceS / distance) + magnetStrength;
            Vector3 direction = magnetTrans.position - trans.position;

            thisRb.AddForce(strength * direction, ForceMode.Force);
            magnetRb.AddForce(strength * (-direction), ForceMode.Force);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "magnetZone") {
            magnetTrans = other.transform;
            magnetZone = true;
            magnetRb = GameObject.Find("magnet").GetComponent<Rigidbody>();
        }
    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "magnetZone")
        {
            magnetZone = false;
        }

    }
}
