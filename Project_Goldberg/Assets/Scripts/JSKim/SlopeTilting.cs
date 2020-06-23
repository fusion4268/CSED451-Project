using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeTilting : MonoBehaviour
{
   // float smooth = 5.0f;
    public float tiltPerFrame;
    public float tiltAngle;
    private float angle = 0;
    public bool rotate = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        //loat tiltAroundZ = Input.GetAxis("Horizontal") * tiltPerFrame;
        //Quaternion target = Quaternion.Euler(0, 0, tiltPerFrame);
        //Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        //transform.eulerAngles = transform.eulerAngles + new Vector3(tiltPerFrame, 0, 0);
        if (rotate && angle < tiltAngle)
        {
            //if(transform.rotation.eulerAngles.)
            transform.Rotate(-tiltPerFrame, 0, 0);
            angle += tiltPerFrame;
        }
    }
}
