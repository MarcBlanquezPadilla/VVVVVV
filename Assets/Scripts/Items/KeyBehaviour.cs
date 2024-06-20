using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    private KeyManager _keyManager;

    private void Awake()
    {
        _keyManager = GetComponentInParent<KeyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.PlayAudio("TakeKey");
        _keyManager.SumKey(this);
        Disable();
    }
    
    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
