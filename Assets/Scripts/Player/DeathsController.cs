using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathsController : MonoBehaviour
{
    [Header("INFORMATION")]
    [SerializeField] private int deathCounter;

    [Header("EVENTS")]
    public UnityEvent<int> updateDeaths;

    private void Awake()
    {
        deathCounter = 0;
        updateDeaths.Invoke(deathCounter);
    }

    public void SumDeath()
    {
        deathCounter++;
        updateDeaths.Invoke(deathCounter);
    }

    public int GetDeaths()
    {
        return deathCounter;
    }

    public void SetDeaths(int d)
    {
        deathCounter = d;
        updateDeaths.Invoke(deathCounter);
    }
}
