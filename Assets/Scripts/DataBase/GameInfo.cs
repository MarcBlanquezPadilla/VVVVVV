using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo.asset", menuName = "ScriptableObjectsScripts/GameInfo")]
public class GameInfo : ScriptableObject
{
    private string currentGame;
    private bool newGame;

    public void SetCurrentGameNull()
    {
        currentGame = null;
    }

    public void SetNewGameTrue()
    {
        newGame = true;
    }

    public void SetNewGameFalse()
    {
        newGame = false;
    }

    public void ChangeSelected(string gameName)
    {
        gameName = gameName.ToLower();
        currentGame = gameName;
    }

    public string GetName()
    {
        return currentGame;
    }

    public bool ReturnNewGame()
    {
        return newGame;
    }
}
