using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisabler : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private GameObject lvl;
    [SerializeField] private GameObject lvl2;

    private void Awake()
    {
        if (lvl != null)
        {
            lvl.SetActive(false);
        }
        if (lvl2 != null)
        {
            lvl2.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (lvl != null)
        {
            lvl.SetActive(true);
        }
        if (lvl2 != null)
        {
            lvl2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (lvl != null)
        {
            lvl.SetActive(false);
        }
        if (lvl2 != null)
        {
            lvl2.SetActive(false);
        }
    }
}
