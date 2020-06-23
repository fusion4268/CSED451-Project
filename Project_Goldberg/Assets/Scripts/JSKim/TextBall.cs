using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBall : MonoBehaviour
{
    public GameObject text;
    public Color textColor = new Color(200 / 255f, 30 / 255f, 30 / 255f);
    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("coll");
        if (coll.gameObject.tag == "textCollider")
        {
            Debug.Log("Change");
            text.GetComponent<TextMeshPro>().color = textColor;
        }
    }
}
