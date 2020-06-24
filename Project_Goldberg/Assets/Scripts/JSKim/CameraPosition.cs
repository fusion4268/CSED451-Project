using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject sphere;
    public float arrowScale = 0.025f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Sphere Tracking
        //transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y+3, transform.position.z);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, arrowScale, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -arrowScale, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-arrowScale, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(arrowScale, 0, 0);
        }
        if (Input.GetKey(KeyCode.Keypad0))
        {
            transform.position += new Vector3(0, 0, -arrowScale);
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            transform.position += new Vector3(0, 0, arrowScale);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}