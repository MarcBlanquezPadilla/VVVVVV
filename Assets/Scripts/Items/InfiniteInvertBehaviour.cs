using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteInvertBehaviour : BuffBehaviour
{
    public override void Activate()
    {
        player.GetComponent<PlayerBehaviour>().SetInfiniteInvert(true);
        Buff_FX.SetActive(true);
        Buff_FX.transform.SetParent(player.transform);
        Buff_FX.transform.position = player.transform.position;
    }

    public override void Deactivate()
    {
        player.GetComponent<PlayerBehaviour>().SetInfiniteInvert(false);
        Buff_FX.transform.SetParent(this.transform);
        gameObject.SetActive(false);
    }
}
