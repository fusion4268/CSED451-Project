using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        //Debug.Log(tf.position);
        //Debug.Log(tf.parent.transform.position);
        tf.position = tf.parent.transform.position + new Vector3(3, -6, 0);
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
