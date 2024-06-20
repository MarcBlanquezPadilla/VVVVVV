using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchesBehaviour : MonoBehaviour
{
    private GameObject cam;

    void Awake()
    {
        cam = GameObject.Find("Main Camera");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }


}
