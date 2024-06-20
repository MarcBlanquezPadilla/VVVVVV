using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensNavigation : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private Transform mainPoint;
    [SerializeField] private Transform optionsPoint;
    [SerializeField] private Transform loadGamePoint;
    [SerializeField] private Transform newGamePoint;

    [Header("INFORMATION")]
    [SerializeField] private bool move;
    [SerializeField] private float timeMoving;
    [SerializeField] Transform pointToGo;
    [SerializeField] Transform initialPoint;

    private void Awake()
    {
        move = false;
    }

    private void Update()
    {
        if (move)
        {
            timeMoving += Time.unscaledDeltaTime;
            transform.position = Vector3.Lerp(initialPoint.position, pointToGo.position, timeMoving);
            if (transform.position == pointToGo.position)
            {
                move = false;
            }
        }
        
    }

    public void ReturnMain()
    {
        
        pointToGo = mainPoint;
        RestarMovement();
    }

    public void GoOptions()
    {
        pointToGo = optionsPoint;
        RestarMovement();
    }

    public void GoLoadGame()
    {
        pointToGo = loadGamePoint;
        RestarMovement();
    }

    public void GoNewGame()
    {
        pointToGo = newGamePoint;
        RestarMovement();
    }
    private void RestarMovement()
    {
        initialPoint = transform;
        timeMoving = 0;
        move = true;
    }
}
