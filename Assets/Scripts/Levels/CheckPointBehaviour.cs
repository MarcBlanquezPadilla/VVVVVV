using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour
{
    private CheckPointsManager _cpManager;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _cpManager = GetComponentInParent<CheckPointsManager>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _cpManager.ActivateCheckPoint(gameObject);
        SetEnabled();
    }

    public void SetDisabled()
    {
        _sprite.color = Color.black;
    }

    public void SetEnabled()
    {
        _sprite.color = Color.green;
    }
}
