using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinScreen : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private DeathsController _deaths;
    [SerializeField] private TimeManager _time;

    [Header("EVENTS")]
    public UnityEvent<int> ShowTime;
    public UnityEvent<int> ShowDeaths;

    public void ChargeWin()
    {
        ShowTime.Invoke(_time.GetTime());
        ShowDeaths.Invoke(_deaths.GetDeaths());
    }
}
