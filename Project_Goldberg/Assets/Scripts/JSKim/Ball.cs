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
    Vector3 previousPos;
    private float resistanceFactor = 1f;
    Vector3 velocity;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, 0);
        previousPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = transform.position - previousPos;
        Vector3 windResistance = - GetScale(velocity.normalized,(GetScale(velocity,velocity) / 0.02f)) * resistanceFactor;
        if (inWindArea)
        {
            rb.AddForce(WindAmplitude() + windResistance);
        }
        else
        {
            rb.AddForce(windResistance);
        }
        previousPos = transform.position;
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


    private Vector3 WindAmplitude()
    {
        //mapping to vector field -1/2 ~ 1/2
        Vector3 mapping1 = GetScale((transform.position - windArea.transform.position), InverseVector(windArea.transform.localScale));
        //mapping to vector field 0 ~ 1
        Vector3 mapping2 = mapping1 + GetScale(windDirection, new Vector3(0.5f, 0.5f, 0.5f));
        //mapping to wind function (-x+1)^n
        Vector3 mapping3 = windFunction(mapping2);        
        Vector3 result = GetScale(mapping3, windDirection) * windStrength;
        
        return result;
    }

    Vector3 GetScale(Vector3 a, Vector3 b)
    {
        return Vector3.Scale(a, b);
    }

    Vector3 InverseVector(Vector3 a)
    {
        return new Vector3(1 / a.x, 1 / a.y, 1 / a.z);
    }

    Vector3 windFunction(Vector3 a)
    {
        float x = Mathf.Pow((-a.x + 1),3);
        float y = Mathf.Pow((-a.y + 1), 3);
        float z = Mathf.Pow((-a.y + 1), 3);
        return new Vector3(x, y, z);
    }
}
