using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    private LauncherBehaviour _launcher;

    [Header("REFERENCED")]
    [SerializeField] private Transform shootPoint;

    [Header("PROPERTIES")]
    [SerializeField] private float firstShootDelay;
    [SerializeField] private float shootTime;

    [Header("INFORMATION")]
    [SerializeField] private Vector3 direction;
    [SerializeField] private float time;

    private void Awake()
    {
        _launcher = GetComponent<LauncherBehaviour>();
        direction = shootPoint.position-transform.position;
        time = shootTime - firstShootDelay;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > shootTime)
        {
            time = 0;
            SoundManager.Instance.PlayAudio("Shoot");
            _launcher.Shoot(direction);
        }
    }


}
