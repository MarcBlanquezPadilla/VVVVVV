using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    [Header("PROPERTIES")]
    [SerializeField] private float time;

    [Header("INFORMATION")]
    [SerializeField] private float timer;

    private ParticleSystem _particlesys;

    private void Awake()
    {
        _particlesys = GetComponent<ParticleSystem>();
        _particlesys.Play();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > time)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        _particlesys.Stop();
        _particlesys.Play();
    }

}
