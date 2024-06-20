using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private MovementBehaviour _move;
    private DestroyBehaviour _destroy;
    private DamageBehaviour _dmg;

    [Header("INFORMATION")]
    Vector3 direction;

    private void Awake()
    {
        _move = GetComponent<MovementBehaviour>();
        _destroy = GetComponent<DestroyBehaviour>();
        _dmg = GetComponent<DamageBehaviour>();
    }

    void Update()
    {
        _move.Move(direction);
    }

    public void Init(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _dmg.SelfDamage();
    }

    private void OnBecameInvisible()
    {
        _dmg.SelfDamage();
    }
}
