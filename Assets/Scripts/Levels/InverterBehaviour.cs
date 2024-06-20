using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverterBehaviour : MonoBehaviour
{
    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        _anim.SetInteger("state", 1);
        collision.gameObject.GetComponent<GravityBehaviour>().FlipGravity();
    }

    public void RestarAnim()
    {
        _anim.SetInteger("state", 0);
    }
}
