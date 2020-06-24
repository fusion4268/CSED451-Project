using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject sphere;
    public float arrowScale;
    public float rotateScale;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Sphere Tracking
        //transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y+3, transform.position.z);
        //Vector3.ler
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(new Vector3(0, arrowScale, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(new Vector3(0, -arrowScale, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(new Vector3(-arrowScale, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(new Vector3(arrowScale, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.TransformDirection(new Vector3(0, 0, -arrowScale));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.TransformDirection(new Vector3(0, 0, arrowScale));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotateScale, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotateScale, 0);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(0, 0, -rotateScale);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}