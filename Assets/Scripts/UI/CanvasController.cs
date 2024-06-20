using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] Canvas inGameUi;
    [SerializeField] Canvas pauseUI;
    [SerializeField] Canvas optionsUi;
    [SerializeField] Canvas winUi;

    private void Awake()
    {
        inGameUi.enabled = true;
        pauseUI.enabled = false;
        optionsUi.enabled = false;
        winUi.enabled = false;
    }

    public void ToInGameUi()
    {
        inGameUi.enabled = true;
        pauseUI.enabled = false;
        optionsUi.enabled = false;
        winUi.enabled = false;
    }

    public void ToPauseUi()
    {
        inGameUi.enabled = false;
        pauseUI.enabled = true;
        optionsUi.enabled = false;
        winUi.enabled = false;
    }

    public void ToOptionsUi()
    {
        inGameUi.enabled = false;
        pauseUI.enabled = false;
        optionsUi.enabled = true;
        winUi.enabled = false;
    }

    public void ToWinUi()
    {
        inGameUi.enabled = false;
        pauseUI.enabled = false;
        optionsUi.enabled = false;
        winUi.enabled = true;
    }
}
