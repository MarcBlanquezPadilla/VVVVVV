using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearPlatform : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sprite;

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _anim.SetInteger("state", 1);
    }

    void RestartAnim()
    {
        _anim.SetInteger("state", 0);
    }
}
