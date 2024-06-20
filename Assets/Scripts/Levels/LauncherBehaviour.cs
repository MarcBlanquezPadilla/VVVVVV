using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherBehaviour : MonoBehaviour
{
    [Header("REFERENCED")]
    public GameObject ShootPoint;
    public string Name;

    public void Shoot(Vector3 direction)
    {
        GameObject bullet = PoolingManager.Instance.GetPooledObject(Name);
        if (bullet != null)
        {
            bullet.transform.position = ShootPoint.transform.position;
            bullet.GetComponent<MovementBehaviour>().RotateVector(direction);
            bullet.SetActive(true);
            bullet.GetComponent<ProjectileBehaviour>().Init(direction);
            bullet.GetComponent<HealthBehaviour>().Healing(1);
        }
    }

}
