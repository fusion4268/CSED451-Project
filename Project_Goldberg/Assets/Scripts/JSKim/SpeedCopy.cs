using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCopy : MonoBehaviour
{
    public GameObject windToCopy;
    public GameObject arrow;
    private WindArea copyArea;
    private WindArea myArea;
    private float arrowScale = 1.1f;
    float prevStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        copyArea = windToCopy.GetComponent<WindArea>();
        myArea = gameObject.GetComponent<WindArea>();
        prevStrength = myArea.strength;
    }

    // Update is called once per frame
    void Update()
    {
        if (myArea.strength != copyArea.strength)
        {
            myArea.strength = copyArea.strength;
            arrow.transform.localScale = Vector3.Scale(arrow.transform.localScale, new Vector3(arrowScale, arrowScale, arrowScale));
        }
    }

    
}
