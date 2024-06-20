using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public void Create(Vector3 Pos, string Name)
    {
        GameObject particle = PoolingManager.Instance.GetPooledObject(Name);
        if (particle != null)
        {
            particle.transform.position = Pos;
            particle.SetActive(true);
            particle.GetComponent<BulletParticle>().Restart();
        }
    }
}
