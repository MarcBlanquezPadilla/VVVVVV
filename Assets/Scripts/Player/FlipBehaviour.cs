using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBehaviour : MonoBehaviour
{
    bool rightFacing;

    private void Awake()
    {
        rightFacing = true;
    }

    public void FlipX(bool rF)
    {
        if (rF != rightFacing)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            if (rightFacing == true)
            {
                rightFacing = false;
            }
            else
            {
                rightFacing = true;
            }
        }
    }

    public void FlipY()
    {
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
    }

}
