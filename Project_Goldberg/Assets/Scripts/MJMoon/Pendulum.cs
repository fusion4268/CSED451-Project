using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Transform tf;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        //Debug.Log(tf.position);
        //Debug.Log(tf.parent.transform.position);
        //tf.position = tf.parent.transform.position + new Vector3(3, -6, 0);
        tf.position = GameObject.Find("PendulumPlane").GetComponent<Transform>().position + new Vector3(-0.5f, 1.5f,0);
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Soccer Ball")
        {
            rb.constraints = 0;
        }
    }
}
