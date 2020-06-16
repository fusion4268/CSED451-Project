using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour
{
    private float originalx;
    private int cnt;
    private bool cntb;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        originalx = gameObject.transform.position.x;
        cnt = 1000;
        cntb = true;
        time = 1000;
    }



    // Update is called once per frame
    void Update()
    {
        if (cntb) cnt--;
        if (cnt < 0 && time > 0)
        {
            cntb = false;
            time--;
            if (gameObject.transform.position.x == originalx)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else gameObject.transform.position = new Vector3(originalx, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
    }
