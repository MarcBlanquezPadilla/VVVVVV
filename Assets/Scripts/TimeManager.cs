using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [Header("INFORMATION")]
    [SerializeField] private float time;
    [SerializeField] public static bool paused;

    [Header("EVENTS")]
    public UnityEvent<int> UpdateTime;

    private void Awake()
    {
        Time.timeScale = 1;
        paused = false;
    }

    private void Update()
    {
        if (!paused)
        {
            int nextTime = (int)time;
            time += Time.unscaledDeltaTime;
            if (nextTime < time)
            {
                UpdateTime.Invoke((int)time);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        paused = false;
    }

    public int GetTime()
    {
        return (int)time;
    }

    public void SetTime(int t)
    {
        time = t;
        UpdateTime.Invoke((int)time);
    }
}
