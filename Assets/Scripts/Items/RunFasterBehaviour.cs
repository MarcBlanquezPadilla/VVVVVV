using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFasterBehaviour : BuffBehaviour
{ 
    [Header("PROPERTIES")]
    [SerializeField] private float BuffedSpeed;

    public override void Activate()
    {
        player.GetComponent<MovementBehaviour>().SetVelocity(BuffedSpeed);
        Buff_FX.SetActive(true);
        Buff_FX.transform.SetParent(player.transform);
        Buff_FX.transform.position = player.transform.position;
    }

    public override void Deactivate()
    {
        player.GetComponent<MovementBehaviour>().SetDefaultVelocity();
        Buff_FX.transform.SetParent(this.transform);
        gameObject.SetActive(false);
    }
}
