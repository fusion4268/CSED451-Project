using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public bool inWindArea = false;
    public GameObject windArea;
    Vector3 windDirection;
    float windStrength;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inWindArea)
        {
            //rb.AddForce();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            windArea = coll.gameObject;
            inWindArea = true;
            windDirection = windArea.GetComponent<WindArea>().direction;
            windStrength = windArea.GetComponent<WindArea>().strength;
            Debug.Log("Start");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            inWindArea = false;
            Debug.Log("End");
        }
    }

    /*
    private Vector3 WindAmplitude()
    {

        Vector3 amplitude = windDirection * windStrength;
        GetScale(-GetScale(transform.position, windDirection) + GetScale(windArea.transform.position, windDirection), InverseVector(windArea.transform.localScale));
        return amplitude * positionFactor;
    }
    */

    Vector3 GetScale(Vector3 a, Vector3 b)
    {
        return Vector3.Scale(a, b);
    }

    Vector3 InverseVector(Vector3 a)
    {
        return new Vector3(1 / a.x, 1 / a.y, 1 / a.z);
    }
}
