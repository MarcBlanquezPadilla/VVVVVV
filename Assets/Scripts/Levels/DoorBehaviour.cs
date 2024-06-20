using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorBehaviour : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private TextMeshPro _text;

    private void Awake()
    {
        _text.enabled = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _text.enabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _text.enabled = false;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
