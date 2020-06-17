using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using UnityEngine;

public class Button : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        mat.color = new Color(1, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ButtonCube")
        {
            mat.color = new Color(0, 0, 1);

            StartCoroutine("ButtonDelay");
        }
    }

    IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject Cannonball = GameObject.Find("Cannonball");
        Rigidbody rb = Cannonball.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(1, .55f, 0)*1000);
    }
}
