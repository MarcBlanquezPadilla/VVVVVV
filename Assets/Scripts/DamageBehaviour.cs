using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    private HealthBehaviour _health;

    [Header("PROPERTIES")]
    [SerializeField] private int damage;

    private void Awake()
    {
        _health = GetComponent<HealthBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthBehaviour>(out HealthBehaviour _playerhealth))
        {
            _playerhealth.Hurt(damage);
        }
    }

    public void SelfDamage()
    {
        _health.Hurt(1);
    }
}
