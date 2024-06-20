using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementByPointsBehaviour : MonoBehaviour
{
    private MovementBehaviour _move;

    [Header("REFERENCED")]
    [SerializeField] private Transform[] PointsList;

    [Header("PROPERTIES")]
    [SerializeField] private float stopTime;

    [Header("INFORMATION")]
    [SerializeField] private Vector3 dir;
    [SerializeField] private int initialPoint, nextPoint;
    [SerializeField] private int movementPhase;
    [SerializeField] private float dist;

    [Header("EVENTS")]
    [SerializeField] private UnityEvent<Vector3> Rotate;

    float timer;

    void Awake()
    {
        _move = GetComponent<MovementBehaviour>();

        initialPoint = 0;
        nextPoint = 1;
        movementPhase = 1;
        timer = 0;

        dir = PointsList[nextPoint].position - PointsList[initialPoint].position;
        dir.Normalize();
        Rotate.Invoke(dir);
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, PointsList[nextPoint].position);
        if (dist < 0.01)
        {
            switch (movementPhase)
            {
                case 1:
                    if (nextPoint != PointsList.Length - 1)
                    {
                        initialPoint = nextPoint;
                        nextPoint++;
                        dir = PointsList[nextPoint].position - PointsList[initialPoint].position;
                        dir.Normalize();
                        Rotate.Invoke(dir);
                    }
                    else
                    {
                        timer += Time.deltaTime;
                        if (timer > stopTime)
                        {
                            movementPhase = 2;
                            timer = 0;
                        }
                    }
                    break;

                case 2:
                    if (nextPoint != 0)
                    {
                        initialPoint = nextPoint;
                        nextPoint--;
                        dir = PointsList[nextPoint].position - PointsList[initialPoint].position;
                        dir.Normalize();
                        Rotate.Invoke(dir);
                    }
                    else
                    {
                        timer += Time.deltaTime;
                        if (timer > stopTime)
                        {
                            movementPhase = 1;
                            timer = 0;
                        }
                    }
                    break;
            }
        }
        else
        {
            _move.Move(dir);
        }
    }
}
