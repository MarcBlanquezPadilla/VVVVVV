using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehaviour : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private GameObject objectToHide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectToHide.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectToHide.SetActive(true);
    }
}
