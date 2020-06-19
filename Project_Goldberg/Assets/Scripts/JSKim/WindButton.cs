using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindButton : MonoBehaviour
{
    public GameObject wind;
    public GameObject pyramid;
    public GameObject arrow;
    float arrowScale = 1.2f;

    private void Start()
    {
        wind.SetActive(false);
    }

    public void arrowLarger()
    {
        arrow.transform.localScale = Vector3.Scale(arrow.transform.localScale, new Vector3(arrowScale, arrowScale, arrowScale));
    }
}
