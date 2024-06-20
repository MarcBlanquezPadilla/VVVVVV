using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private FlipBehaviour _flip;

    [Header("PROPERTIES")]
    [SerializeField] private float DefaultGravity;

    private void Awake()
    {
        _flip = GetComponent<FlipBehaviour>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = DefaultGravity;
    }

    public void FlipGravity()
    {
        _flip.FlipY();
        _rb.gravityScale *= -1;
        _rb.velocity = new Vector2 (_rb.velocity.x, 0);
        SoundManager.Instance.PlayAudio("InvertGravity");
    }

    public void SetGravity(int value)
    {
        _rb.gravityScale = value;
    }

    public void SetDefaultGravity()
    {
        if (_rb.gravityScale < 0)
        {
            _flip.FlipY();
            _rb.gravityScale = DefaultGravity;
        }
    }
}
