using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject sphere;
    public float arrowScale;
    public float rotateScale;
    private bool cameraDynamic = false;
    private Vector3[] cameraPosition = { new Vector3(96, 150, 43), new Vector3(102, 145, 41), new Vector3(102, 145, 28.5f), new Vector3(87, 138, 40), new Vector3(83.5f, 130, 33.5f), new Vector3(73, 130, 34), 
                                        new Vector3(78.67f, 121.831f, 47.879f), new Vector3(85, 102.68f, 22.93f), new Vector3(40.8f, 90.9f, -8.97f),new Vector3(-8.03f, 83.72f, -27.39f),new Vector3(-88.8f, 97.8f, 29.42f),new Vector3(-40.5f, 72.95f, -4.7f), new Vector3(-27.98f, 78.46f, -60.68f),
                                        new Vector3(-4,61,-45), new Vector3(26.5f, 56.8f, -60), new Vector3(50.5f, 42.4f, -53.6f), new Vector3(33.8f, 25.8f, -48), new Vector3(17, 9, -41.2f)};
    private Vector3[] cameraRotation = { new Vector3(5, -10, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0),
                                        new Vector3(0, -90, 0),new Vector3(0, -90, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(20, 130, 0),new Vector3(10, -90, 0),new Vector3(25, 0, 0),
                                        new Vector3(5,0,0),new Vector3(5,0,0),new Vector3(5,0,0),new Vector3(5,0,0),new Vector3(5,0,0)};
    private int cameraIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraPosition[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Static camera
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraDynamic = false;
        }
        //Dynamic camera
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraDynamic = true;
        }

        //Dynamic camera
        if (cameraDynamic)
        {
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
            /*
            if (Input.GetKey(KeyCode.R))
            {
                transform.Rotate(0, 0, -rotateScale);
            }
            */
        }
        //Static camera
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                cameraIndex++;
                if (cameraIndex != cameraPosition.Length)
                {
                    transform.position = cameraPosition[cameraIndex];
                    transform.rotation = Quaternion.Euler(cameraRotation[cameraIndex]);
                }
                else
                {
                    cameraIndex = 0;
                    transform.position = cameraPosition[cameraIndex];
                    transform.rotation = Quaternion.Euler(cameraRotation[cameraIndex]);
                }
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                cameraIndex--;
                if (cameraIndex >= 0)
                {
                    transform.position = cameraPosition[cameraIndex];
                    transform.rotation = Quaternion.Euler(cameraRotation[cameraIndex]);
                }
                else
                {
                    cameraIndex = cameraPosition.Length - 1;
                    transform.position = cameraPosition[cameraIndex];
                    transform.rotation = Quaternion.Euler(cameraRotation[cameraIndex]);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}