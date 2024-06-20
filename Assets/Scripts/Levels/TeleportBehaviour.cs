using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportBehaviour : MonoBehaviour
{
    [Header("EVENTS")]
    public UnityEvent TakeTP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.StopAllAudios();
        SoundManager.Instance.PlayAudio("Win");
        TakeTP.Invoke();
    }
}
