using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SoundManager.Instance.PlayMusic("MenuMusic");
        }
        else
        {
            SoundManager.Instance.PlayMusic("InGameMusic");
        }  
    }

    public static void ReturnMainMenu()
    {
        SoundManager.Instance.StopAllAudios();
        SceneManager.LoadScene("MainMenu");
    }

    public static void PlayGame()
    {
        SoundManager.Instance.StopAllAudios();
        SceneManager.LoadScene("Game");
    }

    public static void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }

}
