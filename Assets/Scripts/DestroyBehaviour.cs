using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehaviour : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private string FxName;
    
    private ParticleManager _particle;

    private void Awake()
    {
        _particle = GameObject.Find("ParticlesManager").GetComponent<ParticleManager>();
    }

    public void Destroy()
    {
        if (!string.IsNullOrEmpty(FxName))
        {
            _particle.Create(this.transform.position, FxName);
        }
        Destroy(gameObject);
    }

    public void Disable()
    {
        if (!string.IsNullOrEmpty(FxName))
        {
            _particle.Create(this.transform.position, FxName);
        }
        gameObject.SetActive(false);
    }
}
