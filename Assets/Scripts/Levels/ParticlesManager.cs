using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public string Name;
    public void Create(Vector3 Pos)
    {
        GameObject particle = PoolingManager.Instance.GetPooledObject(Name);
        if (particle != null)
        {
            particle.transform.position = Pos;
            particle.SetActive(true);
        }
    }
}
