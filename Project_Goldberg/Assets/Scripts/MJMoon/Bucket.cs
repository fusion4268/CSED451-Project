using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bucket : MonoBehaviour
{
    const int FULLCOLLISION = 127;      //0111 1111
    const int COLLISION_RED = 64;       //0100 0000
    const int COLLISION_ORANGE = 32;    //0010 0000
    const int COLLISION_YELLOW = 16;    //0001 0000
    const int COLLISION_GREEN = 8;      //0000 1000
    const int COLLISION_BLUE = 4;       //0000 0100
    const int COLLISION_NAVY = 2;       //0000 0010
    const int COLLISION_PURPLE = 1;     //0000 0001

    Rigidbody rb;
    public int collisionCount = 0;
    bool istriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere_red")
            collisionCount |= COLLISION_RED;
        else if (collision.gameObject.name == "Sphere_orange")
            collisionCount |= COLLISION_ORANGE;
        else if (collision.gameObject.name == "Sphere_yellow")
            collisionCount |= COLLISION_YELLOW;
        else if (collision.gameObject.name == "Sphere_green")
            collisionCount |= COLLISION_GREEN;
        else if (collision.gameObject.name == "Sphere_blue")
            collisionCount |= COLLISION_BLUE;
        else if (collision.gameObject.name == "Sphere_navy")
            collisionCount |= COLLISION_NAVY;
        else if (collision.gameObject.name == "Sphere_purple")
            collisionCount |= COLLISION_PURPLE;

        if ((collisionCount == FULLCOLLISION) && !istriggered)
        {
            StartCoroutine("BucketDelay");
            istriggered = true;

            GameObject soccerBall = GameObject.Find("Soccer Ball");
            Rigidbody rb_soccerBall = soccerBall.GetComponent<Rigidbody>();
            rb_soccerBall.constraints = 0;
        }
    }

    IEnumerator BucketDelay()
    {
        yield return new WaitForSeconds(2.0f);

        GameObject breakpoint = GameObject.Find("Cylinder (6)_breakpoint");
        Rigidbody rb_breakpoint = breakpoint.GetComponent<Rigidbody>();
        rb_breakpoint.AddForce(new Vector3(0, 0, 1.0f) * 5000);

        breakpoint = GameObject.Find("Cylinder (11)_breakpoint");
        rb_breakpoint = breakpoint.GetComponent<Rigidbody>();
        rb_breakpoint.AddForce(new Vector3(0, -1.0f, 0) * 2000);
    }
}
