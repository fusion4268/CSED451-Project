using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ball7")
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;


            GameObject Spheres = GameObject.Find("Spheres");
            for(int i=0; i < Spheres.transform.childCount; i++)
            {
                rb = Spheres.transform.GetChild(i).GetComponent<Rigidbody>();
                rb.constraints = 0;
            }
        }
    }
}
