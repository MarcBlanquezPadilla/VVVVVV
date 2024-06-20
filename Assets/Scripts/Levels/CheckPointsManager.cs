using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPointsManager : MonoBehaviour
{
    private GameObject activeCheckPoint;

    [Header("REFERENCED")]
    [SerializeField] GameObject[] CheckPoints;

    public UnityEvent SetCheckPoint;

    public void ActivateCheckPoint(GameObject checkPoint)
    {
        activeCheckPoint = checkPoint;
        DisableCheckPoints();
    }

    private void DisableCheckPoints()
    {
        for (int i = 0; i < CheckPoints.Length; i++)
        {
            if (CheckPoints[i] != activeCheckPoint)
            {
                CheckPoints[i].GetComponent<CheckPointBehaviour>().SetDisabled();
            }
        }
    }

    public Vector3 GetCheckPointPos()
    {
        return activeCheckPoint.transform.position;
    }

    public Vector3 GetFirstCheckPointPos()
    {   
        activeCheckPoint = CheckPoints[0];
        return activeCheckPoint.transform.position;
    }

    public int GetCheckPointNum()
    {
        int CheckPointNum = 0;
        int i = 0;
        bool found = false;
        while (i < CheckPoints.Length || !found)
        {
            if (CheckPoints[i] == activeCheckPoint)
            {
                found = true;
                CheckPointNum = i;
            }
            i++;
        }
        return CheckPointNum;
    }

    public void SetActiveCheckPoint(int num)
    {
        activeCheckPoint = CheckPoints[num];
        CheckPoints[num].GetComponent<CheckPointBehaviour>().SetEnabled();
        DisableCheckPoints();
        SetCheckPoint.Invoke();
    }
}
